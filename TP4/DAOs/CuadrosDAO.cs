using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4;
using TpExceptions;
using System.Data.SqlClient;

namespace DAOs
{
    public class CuadrosDAO : IDao<Producto,string>
    {
        private SqlConnection sqlConnection;

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor del DAO para los cuadros
        /// </summary>
        public CuadrosDAO()
        {
            string connectionString = "Server=.;Database=TP4;Trusted_Connection=True;";
            this.sqlConnection = new SqlConnection(connectionString);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Trae todos los cuadros de la base datos para el catalogo
        /// </summary>
        /// <param name="productos">Donde va a dejar los productos</param>
        /// <returns></returns>
        public bool TraerDatosDeDB(List<Producto> productos)
        {
            bool retorno = false;

            try
            {
                productos.Clear();
                SqlCommand consulta = new SqlCommand();
                consulta.CommandType = System.Data.CommandType.Text;
                consulta.Connection = this.sqlConnection;
                consulta.CommandText = "SELECT * FROM Cuadros";
                this.sqlConnection.Open();
                SqlDataReader dr = consulta.ExecuteReader();

                while (dr.Read())
                {
                    productos.Add(new Cuadro(dr["sku"].ToString(), dr["nombre"].ToString(), Convert.ToSingle(dr["precio"]), dr["ubicacionArte"].ToString(), dr["tamano"].ToString()));
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
        /// Borra una o mas lineas dependiendo de lo que contenga la lista de string en la columna
        /// </summary>
        /// <param name="lista">Lista de strings a borrar por ej ids</param>
        /// <param name="columna">Columna</param>
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
                        string consulta = $"DELETE FROM Cuadros WHERE " + columna + " = @item;";
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
        /// Borra un cuadro de la db
        /// </summary>
        /// <param name="cuadro">Cuadro a borrar</param>
        /// <returns></returns>
        public bool BorrarRowPorCuadro(Cuadro cuadro)
        {
            bool retorno = false;
            if (!(cuadro is null))
            {
                this.BorrarRowsDB(new List<string> { cuadro.Sku }, "Sku");
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Agrega un cuadro a la db
        /// </summary>
        /// <param name="cuadro"></param>
        /// <returns></returns>
        public bool AgregarCuadro(Cuadro cuadro)
        {
            bool retorno = false;

            try
            {
                string command = "INSERT INTO Cuadros(sku, nombre, ubicacionArte, precio, tamano) " +
                    "VALUES(@sku, @nombre, @ubicacionArte, @precio, @tamano)";

                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("sku", cuadro.Sku);
                sqlCommand.Parameters.AddWithValue("nombre", cuadro.Nombre);
                sqlCommand.Parameters.AddWithValue("ubicacionArte", cuadro.UbicacionArte);
                sqlCommand.Parameters.AddWithValue("precio", cuadro.Precio);
                sqlCommand.Parameters.AddWithValue("tamano", cuadro.Tamano);

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
