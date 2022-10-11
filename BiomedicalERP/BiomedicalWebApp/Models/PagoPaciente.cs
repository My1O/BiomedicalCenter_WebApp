using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class PagoPaciente
    {
        public int IdPago { get; set; }
        public int IdPaciente { get; set; }
        public int IdTurno { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; } = null!;
        public virtual Pago IdPagoNavigation { get; set; } = null!;
        public virtual Turno IdTurnoNavigation { get; set; } = null!;
    }
}
