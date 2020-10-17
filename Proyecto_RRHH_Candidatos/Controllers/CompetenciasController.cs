using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH_Candidatos.Services;
using Proyecto_RRHH_Candidatos.Models;
namespace Proyecto_RRHH_Candidatos.Controllers
{
    public class CompetenciasController : Controller
    {
        Servicios_Competencias sv = new Servicios_Competencias();
        Servicios_NivelHabilidad svn = new Servicios_NivelHabilidad();
        public IActionResult Edit(int id)
        {
            ViewBag.niveles = svn.consultaGeneral();
            var Model = sv.ConsultarPorCodigo(id); 
            return View(Model);
        }
        [HttpPost]
        public IActionResult Edit(Competencias competencias)
        {
            sv.Actualizar(competencias);
            int? id =sv.identificarCandidato(competencias.Id);
            return RedirectToAction("Index", "Home", new { id = id});
        }
        public IActionResult Create(int idCandidato)
        {
            ViewBag.niveles = svn.consultaGeneral();
            ViewBag.idCandidato = idCandidato;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Competencias competencias, int idCandidato)
        {
            sv.Nuevo(competencias, idCandidato);
            return RedirectToAction("Index", "Home", new { id = idCandidato });
        }
    }
}
