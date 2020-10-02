using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        /// <summary>
        /// Consutructor que recibe un [double]
        /// </summary>
        /// <param name="numero">Double para inicializar el numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Inicializa el Numero en 0.
        /// </summary>
        public Numero()
            : this(0)
        {
        }
        /// <summary>
        /// Valida e inicializa el Numero utilizando un [string]
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Setea (Validando) el atributo numero, con el valor o con 0 en caso que no valide.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value); 
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el string recibido sea numerico
        /// </summary>
        /// <param name="strNumero">String a validad</param>
        /// <returns>Retorna el valor numerico en double de string o en caso que no valide retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            if(double.TryParse(strNumero, out retorno))
            {
                return retorno;
            }
            else
            {
                return retorno;
            }
        }
        /// <summary>
        /// Valida que el [string] sea un numero binario
        /// </summary>
        /// <param name="binario">[string] a validar</param>
        /// <returns>Devuelve true si es binario y False si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            for(int i = 0; i<binario.Length; i++)
            {
                if(binario[i] < '0' || binario[i] > '1')
                {
                    return false;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un [string] de Binario entero y natural a Decimal
        /// </summary>
        /// <param name="binario">[string] a convertir</param>
        /// <returns>Devuelve un [string] en Decimal, o "Valor Invalido" si no es posible convertir</returns>
        public static string BinarioDecimal(string binario)
        {
            if(EsBinario(binario))
            {
                return Convert.ToInt32(binario, 2).ToString();
            }
            else
            {
                return "Valor Invalido";
            }
        }
        /// <summary>
        /// Convierte un [double] entero y natural a binario
        /// </summary>
        /// <param name="numero">[double] a convertir</param>
        /// <returns>Devuelve el [string] del numero binario</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";
            int d = (int)numero;
            int resto;
            do
            {
                resto = d % 2;
                if (resto == 0)
                {
                    //binario += resto;
                    binario = binario.Insert(0, "0");
                }
                else
                {
                    //binario += "1";
                    binario = binario.Insert(0, "1");
                }
                d = d / 2;
            } while (d > 0);
            return binario;
        }
        /// <summary>
        /// Convierte un [string] entero y natural a binario
        /// </summary>
        /// <param name="numero">[string] a convertir</param>
        /// <returns>Devuelve el [string] del numero binario o Valor invalido si el string no es un numero</returns>
        public static string DecimalBinario(string numero)
        {
            double aux;
            if(double.TryParse(numero, out aux))
            {
                return Numero.DecimalBinario(aux);
            }
            else
            {
                return "Valor Invalido";
            }
        }
        #endregion

        #region Sobrecarga Operaciones
        /// <summary>
        /// Sobrecarga de operador suma [+]
        /// </summary>
        /// <param name="n1">Primer objeto Numero</param>
        /// <param name="n2">segundo objeto Numero</param>
        /// <returns>Devuelve un double que opera entre el atributo numero</returns>
        public static Double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador resta [-]
        /// </summary>
        /// <param name="n1">Primer objeto Numero</param>
        /// <param name="n2">segundo objeto Numero</param>
        /// <returns>Devuelve un double que opera entre el atributo numero</returns>
        public static Double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador multiplicacion [*]
        /// </summary>
        /// <param name="n1">Primer objeto Numero</param>
        /// <param name="n2">segundo objeto Numero</param>
        /// <returns>Devuelve un double que opera entre el atributo numero</returns>
        public static Double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador division [/]
        /// </summary>
        /// <param name="n1">Primer objeto Numero</param>
        /// <param name="n2">segundo objeto Numero</param>
        /// <returns>Devuelve un double que opera entre el atributo numero, si la division es por 0 devuelve double.minValue</returns>
        public static Double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion
    }
}
