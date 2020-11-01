using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region METODOS
        /// <summary>
        /// Garda un string en un archivo de texto
        /// </summary>
        /// <param name="archivo">string con el nombre del archivo</param>
        /// <param name="datos">string a guardar</param>
        /// <returns>True si se pudo guardar</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo, false);
            try
            {
                sw.WriteLine(datos);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();
            }
        }

        /// <summary>
        /// Lee y guarda en una variable un archivo de texto
        /// </summary>
        /// <param name="archivo">string con archivo a leer</param>
        /// <param name="datos">string donde deja lo guardado</param>
        /// <returns>True si se pudo guardar</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sw = new StreamReader(archivo);
            try
            {
                datos = sw.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();
            }
        } 
        #endregion
    }
}
