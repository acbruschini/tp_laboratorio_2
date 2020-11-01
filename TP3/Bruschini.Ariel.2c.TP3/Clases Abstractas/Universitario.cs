using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region ATRIBUTOS
        private int legajo;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de Universitario con los valores por defecto
        /// </summary>
        public Universitario()
        {

        }
        
        /// <summary>
        /// Constructor de Universitario
        /// </summary>
        /// <param name="legajo">Legajo o ID</param>
        /// <param name="nombre">Nombre de Universitario</param>
        /// <param name="apellido">Apellido de Universitario</param>
        /// <param name="dni">Dni de universitario</param>
        /// <param name="nacionalidad">Nacionalidad (Extranjero o Argentino)</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra los datos del Universitario
        /// </summary>
        /// <returns>String con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto que asigna Clase en clases instanciables
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobreescribe el Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si el objeto es Universitario</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>True si ambos son universitario y su legajo o su dni son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni);
        }

        /// <summary>
        /// Sobrecarga != (Usa sobrecarga ==)
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        } 
        #endregion
    }
}
