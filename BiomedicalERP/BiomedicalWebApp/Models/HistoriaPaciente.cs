using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class HistoriaPaciente
    {
        public int IdHistoria { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }

        public virtual Historium IdHistoriaNavigation { get; set; } = null!;
        public virtual Medico IdMedicoNavigation { get; set; } = null!;
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
    }
}
