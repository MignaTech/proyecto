using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class ProveService : IProveService
    {
        #region add ILogger and context
        private readonly ILogger<ProveService> _looger;
        private readonly proyectoContext _context;
        public ProveService(ILogger<ProveService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllProveedor(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Autor from {index} to {take}");

                return _context.Proveedors.Skip(index).Take(take).Select(e => new {
                    IdEditorial = e.IdEditorial,
                    Nombre = e.Nombre,
                    Telefono = e.Telefono,
                    Direccion = e.Direccion,
                    Correo = e.Correo
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllProveedor)}", new { index, take });
                throw;
            }
        }

        public Proveedor GetProveedor(int IdProv)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {IdProv}");
                return _context.Proveedors.Where(e => e.IdProv == IdProv).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetProveedor)}", new { IdProv });
                throw;
            }
        }

        public bool SaveProveedor(Proveedor proveedor)
        {
            try
            {
                _looger.LogInformation($"Adding new Autor to database");
                _context.Proveedors.Add(proveedor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveProveedor)}", new { proveedor });
                throw;
            }
        }

        public bool UpdateProveedor(int IdProv, Proveedor proveedor)
        {
            try
            {
                _looger.LogInformation($"Update record for the Autor number {IdProv}");
                var savedPro = _context.Proveedors.Where(e => e.IdProv == IdProv).FirstOrDefault();
                if (savedPro != null)
                {
                    savedPro.IdEditorial = !savedPro.IdEditorial.Equals(proveedor.IdEditorial) ? proveedor.IdEditorial : savedPro.IdEditorial;
                    savedPro.Nombre = !savedPro.Nombre.Equals(proveedor.Nombre) ? proveedor.Nombre : savedPro.Nombre;
                    savedPro.Telefono = !savedPro.Telefono.Equals(proveedor.Telefono) ? proveedor.Telefono : savedPro.Telefono;
                    savedPro.Direccion = !savedPro.Direccion.Equals(proveedor.Direccion) ? proveedor.Direccion : savedPro.Direccion;
                    savedPro.Correo = !savedPro.Correo.Equals(proveedor.Correo) ? proveedor.Correo : savedPro.Correo;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateProveedor)}", new { IdProv, proveedor });
                throw;
            }
        }

        public bool DeleteProveedor(int IdProv)
        {
            try
            {
                _looger.LogInformation($"Delete Autor with number {IdProv}");
                var savedPro = _context.Proveedors.Where(e => e.IdProv == IdProv).FirstOrDefault();
                if (savedPro != null)
                {
                    _context.Proveedors.Remove(savedPro);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteProveedor)}", new { IdProv });
                throw;
            }
        }
    }
}
