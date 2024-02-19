using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<HospitalEF> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int idhospital)
        {
            HospitalEF hospital = this.repo.FindHospital(idhospital);
            return View(hospital);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(HospitalEF hospital)
        {
            this.repo.InsertarHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(int idhospital)
        {
            HospitalEF hospital = this.repo.FindHospital(idhospital);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Modificar(HospitalEF hospital)
        {
            this.repo.ModificarHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int idhospital)
        {
            this.repo.DeleteHospital(idhospital);
            return RedirectToAction("Index");
        }
    }
}
