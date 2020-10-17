using System;
using System.Collections.Generic;

namespace Proyecto_RRHH_Candidatos.Models
{
    public partial class IdiomasCandidatos
    {
        public int Id { get; set; }
        public int Candidato { get; set; }
        public int? Idiomas { get; set; }

        public virtual Candidatos CandidatoNavigation { get; set; }
        public virtual Idiomas IdiomasNavigation { get; set; }
    }
}
