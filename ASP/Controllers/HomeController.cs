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

        [HttpPost]
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