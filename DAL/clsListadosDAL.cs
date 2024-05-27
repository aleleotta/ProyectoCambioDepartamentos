using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class clsListadosDAL
    {
        public List<clsPersona> getListadoCompletoPersonas()
        {
            return new List<clsPersona>();
        }
        public List<clsDepartamento> getListadoCompletoDepartamentos()
        {
            return new List<clsDepartamento>();
        }
        public void updateListadoPersonas(List<clsPersona> listadoPersonasConCambio) { }
    }
}
