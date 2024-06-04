using ASP.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CambioDepartamento(int idDepartamentoSeleccionado, bool isChecked)
        {
            List<clsPersonaDepartamento> listadoPersonasSeleccionadas = new List<clsPersonaDepartamento>();
            //TODO
            return View();
        }

    }
}