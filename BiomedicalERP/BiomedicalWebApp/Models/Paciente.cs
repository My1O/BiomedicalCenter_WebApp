using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("ID Paciente")]
        public int IdPaciente { get; set; }
        [DisplayName("DNI")]
        public string? Dni { get; set; }
        [DisplayName("Nombre")]
        public string? Nombre { get; set; }
        [DisplayName("Apellido")]
        public string? Apellido { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Observacion { get; set; }
        [DisplayName("País")]
        public string? IdPais { get; set; }

        public virtual Pai? IdPaisNavigation { get; set; }
        public virtual ICollection<HistoriaPaciente> HistoriaPacientes { get; set; }
        public virtual ICollection<PagoPaciente> PagoPacientes { get; set; }
        public virtual ICollection<TurnoPaciente> TurnoPacientes { get; set; }
    }
}
