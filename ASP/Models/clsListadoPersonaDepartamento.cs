using BL;
using Entities;
using Models;

namespace ASP.Models
{
    public class clsListadoPersonaDepartamento
    {
        private List<clsPersona> listadoPersonas;
        private List<clsDepartamento> listadoDepartamentos;
        private List<clsPersonaDepartamento> listadoPersonasConDepartamento;

        public List<clsDepartamento> ListadoDepartamentos { get => listadoDepartamentos; }
        public List<clsPersonaDepartamento> ListadoPersonasConDepartamento { get => listadoPersonasConDepartamento; }

        public clsListadoPersonaDepartamento()
        {
            llamarBD();
        }

        /// <summary>
        /// Hace 2 llamadas a la base de datos para rellenar los listados de personas y departamentos
        /// y luego los junta en un nuevo listado que usa el modelo clsPersonaDepartamento.
        /// </summary>
        private void llamarBD()
        {
            listadoPersonas = new List<clsPersona>(clsGetBL.getListadoPersonas());
            listadoDepartamentos = new List<clsDepartamento>(clsGetBL.getListadoDepartamentos());
            listadoPersonasConDepartamento = new List<clsPersonaDepartamento>();
            foreach (clsPersona persona in listadoPersonas)
            {
                var dept = listadoDepartamentos.FirstOrDefault(dept => dept.Id == persona.IdDept);
                if (dept != null)
                {
                    clsPersonaDepartamento personaConDepartamento = new clsPersonaDepartamento(persona, dept);
                    listadoPersonasConDepartamento.Add(personaConDepartamento);
                }
            }
        }
    }
}
