using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Get y set de la lista Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        
        /// <summary>
        /// Get y set del atributo Clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Get y set del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region CONSTRUCTORES 
        /// <summary>
        /// Constructor de clase Jornada que instancia lista.
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Consutructor de Jornada
        /// </summary>
        /// <param name="clase">Clases</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.instructor = instructor;
            this.clase = clase;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Sobreescribir ToString
        /// </summary>
        /// <returns>Retorna la info de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE: {this.Clase} POR NOMBRE COMPLETO: {this.Instructor.ToString()}");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("<------------------------------------------------------>");
            return sb.ToString();
        }

        /// <summary>
        /// Guarda en un txt una jornada
        /// </summary>
        /// <param name="j">Jornada a Guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            try
            {
                Texto txt = new Texto();
                txt.Guardar("Jornadas.txt", j.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lee de un archivo una jornada
        /// </summary>
        /// <returns>Retorna el contenido del archivo</returns>
        public static string Leer()
        {
            try
            {
                string retorno;
                Texto txt = new Texto();
                if (txt.Leer("Jornadas.txt", out retorno))
                {
                    return retorno;
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno se encuentra en la lista de alumno de la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga !=
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno no se encuentra en lista de alumnos de jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga +
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la Jornada con el alumno en el caso que este no se encuentre previamente</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        } 
        #endregion

    }
}
