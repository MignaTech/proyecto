﻿using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IPersonaService
    {
        IEnumerable GetAllPersona(int index, int take);
        Verpersona GetPersona(int IdPersona);
        Verpersona Usuario(string usuario);
        bool SavePersona(Persona persona);
        bool UpdatePersona(int IdPersona, Persona persona);
        bool DeletePersona(int IdPersona);
    }
}
