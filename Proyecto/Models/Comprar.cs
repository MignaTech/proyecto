using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Comprar
    {
        public int IdPre { get; set; }
        public int IdCompra { get; set; }
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int? PrecioTotal { get; set; }
        public string Estado { get; set; }
    }
}
