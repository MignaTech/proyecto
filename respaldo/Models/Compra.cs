using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public int IdLibro { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public int IdEmpleado { get; set; }
        public string Folio { get; set; }
    }
}
