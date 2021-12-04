using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Precompra2
    {
        public int IdPre { get; set; }
        public int IdCompra { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public int PrecioTotal { get; set; }
        public sbyte? Estado { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Libro IdLibroNavigation { get; set; }
    }
}
