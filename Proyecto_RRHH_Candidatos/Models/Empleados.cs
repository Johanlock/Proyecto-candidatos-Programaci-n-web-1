using System;
using System.Collections.Generic;

namespace Proyecto_RRHH_Candidatos.Models
{
    public partial class Empleados
    {
        public int CodigoEmpleador { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int Puesto { get; set; }
        public int? Estado { get; set; }

        public virtual Estados EstadoNavigation { get; set; }
        public virtual Puestos PuestoNavigation { get; set; }
    }
}
