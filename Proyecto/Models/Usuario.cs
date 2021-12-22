using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Usuario
    {
        public int? IdUser { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
