using Entities;

namespace Models
{
    public class clsPersonaDepartamento: clsPersona
    {
        private clsDepartamento departamentoSeleccionado; //Por defecto tendra el departamento ya asignado por la base de datos.

        public clsDepartamento DepartamentoSeleccionado
        {
            get => departamentoSeleccionado;
            set
            {
                if (value == null) departamentoSeleccionado = value;
            }
        }

        public clsPersonaDepartamento(clsPersona persona, clsDepartamento departamentoSeleccionado): base(persona)
        {
            this.departamentoSeleccionado = new clsDepartamento(departamentoSeleccionado);
        }
    }
}