using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpExceptions
{
    public class RemeraSinTalleColor : Exception
    {
        /// <summary>
        /// Se usa para cuando queres agregar a una venta una remera, pero no especificas talle y color
        /// </summary>
        /// <param name="mensaje"></param>
        public RemeraSinTalleColor(string mensaje)
            : base(mensaje)
        {

        }
    }
}
