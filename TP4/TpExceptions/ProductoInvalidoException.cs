using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpExceptions
{
    public class ProductoInvalidoException : Exception
    {
        /// <summary>
        /// Se usa para para cuando un producto no tiene todos los datos necesarios para ser instanciado para el catalogo
        /// </summary>
        /// <param name="mensaje"></param>
        public ProductoInvalidoException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
