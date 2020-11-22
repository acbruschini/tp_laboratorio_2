using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //AGREGAR
using System.Runtime.Serialization.Formatters.Binary; //AGREGAR

namespace Archivos
{
    public class Binario<T> : IArchivo<T>
    {
        // RECORDAR AGREGAR EL SERIALIZABLE
        /*
         [Serializable]

        class MiClase
        */

        public bool Guardar(string nombreArchivo, T objeto)
        {
            Stream fileStream = new FileStream(nombreArchivo, FileMode.Create);
            try
            {              
                BinaryFormatter serializer = new BinaryFormatter();

                serializer.Serialize(fileStream, objeto);
                return true;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public bool Leer(string nombreArchivo, out T objeto)
        {
            Stream fileStream = new FileStream(nombreArchivo, FileMode.Open);
            try
            {
                BinaryFormatter ser = new BinaryFormatter();
                objeto = (T)ser.Deserialize(fileStream);
                return true;
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
