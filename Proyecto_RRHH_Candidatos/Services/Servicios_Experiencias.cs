using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Candidatos.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicios_Experiencias
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public ExperienciaLaboral ConsultaPorCodigo(int id)
        {
            return DB.ExperienciaLaboral.FirstOrDefault(x => x.Id == id);
        }

        public void Actualizar(ExperienciaLaboral experienciaLaboral)
        {
            DB.Entry(experienciaLaboral).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public void Nuevo(ExperienciaLaboral experiencias, int idCandidato)
        {
            experiencias.Candidato = idCandidato;
            experiencias.Id = NuevoCodigo();
            DB.ExperienciaLaboral.Add(experiencias);

            DB.SaveChanges();
        }
        public int NuevoCodigo()
        {
            if (DB.ExperienciaLaboral.ToList().Count >= 1)
            {
                return DB.ExperienciaLaboral.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return 1;
        }
    }
}
