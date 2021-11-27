using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class NivelUser
    {
        public NivelUser()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdNivelUser { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
