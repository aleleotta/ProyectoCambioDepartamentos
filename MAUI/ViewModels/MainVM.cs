using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BL;
using Entities;
using Models;
using MAUI.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace MAUI.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        #region Attributes
        private List<clsPersona> listadoPersonas;
        private List<clsDepartamento> listadoDepartamentos;
        private ObservableCollection<clsPersonaDepartamento> listadoPersonasConDepartamento;
        private ObservableCollection<object> listadoPersonasSeleccionadas;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand submit;
        #endregion

        #region Properties
        public List<clsPersona> ListadoPersonas
        {
            get => listadoPersonas;
        }
        public List<clsDepartamento> ListadoDepartamentos
        {
            get => listadoDepartamentos;
        }
        public ObservableCollection<clsPersonaDepartamento> ListadoPersonasConDepartamento
        {
            get => listadoPersonasConDepartamento;
        }
        public ObservableCollection<object> ListadoPersonasSeleccionadas
        {
            get => listadoPersonasSeleccionadas;
            set
            {
                listadoPersonasSeleccionadas = value;
                submit.RaiseCanExecuteChanged();
            }
        }
        public clsDepartamento DepartamentoSeleccionado
        {
            set
            {
                if (value != null) departamentoSeleccionado = value;
                submit.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand Submit
        {
            get => submit;
        }
        #endregion

        #region Command Executers
        private async void submit_execute()
        {
            //Objects to use: listadoPersonasSeleccionadas, departamentoSeleccionado
            List<clsPersona> listadoPersonasCambiadas = new List<clsPersona>();
            foreach (clsPersonaDepartamento persona in listadoPersonasSeleccionadas)
            {
                //Se cambia IdDept por el ID del departamento seleccionado.
                clsPersona persona1 = new clsPersona(persona.Id, persona.Nombre, persona.Apellidos, departamentoSeleccionado.Id);
                listadoPersonasCambiadas.Add(persona1);
            }
            string result = clsUpdateBL.updateListadoPersonas(listadoPersonasCambiadas);
            await Application.Current.MainPage.DisplayAlert("Alerta", result, "Ok");
            llenarListadoPersonas();
            llenarListadoPersonasConDepartamento();
            OnPropertyChanged("ListadoPersonas");
            OnPropertyChanged("ListadoPersonasConDepartamento");
        }
        private bool submit_canExecute()
        {
            if (departamentoSeleccionado == null || listadoPersonasSeleccionadas.IsNullOrEmpty()) return false;
            else return true;
        }
        #endregion

        #region Constructors
        public MainVM()
        {
            llenarListadoPersonas();
            llenarListadoDepartamentos();
            llenarListadoPersonasConDepartamento();
            listadoPersonasSeleccionadas = new ObservableCollection<object>();
            submit = new DelegateCommand(submit_execute, submit_canExecute);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Rellena el listado de personas llamando a la base de datos.
        /// </summary>
        private void llenarListadoPersonas()
        {
            try
            {
                listadoPersonas = new List<clsPersona>(clsGetBL.getListadoPersonas());
            }
            catch
            {
                listadoPersonas = new List<clsPersona>();
            }
        }

        /// <summary>
        /// Rellena el listado de departamentos llamando a la base de datos.
        /// </summary>
        private void llenarListadoDepartamentos()
        {
            try
            {
                listadoDepartamentos = new List<clsDepartamento>(clsGetBL.getListadoDepartamentos());
            }
            catch
            {
                listadoDepartamentos = new List<clsDepartamento>();
            }
        }

        /// <summary>
        /// Une los dos listados (personas y departamentos) ya rellenados.
        /// </summary>
        private void llenarListadoPersonasConDepartamento()
        {
            listadoPersonasConDepartamento = new ObservableCollection<clsPersonaDepartamento>();
            foreach (clsPersona persona in listadoPersonas)
            {
                clsDepartamento dept = listadoDepartamentos.FirstOrDefault(dept => dept.Id == persona.IdDept);
                if (dept != null)
                {
                    clsPersonaDepartamento personaConDepartamento = new clsPersonaDepartamento(persona, dept);
                    listadoPersonasConDepartamento.Add(personaConDepartamento);
                }
            }
        }
        #endregion

        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}