using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_RRHH_Candidatos.Models
{
    public partial class ExperienciaLaboral
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Descripcion { get; set; }
        public string Puesto { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public string FechaInicio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public string FechaFinal { get; set; }
        public decimal Salario { get; set; }
        public int? Candidato { get; set; }

        public virtual Candidatos CandidatoNavigation { get; set; }
    }
}
