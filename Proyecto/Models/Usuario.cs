using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
