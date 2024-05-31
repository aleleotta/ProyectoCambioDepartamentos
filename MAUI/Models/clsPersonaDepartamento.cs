using Entities;

namespace MAUI.Models
{
    public class clsPersonaDepartamento: clsPersona
    {
        private clsDepartamento departamento;

        public clsDepartamento Departamento
        {
            get => departamento;
            set
            {
                if (value == null) departamento = value;
            }
        }

        public clsPersonaDepartamento() { }
        public clsPersonaDepartamento(clsDepartamento departamento)
        {
            this.departamento = new clsDepartamento(departamento);
        }
    }
}