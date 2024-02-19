using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult IncrementoSalarial()
        {
            //debemos devolver los oficios
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View();
        }
        [HttpPost]
        public IActionResult IncrementoSalarial
            (int incremento, string oficio)
        {
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;

            ModelEmpleados model = 
                this.repo.IncrementarSalarioOficio(incremento, oficio);
            return View(model);
        }
    }
}
