using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_RRHH_Candidatos.Models;
using Proyecto_RRHH_Candidatos.Services;

namespace Proyecto_RRHH_Candidatos.Controllers
{
    public class HomeController : Controller
    {
        Servicios_Candidatos sv = new Servicios_Candidatos();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.idiomas = sv.ConsultaIdiomas(id);
            ViewBag.experiencias = sv.CandidatoExperiencia(id);
            ViewBag.competencias = sv.CandidatoCompetencias(id);
            ViewBag.capacitaciones = sv.CandidatoCapacitaciones(id);

            var Model = sv.ConsultaPorCodigo(id);
            return View(Model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
