using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using BL;
using Entities;
using MAUI.Models;
using MAUI.Utilities;

namespace MAUI.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        #region Attributes
        private List<clsPersona> listadoPersonas;
        private List<clsDepartamento> listadoDepartamentos;
        private ObservableCollection<clsPersonaDepartamento> listadoPersonasConDepartamento;
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
        public DelegateCommand Submit
        {
            get => submit;
        }
        #endregion

        #region Command Executers
        private void submit_execute()
        {
            //TODO
        }
        private bool submit_canExecute()
        {
            return true;
        }
        #endregion

        #region Constructors
        public MainVM()
        {
            llenarListadoPersonas();
            llenarListadoDepartamentos();
            llenarListadoPersonasConDepartamento();
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
                listadoPersonas = new List<clsPersona>(clsListadosBL.getListadoPersonas());
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
                listadoDepartamentos = new List<clsDepartamento>(clsListadosBL.getListadoDepartamentos());
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