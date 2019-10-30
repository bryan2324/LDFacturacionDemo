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
    public class MantenimientoFacturas
    {
        private static MantenimientoFacturas Instancia;
        public static MantenimientoFacturas _Instancia
        {
            get
            {
                if (Instancia == null)
                {
                    return new MantenimientoFacturas();
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
        /// Actualiza los campos de la factura.
        /// </summary>
        /// <param name="factura"></param>
        public void Actualizar(Factura factura)
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
                DbParameter param3 = factory.CreateParameter();
                DbParameter param4 = factory.CreateParameter();

                param0.ParameterName = "@idFactura";
                param0.DbType = DbType.Int32;
                param0.Value = factura.idFactura;


                param1.ParameterName = "@subtotal";
                param1.DbType = DbType.Decimal;
                param1.Value = factura.subtotal;

                param2.ParameterName = "@impuesto";
                param2.DbType = DbType.Decimal;
                param2.Value = factura.impuesto;

                param3.ParameterName = "@total";
                param3.DbType = DbType.Decimal;
                param3.Value = factura.total;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "modificarFactura";
                comm.Parameters.Add(param0);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
        
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
        /// Elimina una determinada factura.
        /// </summary>
        /// <param name="factura"></param>
        public void Eliminar(Factura factura)
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
                param0.Value = factura.idFactura;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "eliminarFactura";
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
        /// Crea una nueva factura.
        /// </summary>
        /// <param name="factura"></param>
        public void Insertar(Factura factura)
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
                DbParameter param3 = factory.CreateParameter();
                DbParameter param4 = factory.CreateParameter();

                param0.ParameterName = "@cliente";
                param0.DbType = DbType.String;
                param0.Value = factura.cliente;

                param1.ParameterName = "@fecha";
                param1.DbType = DbType.DateTime;
                param1.Value = factura.fecha;

                param2.ParameterName = "@subtotal";
                param2.DbType = DbType.Decimal;
                param2.Value = factura.subtotal;

                param3.ParameterName = "@impuesto";
                param3.DbType = DbType.Decimal;
                param3.Value = factura.impuesto;

                param4.ParameterName = "@total";
                param4.DbType = DbType.Decimal;
                param4.Value = factura.total;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "insertarFactura";
                comm.Parameters.Add(param0);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.Parameters.Add(param4);

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
        /// Muestra todas las facturas registradas.
        /// </summary>
        /// <returns></returns>
        public List<Factura> Mostrar()
        {
            //Inicializamos
            List<Factura> lista = new List<Factura>();

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
                comm.CommandText = "mostrarFactura";

                using (IDataReader dataReader = comm.ExecuteReader())
                {
                    Factura factura;
                    while (dataReader.Read())
                    {
                        factura = new Factura
                        {
                            idFactura = Convert.ToInt32(dataReader["idFactura"].ToString()),
                            cliente = dataReader["cliente"].ToString(),
                            fecha = Convert.ToDateTime(dataReader["fecha"].ToString()),
                            subtotal = Convert.ToDecimal(dataReader["subTotal"].ToString()),
                            impuesto = Convert.ToDecimal(dataReader["impuesto"].ToString()),
                            total = Convert.ToDecimal(dataReader["total"].ToString())

                        };
                        lista.Add(factura);
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
