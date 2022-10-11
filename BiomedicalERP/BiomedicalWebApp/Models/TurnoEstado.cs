using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class TurnoEstado
    {
        public TurnoEstado()
        {
            Turnos = new HashSet<Turno>();
        }

        public short IdEstado { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
