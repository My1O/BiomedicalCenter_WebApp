using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Historium
    {
        public Historium()
        {
            HistoriaPacientes = new HashSet<HistoriaPaciente>();
        }

        public int IdHistoria { get; set; }
        public DateTime? FechaHistoria { get; set; }
        public string? Observacion { get; set; }

        public virtual ICollection<HistoriaPaciente> HistoriaPacientes { get; set; }
    }
}
