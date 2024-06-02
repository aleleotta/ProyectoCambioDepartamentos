using Entities;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsGetDAL
    {
        /// <summary>
        /// Accede a la base de datos para recojer todas las personas y devolverlas como un listado.
        /// </summary>
        /// <returns>El listado de personas</returns>
        public static List<clsPersona> getListadoCompletoPersonas()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = clsConnection.getConnection();
            SqlCommand cmd;
            SqlDataReader reader;
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Personas";
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clsPersona persona = new clsPersona((int)reader["ID"], (string)reader["Nombre"], (string)reader["Apellidos"], (int)reader["IDDepartamento"]);
                        listadoPersonas.Add(persona);
                    }
                }
                conn.Close();
            }
            catch (Exception err)
            {
                listadoPersonas = new List<clsPersona>();
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return listadoPersonas;
        }

        /// <summary>
        /// Accede a la base de datos para recojer todos los departamentos y devolverlos como un listado.
        /// </summary>
        /// <returns>El listado de departamentos</returns>
        public static List<clsDepartamento> getListadoCompletoDepartamentos()
        {
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = clsConnection.getConnection();
            SqlCommand cmd;
            SqlDataReader reader;
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Departamentos";
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clsDepartamento dept = new clsDepartamento((int)reader["ID"], (string)reader["Nombre"]);
                        listadoDepartamentos.Add(dept);
                    }
                }
                conn.Close();
            }
            catch (Exception err)
            {
                listadoDepartamentos = new List<clsDepartamento>();
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return listadoDepartamentos;
        }
    }
}