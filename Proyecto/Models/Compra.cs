using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdEmpleado { get; set; }
        public double? TotalCompra { get; set; }
    }
}
