using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
            Proveedors = new HashSet<Proveedor>();
        }

        public int IdEditorial { get; set; }
        public string Nombre { get; set; }
        public sbyte? Estado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
        public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}
