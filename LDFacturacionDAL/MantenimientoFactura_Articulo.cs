using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDFacturacionDAL
{
    public class MantenimientoFactura_Articulo
    {

        private static MantenimientoFactura_Articulo Instancia;
        public static MantenimientoFactura_Articulo _Instancia
        {
            get
            {
                if (Instancia == null)
                {
                    return new MantenimientoFactura_Articulo();
                }
                return Instancia;
            }
            set
            {
                if (Instancia == null)
                {
                    Instancia = value;
                }
            }
        }

        /// <summary>
        /// Actualiza los elementos de una determinada factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void Actualizar(Factura_Articulo factura_articulo)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                DbParameter param0 = factory.CreateParameter();
                DbParameter param1 = factory.CreateParameter();
                DbParameter param2 = factory.CreateParameter();

                param0.ParameterName = "@codigo";
                param0.DbType = DbType.Int32;
                param0.Value = factura_articulo.codigo;

                param1.ParameterName = "@idFactura";
                param1.DbType = DbType.Int32;
                param1.Value = factura_articulo.idFactura;

                param2.ParameterName = "@cantidad";
                param2.DbType = DbType.Int32;
                param2.Value = factura_articulo.cantidad;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "modificarFactura_Articulo";
                comm.Parameters.Add(param0);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);

                comm.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Elimina los articulos de una determinada factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void Eliminar(Factura_Articulo factura_articulo)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                DbParameter param0 = factory.CreateParameter();

                param0.ParameterName = "@idFactura";
                param0.DbType = DbType.Int32;
                param0.Value = factura_articulo.idFactura;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "eliminarFactura_Articulo";
                comm.Parameters.Add(param0);
                comm.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Elimina un articulo especifico en una factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void EliminarItemFactura(Factura_Articulo factura_articulo)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                DbParameter param0 = factory.CreateParameter();
                DbParameter param1 = factory.CreateParameter();

                param0.ParameterName = "@idFactura";
                param0.DbType = DbType.Int32;
                param0.Value = factura_articulo.idFactura;

                param1.ParameterName = "@codigo";
                param1.DbType = DbType.Int32;
                param1.Value = factura_articulo.codigo;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "EliminarItemFactura_Factura_Articulo";
                comm.Parameters.Add(param0);
                comm.Parameters.Add(param1);
                comm.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                throw;
            }
            finally
            {
                comm.Dispose();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Inserta los articulos en una determinada factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void Insertar(Factura_Articulo factura_articulo)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);
            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                DbParameter param0 = factory.CreateParameter();
                DbParameter param1 = factory.CreateParameter();
                DbParameter param2 = factory.CreateParameter();

                param0.ParameterName = "@codigo";
                param0.DbType = DbType.Int32;
                param0.Value = factura_articulo.codigo;

                param1.ParameterName = "@idFactura";
                param1.DbType = DbType.Int32;
                param1.Value = factura_articulo.idFactura;

                param2.ParameterName = "@cantidad";
                param2.DbType = DbType.Int32;
                param2.Value = factura_articulo.cantidad;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "insertarFactura_Articulo";
                comm.Parameters.Add(param0);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);

                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Muestra todos los articulos relacionados a una factura
        /// </summary>
        /// <returns></returns>
        public List<Factura_Articulo> Mostrar()
        {
            //Inicializamos
            List<Factura_Articulo> lista = new List<Factura_Articulo>();

            DbConnection conn = null;
            DbCommand comm = null;

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(Settings.Default.proveedor);

                conn = factory.CreateConnection();
                conn.ConnectionString = Settings.Default.connection;
                comm = factory.CreateCommand();

                comm.Connection = conn;
                conn.Open();

                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "mostrarFactura_Articulo";

                using (IDataReader dataReader = comm.ExecuteReader())
                {
                    Factura_Articulo factura_articulo;
                    while (dataReader.Read())
                    {
                        factura_articulo = new Factura_Articulo
                        {
                            codigo = Convert.ToInt32(dataReader["codigo"].ToString()),
                            idFactura = Convert.ToInt32(dataReader["idFactura"].ToString()),
                            cantidad = Convert.ToInt32(dataReader["cantidad"].ToString()),
                            descripcion = dataReader["descripcion"].ToString(),
                            subtotal = Convert.ToDecimal(dataReader["subTotal"].ToString()),
                            impuesto = Convert.ToDecimal(dataReader["impuesto"].ToString()),
                            total = Convert.ToDecimal(dataReader["total"].ToString()),
                            precio = Convert.ToDecimal(dataReader["precio"].ToString())
                        };
                        lista.Add(factura_articulo);
                    }
                }
                return lista;
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
