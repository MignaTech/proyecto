using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Entradaproducs = new HashSet<Entradaproduc>();
            Precompras = new HashSet<Precompra>();
            Temporals = new HashSet<Temporal>();
        }

        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public int IdEditorial { get; set; }
        public int Ejemplares { get; set; }
        public decimal Costo { get; set; }
        public decimal? Precio { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Editorial IdEditorialNavigation { get; set; }
        public virtual ICollection<Entradaproduc> Entradaproducs { get; set; }
        public virtual ICollection<Precompra> Precompras { get; set; }
        public virtual ICollection<Temporal> Temporals { get; set; }
    }
}
