using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Entradaproduc
    {
        public int IdProd { get; set; }
        public DateTime Fecha { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }

        public virtual Libro IdLibroNavigation { get; set; }
    }
}
