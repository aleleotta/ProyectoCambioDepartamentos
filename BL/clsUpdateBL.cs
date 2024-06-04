using DAL;
using Entities;
using Microsoft.Data.SqlClient;

namespace BL
{
    public class clsUpdateBL
    {
        /// <summary>
        /// Comprueba si el dia corriente no es Domingo y si devuelve true se manda el listado parcial de personas a la capa DAL.
        /// Precondicion: Los Domingos no se puede actualizar.
        /// </summary>
        /// <param name="listadoPersonasConCambio">El listado parcial de personas</param>
        public static string updateListadoPersonas(List<clsPersona> listadoPersonasConCambio)
        {
            string result;
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                result = clsUpdateDAL.updateListadoPersonas(listadoPersonasConCambio);
            }
            else
            {
                result = "No se pueden cambiar los departamentos durante un Domingo.";
            }
            return result;
        }
    }
}