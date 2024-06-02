using Entities;

namespace Models
{
    public class clsPersonaDepartamento: clsPersona
    {
        private clsDepartamento departamentoAsignado; //Por defecto tendra el departamento ya asignado por la base de datos.

        public clsDepartamento DepartamentoSeleccionado
        {
            get => departamentoAsignado;
            set
            {
                if (value != null) departamentoAsignado = value;
            }
        }

        public clsPersonaDepartamento(clsPersona persona, clsDepartamento departamentoSeleccionado): base(persona)
        {
            this.departamentoAsignado = new clsDepartamento(departamentoSeleccionado);
        }
    }
}