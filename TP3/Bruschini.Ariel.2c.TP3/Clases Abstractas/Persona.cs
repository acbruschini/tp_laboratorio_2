using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        #region ATRIBUTOS
        public enum ENacionalidad {Argentino,Extranjero};
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Get y Set del atributo Nombre (El set valida que el apellido tenga mas de dos letras, sin numeros ni caracteres especiales
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                    this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Get y Set del atributo Apellido (El set valida mismo criterio que set del atributo nombre)
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Gey y set del atributo Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Set del atributo DNI, utilizando y validando un string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Get y set del atributo DNI, Valida que el numero y la nacionalidad sean correctos usando ValidarDni)
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de Persona con los valores por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Nombre del Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="nacionalidad">Extranjero o Argentino</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Nombre del Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">Dni de la Persona</param>
        /// <param name="nacionalidad">Extranjero o Argentino</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Nombre del Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">Dni de la Persona en string</param>
        /// <param name="nacionalidad">Extranjero o Argentino</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Valida Nombre o Apellido, tiene que tener mas de 2 letras y ningun numero ni caracter especial
        /// </summary>
        /// <param name="s">Nombre o Apellido a Validar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string s)
        {
            string retorno = "";
            if (s.Count() > 2 && !(s.Any(char.IsDigit)))
            {
                retorno = s;
            }
            return retorno; 
        }

        /// <summary>
        /// Valida un Int de Dni en relacion a la nacionalidad (Si es Argentino tiene que ser mayor a 0 y menor 999999999, y si es extranjero mayor a 89999999 y menor o igual a 99999999)
        /// </summary>
        /// <param name="nacionalidad">Argentino o Estranjero</param>
        /// <param name="dato">Dni</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && (dato >= 1 && dato <= 89999999))
                ||
               (nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato <= 99999999)))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Valida que un string sea DNI (Todos los caracteres deben ser numeros) y luego usa metodo con Int para validar DNI con Nacionalidad)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni))
            {
                return this.ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Sobreescribe el ToString
        /// </summary>
        /// <returns>String con los datos de la Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Nombre} {this.Apellido}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            if(this.Dni != 0)
            {
                sb.AppendLine($"DNI: {this.Dni}");
            }
            return sb.ToString();
        }
        #endregion

    }
}
