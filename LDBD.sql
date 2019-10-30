CREATE DATABASE LDFacturacionBD
USE LDFacturacionBD
GO
------------------------------TABLAS---------------------------------------

---TABLA DE ARTICULOS----
CREATE TABLE Articulos (
codigo INT PRIMARY KEY,
descripcion VARCHAR(100),
precio MONEY,
costo MONEY,
activo BIT,
impuesto MONEY
)
---TABLA DE FACTURAS---
CREATE TABLE Facturas(
idFactura INT IDENTITY(1,1) PRIMARY KEY,
cliente VARCHAR(50),
fecha DATETIME,
subTotal MONEY,
impuesto MONEY,
total MONEY
)

---TABLA DE FACTURAS_ARTICULOS---
CREATE TABLE Factura_Articulo(
codigo int foreign key (codigo) references Articulos(codigo),
idFactura int foreign key (idFactura) references Facturas (idfactura),
cantidad int,
descripcion VARCHAR(100),
subTotal MONEY,
impuesto MONEY,
total MONEY,
precio MONEY
)
GO

--------------------------PROCEDIMIENTOS ALMACENADOS--------------------------

----MOSTRAR FACTURA_ARTICULO----
CREATE PROCEDURE [mostrarFactura_Articulo]
AS
BEGIN
	SELECT *FROM Factura_Articulo;
END
GO
USE [LDFacturacionBD]
GO

----ELIMINAR FACTURA_ARTICULO----
CREATE PROCEDURE [eliminarFactura_Articulo]
@idFactura INT
AS
BEGIN	
	DELETE FROM Factura_Articulo WHERE idFactura=@idFactura;
END
GO
USE [LDFacturacionBD]
GO

----INSERTAR FACTURA ----
CREATE PROCEDURE [insertarFactura]
@cliente varchar(50),
@fecha datetime,
@subtotal MONEY,
@impuesto MONEY,
@total MONEY
AS
BEGIN
	INSERT INTO Facturas VALUES(@cliente,@fecha,@subtotal,@impuesto,@total);
END
GO
USE [LDFacturacionBD]
GO

----MODIFICAR FACTURA----
CREATE PROCEDURE [modificarFactura]
@idFactura INT,
@subtotal MONEY,
@impuesto MONEY,
@total MONEY
AS
BEGIN
	UPDATE Facturas SET subTotal=@subtotal,impuesto=@impuesto,total=@total
	WHERE idFactura=@idFactura
END
GO
USE [LDFacturacionBD]
GO

----MOSTRAR FACTURA----
CREATE PROCEDURE [mostrarFactura]
AS
BEGIN
	SELECT *FROM Facturas;
END
GO
USE [LDFacturacionBD]
GO


----ELIMINAR FACTURA----
CREATE PROCEDURE [eliminarFactura]
@idFactura INT
AS
BEGIN	
	DELETE Facturas WHERE idFactura=@idFactura;
END
GO
USE [LDFacturacionBD]
GO

----INSERTAR ARTICULO ----
CREATE PROCEDURE [insertarArticulo]
@codigo INT,
@descripcion VARCHAR(100),
@precio MONEY,
@costo MONEY,
@activo BIT
AS
BEGIN
	INSERT INTO Articulos VALUES(@codigo,@descripcion,@precio,@costo,@activo,@precio*0.13);
END
GO
USE [LDFacturacionBD]
GO

----MODIFICAR ARTICULO----
CREATE PROCEDURE [modificarArticulo]
@codigo INT,
@descripcion VARCHAR(100),
@precio MONEY,
@costo MONEY,
@activo BIT
AS
BEGIN
	UPDATE Articulos SET descripcion=@descripcion,precio=@precio,costo=@costo,activo=@activo,impuesto=@precio*0.13
	WHERE codigo=@codigo
END
GO
USE [LDFacturacionBD]
GO

----ELIMINAR ARTICULO----
CREATE PROCEDURE [eliminarArticulo]
@codigo INT
AS
BEGIN	
	DELETE Articulos WHERE codigo=@codigo;
END
GO
USE [LDFacturacionBD]
GO

----MOSTRAR ARTICULOS----
CREATE PROCEDURE [mostrarArticulo]
AS
BEGIN
	SELECT *FROM Articulos;
END
GO
USE [LDFacturacionBD]
GO


----ELIMINAR FACTURA_ARTICULO POR IDFACTURA Y CODIGO----
CREATE PROCEDURE [EliminarItemFactura_Factura_Articulo]
@idFactura INT,
@codigo INT
AS
BEGIN	
	DELETE FROM Factura_Articulo WHERE idFactura=@idFactura AND codigo=@codigo;

	DECLARE @subTotalFactura MONEY = (SELECT SUM(subTotal) FROM Factura_Articulo WHERE idFactura=@idFactura);
	DECLARE @impuestoFactura MONEY = (SELECT SUM(impuesto) FROM Factura_Articulo WHERE idFactura=@idFactura);
	DECLARE @total MONEY = (SELECT SUM(total) FROM Factura_Articulo WHERE idFactura=@idFactura);
	if @total IS NULL
	BEGIN
	set @subTotalFactura=0;
	set @impuestoFactura=0;
	set @total=0;
	END
	EXEC dbo.modificarFactura @idFactura,@subTotalFactura,@impuestoFactura,@total;  

	
END
GO
USE [LDFacturacionBD]
GO


----INSERTAR FACTURA_ARTICULO ----
CREATE PROCEDURE [insertarFactura_Articulo]
@codigo INT,
@idFactura INT,
@cantidad INT
AS
BEGIN
	DECLARE @precioUnitario MONEY;
	DECLARE @descripcion VARCHAR(100);
	SET @precioUnitario = (SELECT precio FROM Articulos WHERE codigo = @codigo);
	SET @descripcion = (SELECT descripcion FROM Articulos WHERE codigo = @codigo);

	INSERT INTO Factura_Articulo VALUES(@codigo,@idFactura,@cantidad,@descripcion,@precioUnitario*@cantidad,
									   ((@precioUnitario*@cantidad)*0.13),((@precioUnitario*1.13)*@cantidad),@precioUnitario);

	--- Calculo Factura Completa--
	DECLARE @subTotalFactura MONEY = (SELECT SUM(subTotal) FROM Factura_Articulo WHERE idFactura=@idFactura);
	DECLARE @impuestoFactura MONEY = (SELECT SUM(impuesto) FROM Factura_Articulo WHERE idFactura=@idFactura);
	DECLARE @total MONEY = (SELECT SUM(total) FROM Factura_Articulo WHERE idFactura=@idFactura);
	
	EXEC dbo.modificarFactura @idFactura,@subTotalFactura,@impuestoFactura,@total;  
	
END
GO
USE [LDFacturacionBD]
GO