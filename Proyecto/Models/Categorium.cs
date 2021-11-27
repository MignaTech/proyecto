using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public sbyte? Estado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
