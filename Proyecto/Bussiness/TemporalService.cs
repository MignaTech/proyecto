using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class TemporalService : ITemporalService
    {
        #region add ILogger and context
        private readonly ILogger<TemporalService> _looger;
        private readonly proyectoContext _context;
        public TemporalService(ILogger<TemporalService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllTemporal(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Temporal from {index} to {take}");

                return _context.Temporals.Skip(index).Take(take).Select(e => new {
                    IdTem = e.IdTem,
                    IdCompra = e.IdCompra,
                    IdLibro = e.IdLibro,
                    Cantidad = e.Cantidad,
                    PrecioTotal = e.PrecioTotal,
                    Estado = e.Estado
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllTemporal)}", new { index, take });
                throw;
            }
        }

        public Temporal GetTemporal(int IdTem)
        {
            try
            {
                _looger.LogInformation($"Getting information for Temporal with number {IdTem}");
                return _context.Temporals.Where(e => e.IdTem == IdTem).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetTemporal)}", new { IdTem });
                throw;
            }
        }

        public bool SaveTemporal(Temporal temporal)
        {
            try
            {
                _looger.LogInformation($"Adding new Temporal to database");
                _context.Temporals.Add(temporal);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveTemporal)}", new { temporal });
                throw;
            }
        }

        public bool UpdateTemporal(int IdTem, Temporal temporal)
        {
            try
            {
                _looger.LogInformation($"Update record for the Temporal number {IdTem}");
                var savedTemporal = _context.Temporals.Where(e => e.IdTem == IdTem).FirstOrDefault();
                if (savedTemporal != null)
                {
                    savedTemporal.IdCompra = !savedTemporal.IdCompra.Equals(temporal.IdCompra) ? temporal.IdCompra : savedTemporal.IdCompra;
                    savedTemporal.IdLibro = !savedTemporal.IdLibro.Equals(temporal.IdLibro) ? temporal.IdLibro : savedTemporal.IdLibro;
                    savedTemporal.Cantidad = !savedTemporal.Cantidad.Equals(temporal.Cantidad) ? temporal.Cantidad : savedTemporal.Cantidad;
                    savedTemporal.PrecioTotal = !savedTemporal.PrecioTotal.Equals(temporal.PrecioTotal) ? temporal.PrecioTotal : savedTemporal.PrecioTotal;
                    savedTemporal.Estado = !savedTemporal.Estado.Equals(temporal.Estado) ? temporal.Estado : savedTemporal.Estado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateTemporal)}", new { IdTem, temporal });
                throw;
            }
        }

        public bool DeleteTemporal(int IdTem)
        {
            try
            {
                _looger.LogInformation($"Delete Temporal with number {IdTem}");
                var savedTemporal = _context.Temporals.Where(e => e.IdTem == IdTem).FirstOrDefault();
                if (savedTemporal != null)
                {
                    _context.Temporals.Remove(savedTemporal);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteTemporal)}", new { IdTem });
                throw;
            }
        }

    }
}
