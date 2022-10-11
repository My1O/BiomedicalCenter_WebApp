using System;
using System.Collections.Generic;

namespace BiomedicalWebApp.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            Pagos = new HashSet<Pago>();
        }

        public byte IdConcepto { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
