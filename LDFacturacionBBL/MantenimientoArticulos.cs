using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace LDFacturacionBBL
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
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoArticulos._Instancia.Actualizar(articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un articulo
        /// </summary>
        /// <param name="articulo"></param>
        public void Eliminar(Articulo articulo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoArticulos._Instancia.Eliminar(articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }
        
        /// <summary>
        /// Crea un articulo nuevo.
        /// </summary>
        /// <param name="articulo"></param>
        public void Insertar(Articulo articulo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoArticulos._Instancia.Insertar(articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Muestra una lista completa de todos los articulos con sus respectivos campos..
        /// </summary>
        /// <returns></returns>
        public List<Articulo> Mostrar()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoArticulos._Instancia.Mostrar();
                    scope.Complete();
                }
                return lista;
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Muestra las los campos de un determinado articulo de acuerdo al codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public List<Articulo> MostrarPorCodigo(int codigo)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoArticulos._Instancia.Mostrar();
                    scope.Complete();
                }
                return lista.Where(x=>x.codigo==codigo).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida si el articulo existe y no se encuentra inactivo.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public bool ValidarItem(int codigo)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoArticulos._Instancia.Mostrar();
                    scope.Complete();
                    var elemento = lista.Where(x => x.codigo == codigo).Where(r => r.activo == true);

                    if (elemento.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el nombre de un articulo de acuerdo al codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public string obtenerNombreArticulo(int codigo)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    string nombreArticulo = "";
                    lista = LDFacturacionDAL.MantenimientoArticulos._Instancia.Mostrar();
                    scope.Complete();
                    var elemento = lista.Where(x => x.codigo == codigo);
                    
                    if (elemento.Count() > 0)
                    {
                        foreach (var item in elemento)
                        {
                            nombreArticulo = item.descripcion;
                        }
                        
                        return nombreArticulo;
                    }
                    else
                    {
                        return nombreArticulo;
                    }
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}