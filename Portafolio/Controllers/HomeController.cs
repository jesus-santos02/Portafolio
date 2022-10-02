using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;
using System.IO;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyecto;
        private readonly IServicioEmail servicioEmail;

        public HomeController(IRepositorioProyectos repositorioProyecto, IServicioEmail servicioEmail)
        {
            this.repositorioProyecto = repositorioProyecto;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            var proyecto = repositorioProyecto.ObtenerProyecto().Take(3).ToList();

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyecto
            };
            
            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyecto.ObtenerProyecto();

            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
            servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}