using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BL;
using Entities;
using MAUI.Models;
using MAUI.Utilities;

namespace MAUI.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        #region Attributes
        private ObservableCollection<clsPersona> listadoPersonas;
        private ObservableCollection<clsDepartamento> listadoDepartamentos;
        private ObservableCollection<clsPersonaDepartamento> listadoPersonasConDepartamento;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand submit;
        #endregion

        #region Properties
        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get => listadoPersonas;
        }
        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get => listadoDepartamentos;
        }
        public ObservableCollection<clsPersonaDepartamento> ListadoPersonasConDepartamento
        {
            get => listadoPersonasConDepartamento;
        }
        public clsDepartamento DepartamentoSeleccionado
        {
            get => departamentoSeleccionado;
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

        #region Constructors
        public MainVM()
        {
            llenarListadoPersonas();
            llenarListadoDepartamentos();
            //TODO
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
                listadoPersonas = new ObservableCollection<clsPersona>(clsListadosBL.getListadoPersonas());
            }
            catch
            {
                listadoPersonas = new ObservableCollection<clsPersona>();
            }
        }

        /// <summary>
        /// Rellena el listado de departamentos llamando a la base de datos.
        /// </summary>
        private void llenarListadoDepartamentos()
        {
            try
            {
                listadoDepartamentos = new ObservableCollection<clsDepartamento>(clsListadosBL.getListadoDepartamentos());
            }
            catch
            {
                listadoDepartamentos = new ObservableCollection<clsDepartamento>();
            }
        }

        /// <summary>
        /// Une los dos listados (personas y departamentos) ya rellenados.
        /// </summary>
        private void llenarListadoPersonasConDepartamento()
        {

        }
        #endregion

        #region ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}