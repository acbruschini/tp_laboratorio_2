using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpExceptions;

namespace TP4
{
    public abstract class Producto
    {
        #region ATRIBUTOS
        /// <summary>
        /// Precio del producto
        /// Nombre del producto
        /// Sku, codigo unico de producto en formato CU o RE (CU para cuadros, RE para remeras) y 0000
        /// </summary>
        protected float precio;
        protected string nombre;
        protected string sku;
        #endregion

        #region PROPIEDADES
        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Sku
        {
            get { return this.sku; }
            set { this.sku = value; }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructo de producto, que valida que los datos sean correctos antes de instanciar.
        /// </summary>
        /// <param name="sku">Codigo unico ej: CU0001</param>
        /// <param name="nombre">Nombre del producto</param>
        /// <param name="precio">Precio</param>
        public Producto(string sku, string nombre, float precio)
        {
            if (this.ValidarStringProducto(sku, 5) && this.ValidarStringProducto(nombre, 2))
            {
                this.Sku = sku;
                this.Nombre = nombre;
                this.Precio = precio;
            }
            else
            {
                throw new ProductoInvalidoException("Alguno de los datos del producto es incorrecto");
            }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Valida que la cantidad de caracteres en un string sea mas que otro numero
        /// </summary>
        /// <param name="nombre">String a validar</param>
        /// <param name="length">Numero minimo de caracteres que tiene que tener</param>
        /// <returns>True si es valido</returns>
        protected bool ValidarStringProducto(string nombre, int length)
        {
            bool retorno = false;
            if (nombre.Length > length)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Compra que dos productos son iguales solo si el SKU, que es codigo unico de producto, es el mismo.
        /// </summary>
        /// <param name="a">Producto 1</param>
        /// <param name="b">Producto 2</param>
        /// <returns>True si es igual</returns>
        public static bool operator ==(Producto a, Producto b)
        {
            return a.Sku == b.Sku;
        }
        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarca del metodo ToString que luego se usa en las clases heredadas
        /// </summary>
        /// <returns>String con el SKU y el Nombre</returns>
        public override string ToString()
        {
            return $"SKU {this.Sku} - {this.Nombre} - ";
        } 
        #endregion
    }
}
