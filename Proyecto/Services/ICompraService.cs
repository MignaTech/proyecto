using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface ICompraService
    {
        IEnumerable GetAllCompra(int index, int take);
        Compra GetCompra(int IdCompra); 
        bool SaveCompra(Compra compra);
        bool UpdateCompra(int IdCompra, Compra compra);
        bool DeleteCompra(int IdCompra);
    }
}
