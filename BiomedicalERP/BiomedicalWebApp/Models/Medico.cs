using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Medico
    {
        public Medico()
        {
            HistoriaPacientes = new HashSet<HistoriaPaciente>();
            MedicoEspecialidads = new HashSet<MedicoEspecialidad>();
            TurnoPacientes = new HashSet<TurnoPaciente>();
        }

        public int IdMedico { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public virtual ICollection<HistoriaPaciente> HistoriaPacientes { get; set; }
        public virtual ICollection<MedicoEspecialidad> MedicoEspecialidads { get; set; }
        public virtual ICollection<TurnoPaciente> TurnoPacientes { get; set; }
    }
}
