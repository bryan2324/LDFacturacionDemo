using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace LDFacturacionDAL
{
    public class MantenimientoArticulos
    {
        private static MantenimientoArticulos Instancia;
        public static MantenimientoArticulos _Instancia
        {
            get
            {
                if (Instancia == null)
                {
                    return new MantenimientoArticulos();
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
        /// Actualiza los campos de un articulo.
        /// </summary>
        /// <param name="articulo"></param>
        public void Actualizar(Articulo articulo)
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

                param0.ParameterName = "@codigo";
                param0.DbType = DbType.Int32;
                param0.Value = articulo.codigo;

                param1.ParameterName = "@descripcion";
                param1.DbType = DbType.String;
                param1.Value = articulo.descripcion;

                param2.ParameterName = "@precio";
                param2.DbType = DbType.Decimal;
                param2.Value = articulo.precio;

                param3.ParameterName = "@costo";
                param3.DbType = DbType.Decimal;
                param3.Value = articulo.costo;

                param4.ParameterName = "@activo";
                param4.DbType = DbType.Boolean;
                param4.Value = articulo.activo;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "modificarArticulo";
                comm.Parameters.Add(param0);
                comm.Parameters.Add(param1);
                comm.Parameters.Add(param2);
                comm.Parameters.Add(param3);
                comm.Parameters.Add(param4);

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
        /// Elimina un articulo
        /// </summary>
        /// <param name="articulo"></param>
        public void Eliminar(Articulo articulo)
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

                param0.ParameterName = "@codigo";
                param0.DbType = DbType.Int32;
                param0.Value = articulo.codigo;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "eliminarArticulo";
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
        /// Crea un articulo nuevo.
        /// </summary>
        /// <param name="articulo"></param>
        public void Insertar(Articulo articulo)
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

                param0.ParameterName = "@codigo";
                param0.DbType = DbType.Int32;
                param0.Value = articulo.codigo;

                param1.ParameterName = "@descripcion";
                param1.DbType = DbType.String;
                param1.Value = articulo.descripcion;

                param2.ParameterName = "@precio";
                param2.DbType = DbType.Decimal;
                param2.Value = articulo.precio;

                param3.ParameterName = "@costo";
                param3.DbType = DbType.Decimal;
                param3.Value = articulo.costo;

                param4.ParameterName = "@activo";
                param4.DbType = DbType.Boolean;
                param4.Value = articulo.activo;

                //Abrir Conx
                comm.Connection = conn;
                conn.Open();

                //Ejecutar SP y pasar parametros 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "insertarArticulo";
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
        /// Muestra una lista completa de todos los articulos con sus respectivos campos..
        /// </summary>
        /// <returns></returns>
        public List<Articulo> Mostrar()
        {
            //Inicializamos
            List<Articulo> lista = new List<Articulo>();

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
                comm.CommandText = "mostrarArticulo";

                using (IDataReader dataReader = comm.ExecuteReader())
                {
                    Articulo articulo;
                    while (dataReader.Read())
                    {
                        articulo = new Articulo
                        {
                            codigo = Convert.ToInt32(dataReader["codigo"].ToString()),
                            descripcion = dataReader["descripcion"].ToString(),
                            precio = Convert.ToDecimal(dataReader["precio"].ToString()),
                            costo = Convert.ToDecimal(dataReader["costo"].ToString()),
                            activo = Convert.ToBoolean(dataReader["activo"].ToString())
                        };
                        lista.Add(articulo);
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