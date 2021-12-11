using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Precompras = new HashSet<Precompra>();
            Temporals = new HashSet<Temporal>();
        }

        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
        public double TotalCompra { get; set; }

        public virtual ICollection<Precompra> Precompras { get; set; }
        public virtual ICollection<Temporal> Temporals { get; set; }
    }
}
