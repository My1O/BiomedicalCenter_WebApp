using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public string IdPais { get; set; } = null!;
        public string? PaisNombre { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
