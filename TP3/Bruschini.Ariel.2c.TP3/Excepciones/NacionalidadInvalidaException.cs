using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Se lanza en el caso que el dni no coincida con la nacionalidad
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el numero de DNI")
        {
        }
        public NacionalidadInvalidaException(string message)
            : base(message)
        {
        }
    }
}
