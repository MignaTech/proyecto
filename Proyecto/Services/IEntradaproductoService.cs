using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IEntradaproductoService
    {
        IEnumerable GetAllEntradaproducto(int index, int take);
        Verentradum GetEntradaproducto(int IdProd);
        bool SaveEntradaproducto(Entradaproduc entradaproductos);
        bool UpdateEntradaproducto(int IdProd, Entradaproduc entradaproductos);
        bool DeleteEntradaproducto(int IdProd);
    }
}
