using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public abstract class Vehiculo
    {
        #region Enumerados/Atributos
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// Comentario para mi: Recordar Borrar: Las derivadas van a implementar esta propiedad.
        /// </summary>
        public abstract ETamanio Tamanio { get; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que recibe 3 parametros
        /// </summary>
        /// <param name="chasis">chasis tipo [string]</param>
        /// <param name="marca">marca tipo [Emarca] enum</param>
        /// <param name="color">color tipo [ConsoleColor]</param>
        public Vehiculo (string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            // Aca si o si, tengo que castear, por la sobrecarga EXPLICITA DE ABAJO
            return (string)this;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga de string EXPLICITA
        /// </summary>
        /// <param name="p">tipo de dato Vehiculo a mostrar</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca.ToString()}");
            sb.AppendLine($"COLOR : {p.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">[Vehiculo] 1 a comparar</param>
        /// <param name="v2">[Vehiculo] 2 a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">[Vehiculo] 1 a comparar</param>
        /// <param name="v2">[Vehiculo] 2 a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
