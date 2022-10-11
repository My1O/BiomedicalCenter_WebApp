using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class TurnoPaciente
    {
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; } = null!;
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
        public virtual Turno IdTurnoNavigation { get; set; } = null!;
    }
}
