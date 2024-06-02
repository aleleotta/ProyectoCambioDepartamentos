using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Entities;
using BL;

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
            return View();
        }
    }
}