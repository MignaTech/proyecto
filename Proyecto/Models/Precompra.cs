using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Precompra
    {
        public int IdPre { get; set; }
        public int IdLibro { get; set; }
        public int Precio { get; set; }
        public int IdEmpleado { get; set; }
        public sbyte? Estado { get; set; }
    }
}
