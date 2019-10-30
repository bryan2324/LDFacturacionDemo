using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LDFacturacionBBL
{
    public class MantenimientoFactura__Articulo
    {
        private static MantenimientoFactura__Articulo Instancia;
        public static MantenimientoFactura__Articulo _Instancia
        {
            get
            {
                if (Instancia == null)
                {
                    return new MantenimientoFactura__Articulo();
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
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.Actualizar(factura_articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina los articulos de una determinada factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void Eliminar(Factura_Articulo factura_articulo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.Eliminar(factura_articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un determinado articulo de una factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void EliminarItemFactura(Factura_Articulo factura_articulo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.EliminarItemFactura(factura_articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Inserta los articulos en una determinada factura.
        /// </summary>
        /// <param name="factura_articulo"></param>
        public void Insertar(Factura_Articulo factura_articulo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.Insertar(factura_articulo);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Muestra todos los articulos relacionados a una factura
        /// </summary>
        /// <returns></returns>
        public List<Factura_Articulo> Mostrar()
        {
            List<Factura_Articulo> lista = new List<Factura_Articulo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.Mostrar();
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
        /// Verifica si existe un articulo en una determinada factura.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="idFactura"></param>
        /// <returns></returns>
        public bool ExisteEnFactura(int codigo,int idFactura)
        {
            List<Factura_Articulo> lista = new List<Factura_Articulo>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.Mostrar();
                    scope.Complete();
                    var elemento = lista.Where(x => x.codigo == codigo).Where(r => r.idFactura == idFactura);
                    
                    if (elemento.Count() > 0 )
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
    }
}
