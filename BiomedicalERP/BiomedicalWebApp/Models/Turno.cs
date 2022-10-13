using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BiomedicalWebApp.Models
{
    public partial class Turno
    {
        public Turno()
        {
            PagoPacientes = new HashSet<PagoPaciente>();
            TurnoPacientes = new HashSet<TurnoPaciente>();
        }
        [DisplayName("Id Turno")]
        public int IdTurno { get; set; }
        [DisplayName("Fecha de Turno")]
        public DateTime? FechaTurno { get; set; }
        public short? Estado { get; set; }
        [DisplayName("Motivo Consulta")]
        public string? Observacion { get; set; }
        [DisplayName("Estado")]
        public virtual TurnoEstado? EstadoNavigation { get; set; }
        public virtual ICollection<PagoPaciente> PagoPacientes { get; set; }
        public virtual ICollection<TurnoPaciente> TurnoPacientes { get; set; }
    }
}
