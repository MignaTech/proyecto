using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Temporal
    {
        public int IdTem { get; set; }
        public int? IdCompra { get; set; }
        public int? IdLibro { get; set; }
        public int? Cantidad { get; set; }
        public double? PrecioTotal { get; set; }
        public sbyte? Estado { get; set; }
    }
}
