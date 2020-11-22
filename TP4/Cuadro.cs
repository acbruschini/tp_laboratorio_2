using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpExceptions;

namespace TP4
{
    public class Cuadro : Producto
    {
        #region ATRIBUTOS
        /// <summary>
        /// Ubicacion arte es el archivo que usa producccion para imprimir el cuadro (.jpg)
        /// </summary>
        private string ubicacionArte;
        private string tamano;
        #endregion

        #region PROPIEDADES
        public string UbicacionArte
        {
            get { return this.ubicacionArte; }
            set { this.ubicacionArte = value; }
        }

        public string Tamano
        {
            get { return this.tamano; }
            set { this.tamano = value; }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Construye un Cuadro
        /// </summary>
        /// <param name="sku">Sku</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="precio">Precio</param>
        /// <param name="ubicacionArte">UbicacionArte , ej : archivo.jpg</param>
        /// <param name="tamano">AltoXAncho</param>
        public Cuadro(string sku, string nombre, float precio, string ubicacionArte, string tamano)
    : base(sku, nombre, precio)
        {
            if (this.ValidarArte(ubicacionArte))
            {
                this.UbicacionArte = ubicacionArte;
                this.Tamano = tamano;
            }
            else
            {
                throw new ProductoInvalidoException("El tipo de archivo de la estampa es incorrecto");
            }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Valida que los ultimos 4 caracteres de un string sean .jpg
        /// </summary>
        /// <param name="recurso">String a validad</param>
        /// <returns>True si el string tiene en sus ultimos caracteres .jpg</returns>
        private bool ValidarArte(string recurso)
        {
            bool retorno = false;
            string extension = recurso.Substring(recurso.Length - 4);
            if (recurso.Length > 3 && extension == ".jpg")
            {
                retorno = true;
            }
            return retorno;
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga toString utilizando la base y agregando el precio y tamano.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"${this.Precio} - TAMANO {this.Tamano}";
        } 
        #endregion
    }
}
