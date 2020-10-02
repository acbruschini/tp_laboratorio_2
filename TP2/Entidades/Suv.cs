using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Suv : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Solo lectura SUV son 'Grande'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la instancia SUV, usa el constructor de la base.
        /// </summary>
        /// <param name="marca">[Emarca] marca del SUV</param>
        /// <param name="chasis">[string] chasis del SUV</param>
        /// <param name="color">[ConsoleColor] color del SUV</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribe el metodo Mostrar de la clase base, utilizandolo.
        /// </summary>
        /// <returns>[String] con la info del Suv</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
