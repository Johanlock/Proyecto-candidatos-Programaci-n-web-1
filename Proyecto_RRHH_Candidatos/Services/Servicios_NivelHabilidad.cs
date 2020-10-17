using Proyecto_RRHH_Candidatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicios_NivelHabilidad
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public List<NivelesHabilidad> consultaGeneral()
        {
            return DB.NivelesHabilidad.ToList();
        }
    }
}
