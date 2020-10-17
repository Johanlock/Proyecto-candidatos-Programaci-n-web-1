using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH_Candidatos.Models;
using Proyecto_RRHH_Candidatos.Services;

namespace Proyecto_RRHH_Candidatos.Controllers
{
    public class CapacitacionesController : Controller
    {

        Servicios_Capacitaciones sv = new Servicios_Capacitaciones();
        public IActionResult Edit(int id)
        {
            ViewBag.niveles = sv.ConsultaNiveles();
            var Model = sv.ConsultaPorCodigo(id);
            return View(Model);
        }

        [HttpPost]
        public IActionResult Edit(Capacitaciones capacitaciones)
        {
            int? id = capacitaciones.Candidato;
            sv.Actualizar(capacitaciones);
            return RedirectToAction("Index", "Home", new { id = id });
        }


        public IActionResult Create(int idCandidato)
        {
            ViewBag.niveles = sv.ConsultaNiveles();
            ViewBag.idCandidato = idCandidato;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Capacitaciones capacitaciones, int idCandidato)
        {
            sv.Nuevo(capacitaciones, idCandidato);
            return RedirectToAction("Index", "Home", new { id = idCandidato });
        }
    }
}
