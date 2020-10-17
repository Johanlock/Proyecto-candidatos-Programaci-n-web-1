using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Candidatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RRHH_Candidatos.Services
{
    public class Servicios_Capacitaciones
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public Capacitaciones ConsultaPorCodigo(int id)
        {
            return DB.Capacitaciones.FirstOrDefault(x => x.Id == id);
        }

        public void Actualizar(Capacitaciones capacitaciones)
        {
            DB.Entry(capacitaciones).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public void Nuevo(Capacitaciones capacitaciones, int idCandidato)
        {
            capacitaciones.Candidato = idCandidato;
            capacitaciones.Id = NuevoCodigo();
            DB.Capacitaciones.Add(capacitaciones);

            DB.SaveChanges();
        }
        public int NuevoCodigo()
        {
            if (DB.Capacitaciones.ToList().Count >= 1)
            {
                return DB.Capacitaciones.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return 1;
        }

        public List<Niveles> ConsultaNiveles()
        {
            return DB.Niveles.ToList();
        }
    }
}
