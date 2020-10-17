using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_RH__Servicios_.Services;
using Proyecto_RRHH_Candidatos.Services;

namespace Proyecto_RH.Controllers
{
    public class VacantesController : Controller
    {
        Servicios_Candidatos svc = new Servicios_Candidatos();
        Servicios_Vacantes sv = new Servicios_Vacantes();
        [HttpGet]
        public IActionResult Index()
        {
            var Model = sv.ConsultaGeneral();
            return View(Model);
        }

        public IActionResult Aplicar(int id)
        {
            svc.ActualizacionVacantes(2, id);
            var Model = sv.ConsultaPorCodigo(id);
            return View(Model);
        }
    }
}
