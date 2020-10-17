using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Candidatos.Models;

namespace Proyecto_RH__Servicios_.Services
{
    public class Servicios_Vacantes
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public List<Puestos> ConsultaGeneral()
        {
            return DB.Puestos.Include("DepartamentoNavigation").Include("EstadoNavigation").Select(x=>x).Where(x=>x.Estado >= 2).ToList();
        }

        public Puestos ConsultaPorCodigo(int codigo)
        {
            return DB.Puestos.Include("DepartamentoNavigation").Include("EstadoNavigation").FirstOrDefault(x=>x.Id == codigo);
        }
        public void Actualizar(Puestos puestos)
        {
            DB.Entry(puestos).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public void Eliminar(int codigo)
        {
           var puesto = ConsultaPorCodigo(codigo);
            DB.Puestos.Remove(puesto);
            DB.SaveChanges();
        }

        public void Nuevo(Puestos id)
        {
            DB.Puestos.Add(id);
            DB.SaveChanges();
        }
        public int NuevoCodigo()
        {
            return  DB.Puestos.OrderByDescending(x=>x.Id).FirstOrDefault().Id +1;
        }
    }
}
