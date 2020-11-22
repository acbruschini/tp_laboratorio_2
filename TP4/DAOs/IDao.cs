using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    interface IDao <T,U>
    {
        bool TraerDatosDeDB(List<T> productosExistentes);
        bool BorrarRowsDB(List<U> lista, string columna);
    }
}
