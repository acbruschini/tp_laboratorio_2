using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor estatico para instanciar un random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id">id o legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">Dni</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Sobreescritura del metodo base mostrar datos
        /// </summary>
        /// <returns>Retorna string con datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Asigna clases a Profesor
        /// </summary>
        /// <returns>Retorna string con los datos de las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura de to string
        /// </summary>
        /// <returns>Retorna string informacion del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Metodo privado que asigna dos clases al azar no repetidas
        /// </summary>
        private void _randomClases()
        {
            int cantidad = Enum.GetNames(typeof(Universidad.EClases)).Length;
            int clase1 = random.Next(0, cantidad);
            int clase2;
            do
            {
                Thread.Sleep(200);
                clase2 = random.Next(0, cantidad);
            } while (clase1 == clase2);

            this.clasesDelDia.Enqueue((Universidad.EClases)clase1);
            this.clasesDelDia.Enqueue((Universidad.EClases)clase2);

        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga ==
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor da esa clase</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
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
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor no da esa clase</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        } 
        #endregion

    }
}
