using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Pago
    {
        public Pago()
        {
            PagoPacientes = new HashSet<PagoPaciente>();
        }

        public int IdPago { get; set; }
        public byte Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public byte? Estado { get; set; }
        public string? Observacion { get; set; }

        public virtual Concepto ConceptoNavigation { get; set; } = null!;
        public virtual ICollection<PagoPaciente> PagoPacientes { get; set; }
    }
}
