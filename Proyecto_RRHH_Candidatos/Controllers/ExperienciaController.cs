using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH_Candidatos.Services;
using Proyecto_RRHH_Candidatos.Models;

namespace Proyecto_RRHH_Candidatos.Controllers
{
    public class ExperienciaController : Controller
    {
        Servicios_Experiencias sv = new Servicios_Experiencias();
        public IActionResult Edit(int id)
        {
            var Model = sv.ConsultaPorCodigo(id);
            return View(Model);
        }

        [HttpPost]
        public IActionResult Edit(ExperienciaLaboral experienciaLaboral)
        {
            int? id = experienciaLaboral.Candidato;
            sv.Actualizar(experienciaLaboral);
            return RedirectToAction("Index", "Home", new { id = id });
        }


        public IActionResult Create(int idCandidato)
        {
            ViewBag.idCandidato = idCandidato;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExperienciaLaboral experiencia, int idCandidato)
        {
            sv.Nuevo(experiencia, idCandidato);
            return RedirectToAction("Index", "Home", new { id = idCandidato });
        }
    }
}
