using DAL;
using Entities;

namespace BL
{
    public class clsListadosBL
    {
        /// <summary>
        /// Devuelve un listado completo de personas.
        /// </summary>
        /// <returns>El listado completo de personas</returns>
        public static List<clsPersona> getListadoPersonas()
        {
            List<clsPersona> listadoPersonas;
            try
            {
                listadoPersonas = new List<clsPersona>(clsListadosDAL.getListadoCompletoPersonas());
            }
            catch
            {
                listadoPersonas = new List<clsPersona>();
            }
            return listadoPersonas;
        }

        /// <summary>
        /// Devuelve un listado completo de departamentos.
        /// </summary>
        /// <returns>El listado completo de departamentos</returns>
        public static List<clsDepartamento> getListadoDepartamentos()
        {
            List<clsDepartamento> listadoDepartamentos;
            try
            {
                listadoDepartamentos = new List<clsDepartamento>(clsListadosDAL.getListadoCompletoDepartamentos());
            }
            catch
            {
                listadoDepartamentos = new List<clsDepartamento>();
            }
            return listadoDepartamentos;
        }

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
                try
                {
                    clsListadosDAL.updateListadoPersonas(listadoPersonasConCambio);
                    result = "Operacion terminada correctamente.";
                }
                catch
                {
                    result = "No se pudieron aplicar los cambios.";
                }
            }
            else
            {
                result = "No se puede cambiar los departamentos durante el Domingo.";
            }
            return result;
        }
    }
}
