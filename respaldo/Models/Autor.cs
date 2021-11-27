using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public sbyte? Estado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
