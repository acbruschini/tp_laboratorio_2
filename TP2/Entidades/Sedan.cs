using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Sedan : Vehiculo
    {
        #region Enumerados/Atributos
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la instancia Sedan, usa el constructor de la base. Tipo por defecto CuatroPuertas
        /// </summary>
        /// <param name="marca">[Emarca] marca del Sedan</param>
        /// <param name="chasis">[string] chasis del Sedan</param>
        /// <param name="color">[ConsoleColor] Color del Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }
        /// <summary>
        /// Constructor de la instancia Sedan, usa el constructor de la base. Tipo por defecto CuatroPuertas
        /// </summary>
        /// <param name="marca">[Emarca] marca del Sedan</param>
        /// <param name="chasis">[string] chasis del Sedan</param>
        /// <param name="color">[ConsoleColor] Color del Sedan</param>
        /// <param name="tipo">[Etipo] Cantidad de Puertas del Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribe el metodo Mostrar de la clase base, utilizandolo.
        /// </summary>
        /// <returns>[String] con la info del SEDAN</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
