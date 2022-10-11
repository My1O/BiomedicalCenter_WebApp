using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Turno
    {
        public Turno()
        {
            PagoPacientes = new HashSet<PagoPaciente>();
            TurnoPacientes = new HashSet<TurnoPaciente>();
        }

        public int IdTurno { get; set; }
        public DateTime? FechaTurno { get; set; }
        public short? Estado { get; set; }
        public string? Observacion { get; set; }

        public virtual TurnoEstado? EstadoNavigation { get; set; }
        public virtual ICollection<PagoPaciente> PagoPacientes { get; set; }
        public virtual ICollection<TurnoPaciente> TurnoPacientes { get; set; }
    }
}
