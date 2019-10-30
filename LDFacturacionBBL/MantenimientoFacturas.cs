using LDFacturacionDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LDFacturacionBBL
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
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoFacturas._Instancia.Actualizar(factura);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Elimina una determinada factura.
        /// </summary>
        /// <param name="factura"></param>
        public void Eliminar(Factura factura)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    LDFacturacionDAL.MantenimientoFacturas._Instancia.Eliminar(factura);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Crea una nueva factura.
        /// </summary>
        /// <param name="factura"></param>
        public void Insertar(Factura factura)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    factura.fecha = System.DateTime.Now;
                    LDFacturacionDAL.MantenimientoFacturas._Instancia.Insertar(factura);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Muestra todas las facturas registradas.
        /// </summary>
        /// <returns></returns>
        public List<Factura> Mostrar()
        {
            List<Factura> lista = new List<Factura>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoFacturas._Instancia.Mostrar();
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
        /// Muestra una factura de acuerdo al Id recibido.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public List<Factura> MostrarPorIdFactura(int codigo)
        {
            List<Factura> lista = new List<Factura>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoFacturas._Instancia.Mostrar();
                    scope.Complete();
                }
                return lista.Where(x => x.idFactura == codigo).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve el Id la ultima factura registrada.
        /// </summary>
        /// <returns></returns>
        public int ultimoIdFactura()
        {
            List<Factura> lista = new List<Factura>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = LDFacturacionDAL.MantenimientoFacturas._Instancia.Mostrar();
                    scope.Complete();
                }
                return lista.LastOrDefault().idFactura;
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        /// <summary>
        /// Muestra los campos y articulos de una factura de acuerdo al id recibido.
        /// </summary>
        /// <param name="idFactura"></param>
        /// <returns></returns>
        public List<Factura> MostrarFactura(int idFactura)
        {
            Factura factura = new Factura();
            List<Factura_Articulo> listaItems = new List<Factura_Articulo>();
            List<Factura> listaCompleta = new List<Factura>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    factura = LDFacturacionDAL.MantenimientoFacturas._Instancia.Mostrar().Where(x=>x.idFactura==idFactura).FirstOrDefault();
                    listaItems = LDFacturacionDAL.MantenimientoFactura_Articulo._Instancia.Mostrar().Where(x => x.idFactura == idFactura).ToList();
                    scope.Complete();
                    factura.Items = listaItems.ToList();
                    listaCompleta.Add(factura);
                }
                return listaCompleta;
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
