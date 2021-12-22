using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdNivel { get; set; }
        public sbyte? Estado { get; set; }

        public virtual NivelUser IdNivelNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
