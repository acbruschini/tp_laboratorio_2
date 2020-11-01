using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Sera en el caso que exista un error al crear/leer archivos.
    /// </summary>
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException)
            : base("Error en archivo",innerException)
        {
        }
    }
}
