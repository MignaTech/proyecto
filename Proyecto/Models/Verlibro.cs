﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Verlibro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public string Autor { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int IdEditorial { get; set; }
        public string Editorial { get; set; }
        public int Ejemplares { get; set; }
        public decimal Costo { get; set; }
        public decimal? Precio { get; set; }
    }
}
