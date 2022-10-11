using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            HistoriaPacientes = new HashSet<HistoriaPaciente>();
            PagoPacientes = new HashSet<PagoPaciente>();
            TurnoPacientes = new HashSet<TurnoPaciente>();
        }

        public int IdPaciente { get; set; }
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Observacion { get; set; }
        public string? IdPais { get; set; }

        public virtual Pai? IdPaisNavigation { get; set; }
        public virtual ICollection<HistoriaPaciente> HistoriaPacientes { get; set; }
        public virtual ICollection<PagoPaciente> PagoPacientes { get; set; }
        public virtual ICollection<TurnoPaciente> TurnoPacientes { get; set; }
    }
}
