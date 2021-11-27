using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Verlibro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public string Editorial { get; set; }
        public string Ubicacion { get; set; }
        public int Ejemplares { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public decimal Costo { get; set; }
        public decimal? Precio { get; set; }
    }
}
