using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TP4;

namespace DAOs
{
    public class RemeraDAO : IDao<Producto,string>
    {
        private SqlConnection sqlConnection;

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de DataAccessObject de Remera
        /// </summary>
        public RemeraDAO()
        {
            string connectionString = "Server=.;Database=TP4;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connectionString);
        }
        #endregion

        #region METODOS       
        /// <summary>
        /// Trae todos los datos de la DB tp4, en la tabla remeras, para popular el catalogo
        /// </summary>
        /// <param name="producto">Lista de productos donde esta todo el catalogo</param>
        /// <returns></returns>
        public bool TraerDatosDeDB(List<Producto> producto)
        {
            bool retorno = false;
            try
            {
                producto.Clear();
                SqlCommand consulta = new SqlCommand();
                consulta.CommandType = System.Data.CommandType.Text;
                consulta.Connection = this.sqlConnection;
                consulta.CommandText = "SELECT * FROM Remeras";
                this.sqlConnection.Open();
                SqlDataReader dr = consulta.ExecuteReader();

                while (dr.Read())
                {
                    producto.Add(new Remera(dr["sku"].ToString(), dr["nombre"].ToString(), Convert.ToSingle(dr["precio"]), dr["ubicacionEstampa"].ToString()));
                }

                retorno = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection != null &&
                    sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que borra filas de la tabla REMERAS con convinacion de dato y columna (asi es un poco mas generico)
        /// </summary>
        /// <param name="lista">Lista de strings a borrar por ejemplo string de IDs</param>
        /// <param name="columna">Columna que matchea con los strings a borrar por ejemplo ID</param>
        /// <returns></returns>
        public bool BorrarRowsDB(List<string> lista, string columna)
        {
            bool retorno = false;

            if (!(lista is null))
            {
                foreach (string item in lista)
                {
                    try
                    {
                        string consulta = $"DELETE FROM Remeras WHERE " + columna + " = @item;";
                        SqlCommand sqlCommand = new SqlCommand(consulta, this.sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@item", item);

                        this.sqlConnection.Open();
                        int filas = sqlCommand.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            retorno = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (sqlConnection != null &&
                        sqlConnection.State == System.Data.ConnectionState.Open)
                        {
                            this.sqlConnection.Close();
                        }
                    }

                }
            }
            return retorno;
        }

        /// <summary>
        /// Borra un row recibiendo una remera (lo hace por el SKU, pq no puse el ID como atributo de remera)
        /// </summary>
        /// <param name="remera">Remera a borrar de la DB</param>
        /// <returns></returns>
        public bool BorrarRowPorRemera(Remera remera)
        {
            bool retorno = false;
            if (!(remera is null))
            {
                this.BorrarRowsDB(new List<string> { remera.Sku }, "Sku");
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Agrega una remera a la db
        /// </summary>
        /// <param name="remera">Remera</param>
        /// <returns></returns>
        public bool AgregarRemera(Remera remera)
        {
            bool retorno = false;

            try
            {
                string command = "INSERT INTO Cuadros(sku, nombre, ubicacionArte, precio) " +
                    "VALUES(@sku, @nombre, @ubicacionEstampa, @precio)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("sku", remera.Sku);
                sqlCommand.Parameters.AddWithValue("nombre", remera.Nombre);
                sqlCommand.Parameters.AddWithValue("ubicacionEstampa", remera.UbicacionEstampa);
                sqlCommand.Parameters.AddWithValue("precio", remera.Precio);


                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection != null &&
                    sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }

            return retorno;
        } 
        #endregion
    }
}
