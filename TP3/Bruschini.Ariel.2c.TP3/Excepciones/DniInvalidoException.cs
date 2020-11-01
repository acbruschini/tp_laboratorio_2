using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Sera lanzada si se coloca un dni invalido.
    /// </summary>
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            : base("El Dni es invalido")
        {
        }
        public DniInvalidoException(Exception e)
            : base("El dni es invalido",e)
        {
        }
        public DniInvalidoException(string message)
            : base(message)
        {
        }
        public DniInvalidoException(string message, Exception e)
            : base(message,e)
        {
        }
    }
}
