using ASP.Models;
using Microsoft.AspNetCore.Mvc;

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
                return View("ErrorGet");
            }
            return View(modelo);
        }
    }
}