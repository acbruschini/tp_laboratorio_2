using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Negocio
    {
        #region ATRIBUTOS
        /// <summary>
        /// Nombre del comercio
        /// Lista de ventas a facturar
        /// Lista de productos del catalogo
        /// </summary>
        private string nombre;
        private List<Venta> ventas;
        private List<Producto> productos;
        #endregion

        #region PROPIEDADES
        public List<Producto> Productos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        public List<Venta> Ventas
        {
            get { return this.ventas; }
            set { this.ventas = value; }
        }
        #endregion

        #region CONSTRUCTORES
        public Negocio(string nombre)
        {
            this.nombre = nombre;
            this.ventas = new List<Venta>();
            this.productos = new List<Producto>();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Agrega productos al catalogo disponible para la venta
        /// </summary>
        /// <param name="n">Negocio</param>
        /// <param name="p">Producto</param>
        /// <returns></returns>
        public static bool operator +(Negocio n, Producto p)
        {
            bool retorno = false;
            bool existeProducto = false;

            if(!(n is null) && !(p is null))
            {
                foreach (Producto producto in n.Productos)
                {
                    if(producto == p)
                    {
                        existeProducto = true;
                        break;
                    }
                }
                if (existeProducto == false)
                {
                    n.Productos.Add(p);
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion
    }
}
