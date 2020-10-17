using System;
using System.Collections.Generic;

namespace Proyecto_RRHH_Candidatos.Models
{
    public partial class EstadosCandidato
    {
        public EstadosCandidato()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}
