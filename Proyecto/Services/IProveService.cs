using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IProveService
    {
        IEnumerable GetAllProveedor(int index, int take);
        Verproveedor GetProveedor(int IdProv);
        bool SaveProveedor(Proveedor proveedor);
        bool UpdateProveedor(int IdProv, Proveedor proveedor);
        bool DeleteProveedor(int IdProv);
    }
}
