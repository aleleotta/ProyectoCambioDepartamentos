using ASP.Models;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Crea una nueva istancia del modelo que contiene todos los listados
        /// y se manda a la vista del cambio de departamentos.
        /// </summary>
        /// <returns>La vista con el modelo mandado.</returns>
        public IActionResult CambioDepartamento()
        {
            clsListadoPersonaDepartamento modelo;
            try
            {
                modelo = new clsListadoPersonaDepartamento();
            }
            catch
            {
                return View("Results/ErrorGet");
            }
            return View(modelo);
        }

        /// <summary>
        /// Coge los datos de los names como parametros y empieza a crear el listado de personas cambiadas con la clase clsPersona
        /// y luego lo manda a la base de datos.
        /// Por cada caso se devuelve una pagina de error o exito.
        /// </summary>
        /// <param name="idDepartamentoSeleccionado">El id de departamento que se usara para cambiar de departamento a las personas seleccionadas.</param>
        /// <param name="idPersonaSeleccionada">El listado de idPersona que se coge a traves de los CheckBoxes.</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ActualizarPersonasConDepartamento")]
        public IActionResult CambioDepartamento(int idDepartamentoSeleccionado, List<int> idPersonaSeleccionada)
        {
            if (idDepartamentoSeleccionado > 0 && !idPersonaSeleccionada.IsNullOrEmpty())
            {
                List<clsPersona> listadoPersonasSeleccionadas = new List<clsPersona>();
                try
                {
                    List<clsPersona> listadoPersonas = new List<clsPersona>(clsGetBL.getListadoPersonas());
                    foreach (clsPersona persona in listadoPersonas)
                    {
                        foreach (int idPersona in idPersonaSeleccionada)
                        {
                            if (idPersona == persona.Id)
                            {
                                persona.IdDept = idDepartamentoSeleccionado;
                                listadoPersonasSeleccionadas.Add(persona);
                            }
                        }
                    }
                    try
                    {
                        clsUpdateBL.updateListadoPersonas(listadoPersonas);
                    }
                    catch
                    {
                        return View("Results/ErrorActualizacion");
                    }
                    return View("Results/ExitoActualizacion");
                }
                catch
                {
                    return View("Results/ErrorGet");
                }
            }
            else if (idDepartamentoSeleccionado > 0 && idPersonaSeleccionada.IsNullOrEmpty())
            {
                return View("Results/ErrorNingunaPersona");
            }
            else if (idDepartamentoSeleccionado == 0 && !idPersonaSeleccionada.IsNullOrEmpty())
            {
                return View("Results/ErrorNingunDepartamento");
            }
            else
            {
                return View("Results/ErrorNingunaPersonaNiDepartamento");
            }
        }

    }
}