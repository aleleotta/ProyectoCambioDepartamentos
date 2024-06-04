using Entities;

namespace Models
{
    public class clsPersonaDepartamento: clsPersona
    {
        private clsDepartamento departamentoAsignado; //Por defecto tendra el departamento ya asignado por la base de datos.

        public clsDepartamento DepartamentoAsignado
        {
            get => departamentoAsignado;
            set
            {
                if (value != null) departamentoAsignado = value;
            }
        }

        public clsPersonaDepartamento(clsPersona persona, clsDepartamento departamentoAsignado): base(persona)
        {
            this.departamentoAsignado = new clsDepartamento(departamentoAsignado);
        }

        public clsPersonaDepartamento(clsPersonaDepartamento persona): base(persona)
        {
            departamentoAsignado = persona.DepartamentoAsignado;
        }
    }
}