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
        public List<clsPersona> getListadoCompletoPersonas()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = clsConnection.getConnection();
            SqlCommand cmd = null;
            try
            {

            }
            catch (Exception err)
            {
                listadoPersonas = new List<clsPersona>();
            }
            return listadoPersonas;
        }
        public List<clsDepartamento> getListadoCompletoDepartamentos()
        {
            return new List<clsDepartamento>();
        }
        public void updateListadoPersonas(List<clsPersona> listadoPersonasConCambio) { }
    }
}
