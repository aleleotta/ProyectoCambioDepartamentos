using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsListadosDAL
    {
        /// <summary>
        /// Accede a la base de datos para recojer todas las personas y devolverlas como un listado.
        /// </summary>
        /// <returns>El listado de personas</returns>
        public List<clsPersona> getListadoCompletoPersonas()
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
        public List<clsDepartamento> getListadoCompletoDepartamentos()
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

        /// <summary>
        /// Actualiza todas las personas que tienen el departamento cambiado en la base de datos.
        /// </summary>
        /// <param name="listadoPersonasConCambio">El listado de personas con los departamentos cambiados</param>
        public void updateListadoPersonas(List<clsPersona> listadoPersonasConCambio)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = clsConnection.getConnection();
            SqlCommand cmd;
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Personas SET IDDepartamento = @idDept WHERE ID != @id"; //@idDept y @id se especificaran adentro de un bucle. El listado pasado por parametro no es completo.
                foreach (clsPersona persona in listadoPersonasConCambio)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", persona.Id);
                    cmd.Parameters.AddWithValue("@idDept", persona.IdDept);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
