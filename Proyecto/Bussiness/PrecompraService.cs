using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class PrecompraService : IPrecompraService
    {
        #region add ILogger and context
        private readonly ILogger<PrecompraService> _looger;
        private readonly proyectoContext _context;
        public PrecompraService(ILogger<PrecompraService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllPrecompra(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Precompra from {index} to {take}");

                return _context.Verprecompras.Skip(index).Take(take).Select(e => new {
                    IdPre = e.IdPre,
                    IdCompra =e.IdCompra,
                    Titulo = e.Titulo,
                    PrecioUnitario = e.PrecioUnitario,
                    Cantidad = e.Cantidad,
                    PrecioTotal = e.PrecioTotal,
                    Estado = e.Estado
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllPrecompra)}", new { index, take });
                throw;
            }
        }

        public Verprecompra GetPrecompra(int IdPre)
        {
            try
            {
                _looger.LogInformation($"Getting information for Precompra with number {IdPre}");
                return _context.Verprecompras.Where(e => e.IdPre == IdPre).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetPrecompra)}", new { IdPre });
                throw;
            }
        }

        public bool SavePrecompra(Precompra precompra)
        {
            try
            {
                _looger.LogInformation($"Adding new Precompra to database");
                _context.Precompras.Add(precompra);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SavePrecompra)}", new { precompra });
                throw;
            }
        }

        public bool UpdatePrecompra(int IdPre, Precompra precompra)
        {
            try
            {
                _looger.LogInformation($"Update record for the Precompra number {IdPre}");
                var savedPrecompra = _context.Precompras.Where(e => e.IdPre == IdPre).FirstOrDefault();
                if (savedPrecompra != null)
                {
                    savedPrecompra.IdCompra = !savedPrecompra.IdCompra.Equals(precompra.IdCompra) ? precompra.IdCompra : savedPrecompra.IdCompra;
                    savedPrecompra.IdLibro = !savedPrecompra.IdLibro.Equals(precompra.IdLibro) ? precompra.IdLibro : savedPrecompra.IdLibro;
                    savedPrecompra.Cantidad = !savedPrecompra.Cantidad.Equals(precompra.Cantidad) ? precompra.Cantidad : savedPrecompra.Cantidad;
                    savedPrecompra.PrecioTotal = !savedPrecompra.PrecioTotal.Equals(precompra.PrecioTotal) ? precompra.PrecioTotal : savedPrecompra.PrecioTotal;
                    savedPrecompra.Estado = !savedPrecompra.Estado.Equals(precompra.Estado) ? precompra.Estado : savedPrecompra.Estado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdatePrecompra)}", new { IdPre, precompra });
                throw;
            }
        }

        public bool DeletePrecompra(int IdPre)
        {
            try
            {
                _looger.LogInformation($"Delete Precompra with number {IdPre}");
                var savedPrecompra = _context.Precompras.Where(e => e.IdPre == IdPre).FirstOrDefault();
                if (savedPrecompra != null)
                {
                    _context.Precompras.Remove(savedPrecompra);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeletePrecompra)}", new { IdPre });
                throw;
            }
        }

        public Total Total(int IdCompra)
        {
            try
            {
                _looger.LogInformation($"Getting information for Total with number {IdCompra}");
                return _context.Totals.Where(e => e.IdCompra == IdCompra).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetPrecompra)}", new { IdCompra });
                throw;
            }
        }

        public IEnumerable Confirmar(int IdCompra)
        {
            try
            {
                _looger.LogInformation($"Getting information for Precompra with number {IdCompra}");
                return _context.Verprecompras.Where(e => e.IdCompra == IdCompra);
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(Confirmar)}", new { IdCompra });
                throw;
            }
        }
    }
}
