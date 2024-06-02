using DAL;
using Entities;

namespace BL
{
    public class clsGetBL
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
                listadoPersonas = new List<clsPersona>(clsGetDAL.getListadoCompletoPersonas());
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
                listadoDepartamentos = new List<clsDepartamento>(clsGetDAL.getListadoCompletoDepartamentos());
            }
            catch
            {
                listadoDepartamentos = new List<clsDepartamento>();
            }
            return listadoDepartamentos;
        }
    }
}