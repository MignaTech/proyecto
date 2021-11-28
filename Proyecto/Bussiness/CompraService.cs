using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;
namespace Proyecto.Bussiness
{
    public class CompraService : ICompraService
    {

        #region add ILogger and context
        private readonly ILogger<CompraService> _looger;
        private readonly proyectoContext _context;
        public CompraService(ILogger<CompraService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllCompra(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Compra from {index} to {take}");

                return _context.Compras.Skip(index).Take(take).Select(e => new {
                    IdCompra = e.IdCompra,
                    Fecha = e.Fecha,
                    IdEmpleado = e.IdEmpleado,
                    TotalCompra = e.TotalCompra
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllCompra)}", new { index, take });
                throw;
            }
        }

        public Compra GetCompra(int IdCompra)
        {
            try
            {
                _looger.LogInformation($"Getting information for Compra with number {IdCompra}");
                return _context.Compras.Where(e => e.IdCompra == IdCompra).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetCompra)}", new { IdCompra });
                throw;
            }
        }

        public bool SaveCompra(Compra compra)
        {
            try
            {
                _looger.LogInformation($"Adding new compra to database");
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveCompra)}", new { compra });
                throw;
            }
        }

        public bool UpdateCompra(int IdCompra, Compra compra)
        {
            try
            {
                _looger.LogInformation($"Update record for the Compra number {IdCompra}");
                var savedCompra = _context.Compras.Where(e => e.IdCompra == IdCompra).FirstOrDefault();
                if (savedCompra != null)
                {
                    savedCompra.Fecha = !savedCompra.Fecha.Equals(compra.Fecha) ? compra.Fecha : savedCompra.Fecha;
                    savedCompra.IdEmpleado = !savedCompra.IdEmpleado.Equals(compra.IdEmpleado) ? compra.IdEmpleado : savedCompra.IdEmpleado;
                    savedCompra.TotalCompra = !savedCompra.TotalCompra.Equals(compra.TotalCompra) ? compra.TotalCompra : savedCompra.TotalCompra;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateCompra)}", new { IdCompra, compra });
                throw;
            }
        }


        public bool DeleteCompra(int IdCompra)
        {
            try
            {
                _looger.LogInformation($"Delete Compra with number {IdCompra}");
                var savedCompra = _context.Compras.Where(e => e.IdCompra == IdCompra).FirstOrDefault();
                if (savedCompra != null)
                {
                    _context.Compras.Remove(savedCompra);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteCompra)}", new { IdCompra });
                throw;
            }
        }

    }
}
