using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Verproveedor
    {
        public int IdProv { get; set; }
        public int IdEditorial { get; set; }
        public string Editorial { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}
