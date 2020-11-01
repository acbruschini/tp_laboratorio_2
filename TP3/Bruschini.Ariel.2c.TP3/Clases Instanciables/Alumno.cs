using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS
        public enum EEstadoCuenta { AlDia, Deudor, Becado };
        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases clasesQueToma;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de Alumno con los valores por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de Alumno
        /// </summary>
        /// <param name="id">Id o Lejajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">Dni</param>
        /// <param name="nacionalidad">Nacionalidad Extranjero o Argentino</param>
        /// <param name="claseQueToma">EClases</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de Alumno
        /// </summary>
        /// <param name="id">Id o Lejajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">Dni</param>
        /// <param name="nacionalidad">Nacionalidad Extranjero o Argentino</param>
        /// <param name="claseQueToma">EClases</param>
        /// <param name="estadoCuenta">Estado de cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Participar en clase
        /// </summary>
        /// <returns>Retorna un string con las Clases que toma el Alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.clasesQueToma;
        }

        /// <summary>
        /// Muestra los datos del Alumn
        /// </summary>
        /// <returns>Retorna un string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribe ToString
        /// </summary>
        /// <returns>Retorna los datos del alumno usando MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region SOBRECARGAS

        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el alumno toma esa clase y su estado de cuenta es distinto a Deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.clasesQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Sobrecarga !=
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clases que toma</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.clasesQueToma != clase;
        } 
        #endregion
    }
}
