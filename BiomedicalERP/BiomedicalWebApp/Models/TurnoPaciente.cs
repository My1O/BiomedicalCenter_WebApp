using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BiomedicalWebApp.Models
{
    public partial class TurnoPaciente
    {
        
        public int IdTurno { get; set; }
        
        public int IdPaciente { get; set; }
        
        public int IdMedico { get; set; }

        
        [DisplayName("ID Medico")]
        public virtual Medico IdMedicoNavigation { get; set; } = null!;
        [DisplayName("ID Paciente")]
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
        [DisplayName("ID Turno")]
        public virtual Turno IdTurnoNavigation { get; set; } = null!;
    }
}
