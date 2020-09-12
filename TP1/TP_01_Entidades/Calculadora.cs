using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Valida y realiza una operacion matematica entre dos [doubles]
        /// </summary>
        /// <param name="num1">Primer [double]</param>
        /// <param name="num2">Segundo [double]</param>
        /// <param name="operador">Operador +,-,*,/ [string]]</param>
        /// <returns></returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            
            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    return num1 + num2;
                    //break;
                case "-":
                    return num1 - num2;
                    //break;
                case "*":
                    return num1 * num2;
                   // break;
                case "/":
                    return num1 / num2;
                // break;
            }
            return 0;
        }
        
        /// <summary>
        /// Valida que el operador recibido sea +,-,* o /
        /// </summary>
        /// <param name="operador">Operador a validad [char]</param>
        /// <returns>Retorna el operador en [string] si es true, o + si es False</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador.ToString();
            }
            return retorno;
        }
        #endregion
    }
}
