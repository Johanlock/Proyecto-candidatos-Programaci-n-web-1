using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_RRHH_Candidatos.Models;

namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicio_Usuarios
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();
        public bool ValidacionUsuario(Usuarios user)
        {
            return DB.Usuarios.FirstOrDefault(x => x.Usuario == user.Usuario && x.Contrasena == user.Contrasena) != null ? true : false;
        }

        public int? ConsultarCandidato(string usuario)
        {
            return DB.Usuarios.FirstOrDefault(x => x.Usuario == usuario).Candidato;
        }
    }
}
