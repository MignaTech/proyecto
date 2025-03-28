﻿using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IPrecompraService
    {
        IEnumerable GetAllPrecompra(int index, int take);
        Verprecompra GetPrecompra(int IdPre);
        bool SavePrecompra(Precompra IdPre);
        bool UpdatePrecompra(int IdPre, Precompra precompra);
        bool DeletePrecompra(int IdPre);
        IEnumerable Confirmar(int IdCompra);
        Total Total(int IdCompra);
    }
}
