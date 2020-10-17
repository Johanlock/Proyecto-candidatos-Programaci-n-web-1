using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH_Candidatos.Models;
using Proyecto_RRHH_Candidatos.Services;

namespace Proyecto_RRHH_Candidatos.Controllers
{
    public class AuthenticationController : Controller
    {
        Servicio_Usuarios sv = new Servicio_Usuarios();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuarios user)
        {
            if (sv.ValidacionUsuario(user))
            {
                int? candidato = sv.ConsultarCandidato(user.Usuario);
                return RedirectToAction("Index", "Home", new { id = candidato});
            }
            return View();
        }
    }
}
