using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Ciclomotor : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la instancia Ciclomotor, usa el constructor de la base.
        /// </summary>
        /// <param name="marca">[Emarca] marca del Ciclomotor</param>
        /// <param name="chasis">[string] chasis del Ciclomotor</param>
        /// <param name="color">[ConsoleColor] Color del Ciclomotor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis,marca,color)
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribe el metodo Mostrar de la clase base, utilizandolo.
        /// </summary>
        /// <returns>[String] con la info del Ciclomotor</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
