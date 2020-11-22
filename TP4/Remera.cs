using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpExceptions;

namespace TP4
{
    public class Remera : Producto
    {
        #region ATRIBUTOS
        /// <summary>
        /// Enumerado para asignar a cada remera, que solo es requerido en el caso de VENTA
        /// </summary>
        public enum ETalle { NoDefinido, S, M, L, XL };
        public enum EColor { NoDefinido, Rojo, Negro, Blanco, Azul }
        private ETalle talle;
        private EColor color;

        /// <summary>
        /// Ubicacion del archivo que usan los empleados de produccio para fabricar el producto.
        /// </summary>
        private string ubicacionEstampa;
        #endregion

        #region PROPIEDADES
        public string UbicacionEstampa
        {
            get { return this.ubicacionEstampa; }
            set { this.ubicacionEstampa = value; }
        } 

        public ETalle Talle
        {
            get { return this.talle; }
            set { this.talle = value; }
        }

        public EColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia, que valida que el ubicacionEstampa sea una archivo de Illustrator .ai
        /// </summary>
        /// <param name="sku">Sku</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="precio">Precio</param>
        /// <param name="ubicacionEstampa">ubicacion de archivo ej: archivo.ai</param>
        /// 
        public Remera(string sku, string nombre, float precio, string ubicacionEstampa)
            : base(sku, nombre, precio)
        {
            if (this.ValidarEstampa(ubicacionEstampa))
            {
                this.UbicacionEstampa = ubicacionEstampa;
            }
            else
            {
                throw new ProductoInvalidoException("El tipo de archivo de la estampa es incorrecto");
            }
        }

        /// <summary>
        /// Constructor que recibe una remera del catalogo e instancia otra con la especificacion de talle y color
        /// </summary>
        /// <param name="remera">Remera a vender</param>
        /// <param name="talle">Talle</param>
        /// <param name="color">Color</param>
        public Remera(Remera remera, ETalle talle, EColor color)
            : this(remera.sku, remera.nombre, remera.precio, remera.ubicacionEstampa)
        {
            this.Talle = talle;
            this.Color = color;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Valida que un string tenga es sus ultimos tres caracteres .ai
        /// </summary>
        /// <param name="recurso">Cadena</param>
        /// <returns>True si sus ultimos caracteres son .ai</returns>
        private bool ValidarEstampa(string recurso)
        {
            bool retorno = false;
            string extension = recurso.Substring(recurso.Length - 3);
            if (recurso.Length > 3 && extension == ".ai")
            {
                retorno = true;
            }
            return retorno;
        }
        #endregion

        #region SOBRECARGA
        /// <summary>
        /// Sobrecarga ToString, agregando al base, precio, y talle y color en el caso que existan.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            if (!(this.Color == EColor.NoDefinido && this.Talle == ETalle.NoDefinido))
            {
                sb.Append($"TALLE: {this.Talle} - COLOR: {this.Color} - ");
            }
            sb.Append($"${this.Precio}");
            return sb.ToString();
        } 
        #endregion
    }
}
