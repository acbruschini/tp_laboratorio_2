using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region ATRIBUTOS
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD };
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Get y set de la lista Alumons
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
        /// Get y set lista Profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Get y set lista Jornada
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indenacion que devuelve la jornada en la lisa de jornada
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornada[i];
            }
            set
            {
                this.Jornada[i] = value;
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor sin parametros que instancia las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Profesores = new List<Profesor>();
            this.Jornada = new List<Jornada>();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Retorna string con los datos de todas las jornadas</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in uni.Jornada)
            {
                sb.AppendLine(j.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura de TOstring
        /// </summary>
        /// <returns>Retona mostrardatos()</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Lee un archivo (en mismo lugar del exe) XML con los datos de una universdad
        /// </summary>
        /// <returns>Retorna una univeridad</returns>
        public static Universidad Leer()
        {
            Universidad uniAux;
            try
            {
                Xml<Universidad> xmlFile = new Xml<Universidad>();
                xmlFile.Leer("Universidad.xml", out uniAux);
                return uniAux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Guarda un archivo XML (en mismo lugar que el EXE) de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> xmlFile = new Xml<Universidad>();
                xmlFile.Guardar("Universidad.xml", uni);
                return true;
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
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si la universidad tiene a ese alumno inscripto</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno a1 in g.Alumnos)
            {
                if (a1 == a)
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
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si la universidad NO tiene a ese alumno inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>True si la universidad tiene a ese profesor dando clases</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor prof in g.Profesores)
            {
                if (prof == i)
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
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>True si la universidad NO tiene a ese profesor dando clases</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Clase</param>
        /// <returns>Retorna el primer profesor de esa universidad que pueda dar esa clase</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga !=
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Clase</param>
        /// <returns>Retorna el primer profesor de esa universidad que NO pueda dar esa clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga +
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
                return g;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Sobrecarga +
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>Universidad con el profesor agregado</returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
            {
                g.Profesores.Add(p);
            }
            return g;
        }

        /// <summary>
        /// Agrega la clase y enconrando un profesor que la de y agregando la jornada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            // ENCUENTRO UN PROFESOR QUE PUEDA DAR LA CLASE
            Profesor p = g == clase;
            Jornada j = new Jornada(clase, p);
            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    j = j + a;
                }
            }
            g.Jornada.Add(j);
            return g;
        } 
        #endregion

    }
}
