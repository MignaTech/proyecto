using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Verpersona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdNivel { get; set; }
        public string Nivel { get; set; }
        public string Estado { get; set; }
    }
}
