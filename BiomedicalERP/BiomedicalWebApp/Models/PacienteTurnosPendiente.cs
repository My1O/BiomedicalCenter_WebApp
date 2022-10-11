using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class PacienteTurnosPendiente
    {
        public int IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public short? Estado { get; set; }
        public DateTime? FechaTurno { get; set; }
    }
}
