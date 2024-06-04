using Models;

namespace ASP.Models
{
    public class clsPersonaDepartamentoCheck: clsPersonaDepartamento
    {
        private bool isChecked = false;

        public bool IsChecked
        {
            get => isChecked;
            set => isChecked = value;
        }

        public clsPersonaDepartamentoCheck(clsPersonaDepartamento persona): base(persona)
        { }
    }
}