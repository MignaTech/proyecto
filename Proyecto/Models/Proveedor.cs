using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Proveedor
    {
        public int IdProv { get; set; }
        public int IdEditorial { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public virtual Editorial IdEditorialNavigation { get; set; }
    }
}
