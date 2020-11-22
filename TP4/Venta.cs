using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpExceptions;

namespace TP4
{
    public class Venta
    {
        #region ATRIBUTOS
        /// <summary>
        /// Lista de producto que componen esta venta.
        /// </summary>
        private List<Producto> productosAFacturar;
        private float precioTotal;
        private string nombre;
        private string apellido;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Apellido del cliente
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        /// <summary>
        /// Lista de productos que va a comprar el cliente
        /// </summary>
        public List<Producto> ProductosAFacturar
        {
            get { return this.productosAFacturar; }
            //set { this.productosAFacturar = value; }
        }

        /// <summary>
        /// Acceso a la lista de productos indentada para en un futuro hacer un gestor que pueda borrar productos por index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Producto this[int i]
        {
            get { return this.ProductosAFacturar[i]; }
            set { this.ProductosAFacturar[i] = value; }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Construye una venta e instancia la lista de productos de esa venta
        /// </summary>
        /// <param name="nombre">Nombre Cliente</param>
        /// <param name="apellido">Apellido Cliente</param>
        public Venta(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.productosAFacturar = new List<Producto>();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Suma una remera a una venta
        /// </summary>
        /// <param name="v">Venta</param>
        /// <param name="r">Remera</param>
        /// <returns></returns>
        public static bool operator +(Venta v, Remera r)
        {
            bool retorno = false;
            if (r.Talle == Remera.ETalle.NoDefinido || r.Color == Remera.EColor.NoDefinido)
            {
                throw new RemeraSinTalleColor("Para agregar el producto a la venta debes especificar Talle y Color de la Remera");
            }
            else
            {
                v.ProductosAFacturar.Add(r);
                v.precioTotal += r.Precio;
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Suma un cuadro a una venta
        /// </summary>
        /// <param name="v">Venta</param>
        /// <param name="c">Cuadro</param>
        /// <returns></returns>
        public static bool operator +(Venta v, Cuadro c)
        {
            bool retorno = false;
            if (!(v is null) && !(c is null))
            {
                v.ProductosAFacturar.Add(c);
                v.precioTotal += c.Precio;
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Borra un producto de una venta mediante su index
        /// </summary>
        /// <param name="v">Venta</param>
        /// <param name="index">Index del producto a borrar</param>
        /// <returns></returns>
        public static bool operator -(Venta v, int index)
        {
            bool retorno = false;
            if (!(v is null) && index < v.ProductosAFacturar.Count())
            {
                v.precioTotal -= v[index].Precio;
                v.ProductosAFacturar.RemoveAt(index);
            }
            return retorno;
        } 
        
        /// <summary>
        /// Genera una factura de una venta.
        /// </summary>
        /// <param name="v">Venta</param>
        /// <returns></returns>
        public string GenerarFactura(Venta v)
        {
            return v.ToString();
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga del string que da toda la info de la venta (se usa para generar la factura)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOTAL A FACTURAR A: {this.Nombre} {this.Apellido}");
            sb.AppendLine($"-------------------------------------------------------------");
            if (this.ProductosAFacturar.Count() == 0)
            {
                sb.AppendLine("No existen productos a facturar");
            }
            else
            {
                foreach (Producto p in this.ProductosAFacturar)
                {
                    sb.AppendLine(p.ToString());
                }
            }
            sb.AppendLine($"-------------------------------------------------------------");
            sb.AppendLine($"TOTAL: ${this.precioTotal}");
            return sb.ToString();
        } 
        #endregion
    }
}
