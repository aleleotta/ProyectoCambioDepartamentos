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
            }
        }
        public clsDepartamento DepartamentoSeleccionado
        {
            set
            {
                if (value != null) departamentoSeleccionado = value;
            }
        }
        public DelegateCommand Submit
        {
            get => submit;
        }
        #endregion

        #region Command Executers
        /// <summary>
        /// Comprueba diferentes condiciones para ver si el viewmodel tiene ambos el listado parcial de personas y el departamento que hay que cambiar.
        /// Si el metodo tiene todo lo que necesita, empieza a cambiar el ID de departamento de todas las personas seleccionadas y hace un intento
        /// para subir todas las personas a la base de datos con los datos actualizados.
        /// Al final la funcion que se llama desde la BL devuelve un resultado de tipo string y se muestra en el DisplayAlert para el usuario.
        /// </summary>
        private async void submit_execute()
        {
            //Objects to use: listadoPersonasSeleccionadas, departamentoSeleccionado
            string result;
            if (!listadoPersonasSeleccionadas.IsNullOrEmpty() && departamentoSeleccionado != null)
            {
                List<clsPersona> listadoPersonasCambiadas = new List<clsPersona>();
                foreach (clsPersonaDepartamento persona in listadoPersonasSeleccionadas)
                {
                    //Se cambia IdDept por el ID del departamento seleccionado.
                    clsPersona persona1 = new clsPersona(persona.Id, persona.Nombre, persona.Apellidos, departamentoSeleccionado.Id);
                    listadoPersonasCambiadas.Add(persona1);
                }
                try
                {
                    result = clsUpdateBL.updateListadoPersonas(listadoPersonasCambiadas);
                }
                catch
                {
                    result = "No se pudieron aplicar los cambios.";
                }
                await Application.Current.MainPage.DisplayAlert("Alerta", result, "Ok");
                llenarListadoPersonas();
                llenarListadoPersonasConDepartamento();
                OnPropertyChanged("ListadoPersonas");
                OnPropertyChanged("ListadoPersonasConDepartamento");
            }
            else if (listadoPersonasSeleccionadas.IsNullOrEmpty() && departamentoSeleccionado != null)
            {
                result = "Ninguna persona fue seleccionada.";
                await Application.Current.MainPage.DisplayAlert("Error", result, "Ok");
            }
            else if (!listadoPersonasSeleccionadas.IsNullOrEmpty() && departamentoSeleccionado == null)
            {
                result = "Ningun departamento fue seleccionado.";
                await Application.Current.MainPage.DisplayAlert("Error", result, "Ok");
            }
            else
            {
                result = "Ninguna persona ni departamento fueron seleccionados.";
                await Application.Current.MainPage.DisplayAlert("Error", result, "Ok");
            }
        }
        #endregion

        #region Constructors
        public MainVM()
        {
            llenarListadoPersonas();
            llenarListadoDepartamentos();
            llenarListadoPersonasConDepartamento();
            listadoPersonasSeleccionadas = new ObservableCollection<object>();
            submit = new DelegateCommand(submit_execute);
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