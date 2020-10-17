using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH_Candidatos.Models;
using Proyecto_RRHH_Candidatos.Services;

namespace Proyecto_RRHH_Candidatos.Controllers
{
    public class IdiomasController : Controller
    {
        Servicios_Idiomas sv = new Servicios_Idiomas();
        Servicios_NivelHabilidad svn = new Servicios_NivelHabilidad();
        public IActionResult Edit(int id)
        {
            ViewBag.niveles = svn.consultaGeneral();
            var Model = sv.ConsultarPorCodigo(id);
            return View(Model);
        }
        [HttpPost]
        public IActionResult Edit(Idiomas idiomas)
        {
            sv.Actualizar(idiomas);
            int? id = sv.identificarCandidato(idiomas.Id);
            return RedirectToAction("Index", "Home", new { id = id });
        }
        public IActionResult Create(int idCandidato)
        {
            ViewBag.niveles = svn.consultaGeneral();
            ViewBag.idCandidato = idCandidato;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Idiomas idiomas, int idCandidato)
        {
            sv.Nuevo(idiomas, idCandidato);
            return RedirectToAction("Index", "Home", new { id = idCandidato });
        }
    }
}
