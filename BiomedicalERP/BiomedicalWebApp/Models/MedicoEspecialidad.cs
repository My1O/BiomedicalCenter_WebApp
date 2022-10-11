using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class MedicoEspecialidad
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string? Descripcion { get; set; }

        public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;
        public virtual Medico IdMedicoNavigation { get; set; } = null!;
    }
}
