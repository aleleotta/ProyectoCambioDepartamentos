using Entities;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsUpdateDAL
    {
        /// <summary>
        /// Actualiza todas las personas que tienen el departamento cambiado en la base de datos.
        /// </summary>
        /// <param name="listadoPersonasConCambio">El listado de personas con los departamentos cambiados</param>
        public static string updateListadoPersonas(List<clsPersona> listadoPersonasConCambio)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = clsConnection.getConnection();
            SqlCommand cmd;
            string result = "";
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.Connection = conn;
                //@idDept y @id se especificaran adentro de un bucle. El listado pasado por parametro no es completo.
                cmd.CommandText = "UPDATE Personas SET IDDepartamento = @idDept WHERE ID = @id";
                foreach (clsPersona persona in listadoPersonasConCambio)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", persona.Id);
                    cmd.Parameters.AddWithValue("@idDept", persona.IdDept);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                conn.Dispose();
                result = "Operacion terminada correctamente.";
            }
            catch (Exception)
            {
                result = "No se pudieron aplicar los cambios.";
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }
    }
}
