using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : new()
    {
        #region METODOS
        /// <summary>
        /// Guarda un dato tipo generico T en un archivo
        /// </summary>
        /// <param name="archivo">Archivo donde guardar</param>
        /// <param name="datos">Objeto a guardar</param>
        /// <returns>True si se pudo guardar</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer;
            XmlSerializer serializador;
            writer = new XmlTextWriter(archivo, Encoding.UTF8);

            try
            {
                serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(writer, datos);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                writer.Close();
            }


        }

        /// <summary>
        /// Lee un archivo y lo guarda como dato T
        /// </summary>
        /// <param name="archivo">Archivo donde leer</param>
        /// <param name="datos">Objeto a guardar</param>
        /// <returns>True si se pudo leer</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader;
            XmlSerializer serializador;
            reader = new XmlTextReader(archivo);
            try
            {
                serializador = new XmlSerializer(typeof(T));
                datos = (T)serializador.Deserialize(reader);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }
        } 
        #endregion
    }
}
