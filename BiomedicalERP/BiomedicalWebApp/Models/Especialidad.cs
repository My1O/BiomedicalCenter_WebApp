using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            MedicoEspecialidads = new HashSet<MedicoEspecialidad>();
        }

        public int IdEspecialidad { get; set; }
        public string? Especialidad1 { get; set; }

        public virtual ICollection<MedicoEspecialidad> MedicoEspecialidads { get; set; }
    }
}
