using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Verentradum
    {
        public int IdProd { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public int Cantidad { get; set; }
    }
}
