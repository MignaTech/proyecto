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
        }

        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public byte[] Imagen { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public int IdEditorial { get; set; }
        public string Ubicacion { get; set; }
        public int Ejemplares { get; set; }
        public ulong? Estado { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int Costo { get; set; }
        public int Precio { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Editorial IdEditorialNavigation { get; set; }
        public virtual ICollection<Entradaproduc> Entradaproducs { get; set; }
    }
}
