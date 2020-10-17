using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Candidatos.Models;

namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicios_Candidatos
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();
       
        public List<IdiomasCandidatos> ConsultaIdiomas(int? id)
        {
            return DB.IdiomasCandidatos.Include("CandidatoNavigation")
                           .Include(x => x.IdiomasNavigation)
                                .ThenInclude(x => x.NivelNavigation)
                                .Where(x => x.Candidato == id).ToList();
        }

        public List<CandidatoCompetencias> CandidatoCompetencias(int? id)
        {
            return DB.CandidatoCompetencias.Include("CandidatoNavigation")
                                       .Include(x => x.CompetenciaNavigation)
                                            .ThenInclude(x => x.NivelNavigation)
                                            .Where(x => x.Candidato == id).ToList();
        }

        public Candidatos ConsultaPorCodigo(int? id)
        {
            return DB.Candidatos.FirstOrDefault(x => x.Id == id);
        }

        public void ActualizacionVacantes(int id, int vacante)
        {
            Candidatos nam = ConsultaPorCodigo(id);
            nam.AspiracionPuesto = vacante;
            DB.Entry(nam).State = EntityState.Modified;
            DB.SaveChanges();
        }
        public List<Capacitaciones> CandidatoCapacitaciones(int? id)
        {
            return DB.Capacitaciones.Include("NivelNavigation")
                                    .Where(x => x.Candidato == id).ToList();
        }
        public List<ExperienciaLaboral> CandidatoExperiencia(int? id)
        {
            return DB.ExperienciaLaboral.Where(x => x.Candidato == id).ToList();
        }

    }
}
