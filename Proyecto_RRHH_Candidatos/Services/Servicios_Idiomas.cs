using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Candidatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicios_Idiomas
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();
        public void Actualizar(Idiomas idiomas)
        {
            DB.Entry(idiomas).State = EntityState.Modified;
            DB.SaveChanges();
        }
        public void Eliminar(Idiomas idiomas)
        {
            DB.Remove(idiomas);
            DB.SaveChanges();
        }
        public void Nuevo(Idiomas id, int idcandidato)
        {
            id.Id = NuevoCodigo();
            id.Estado = 1;
            DB.Idiomas.Add(id);
            DB.SaveChanges();
            NuevoCandidatoCompetencias(id.Id, idcandidato);
        }
        public void NuevoCandidatoCompetencias(int idioma, int candidato)
        {
            IdiomasCandidatos cand = new IdiomasCandidatos()
            {
                Id = nuevoCodigoCandidatoIdiomas(),
                Candidato = candidato,
                Idiomas = idioma

            };
            DB.IdiomasCandidatos.Add(cand);
            DB.SaveChanges();
        }

        private int nuevoCodigoCandidatoIdiomas()
        {
            if (DB.IdiomasCandidatos.ToList().Count >= 1)
            {
                return DB.IdiomasCandidatos.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return 1;
        }
        public int NuevoCodigo()
        {
            if (DB.Idiomas.ToList().Count >= 1)
            {
                return DB.Idiomas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return 1;
        }

        public Idiomas ConsultarPorCodigo(int id)
        {
            return DB.Idiomas.FirstOrDefault(x => x.Id == id);
        }
        public int? identificarCandidato(int id)
        {
            return DB.IdiomasCandidatos.FirstOrDefault(x => x.Idiomas == id).Candidato;
        }
    }
}
