using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Candidatos.Models;
namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicios_Competencias
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();
        public void Actualizar(Competencias competencias)
        {
            DB.Entry(competencias).State = EntityState.Modified;
            DB.SaveChanges();
        }
        public void Eliminar(Competencias competencias)
        {
            DB.Remove(competencias);
            DB.SaveChanges();
        }
        public void Nuevo(Competencias id, int idcandidato)
        {
            id.Id = NuevoCodigo();
            DB.Competencias.Add(id);
            DB.SaveChanges();
            NuevoCandidatoCompetencias(id.Id, idcandidato);
        }
        public void NuevoCandidatoCompetencias(int competencia, int candidato)
        {
            CandidatoCompetencias cand = new CandidatoCompetencias()
            {
                Id = nuevoCodigoCandidatoCompetencias(),
                Candidato = candidato,
                Competencia = competencia

            };
            DB.CandidatoCompetencias.Add(cand);
            DB.SaveChanges();
        }

        private int nuevoCodigoCandidatoCompetencias()
        {
            if (DB.CandidatoCompetencias.ToList().Count >= 1)
            {
                return DB.CandidatoCompetencias.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return 1;
        }
        public int NuevoCodigo()
        {
            if(DB.Competencias.ToList().Count >= 1)
            {
                return DB.Competencias.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return 1;
        }

        public Competencias ConsultarPorCodigo(int id)
        {
            return DB.Competencias.FirstOrDefault(x => x.Id == id);
        }
        public int? identificarCandidato(int id)
        {
            return DB.CandidatoCompetencias.FirstOrDefault(x => x.Competencia == id).Candidato;
        }
    }
}
