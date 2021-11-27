using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class EntradaproductoService : IEntradaproductoService
    {

        #region add ILogger and context
        private readonly ILogger<EntradaproductoService> _looger;
        private readonly proyectoContext _context;
        public EntradaproductoService(ILogger<EntradaproductoService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllEntradaproducto(int index = 0, int take = 50)
        {

            try
            {
                _looger.LogInformation($"Fetching information for Entradaproducto from {index} to {take}");

                return _context.Verentrada.Skip(index).Take(take).Select(e => new
                {
                    IdProd = e.IdProd,
                    Fecha = e.Fecha,
                    Libro = e.Titulo,
                    Cantidad = e.Cantidad
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllEntradaproducto)}", new { index, take });
                throw;
            }
        }

        public Verentradum GetEntradaproducto(int IdProd)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {IdProd}");
                return _context.Verentrada.Where(e => e.IdProd == IdProd).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetEntradaproducto)}", new { IdProd });
                throw;
            }
        }

        public bool SaveEntradaproducto(Entradaproduc entradaproducto)
        {
            try
            {
                _looger.LogInformation($"Adding new Entradaproducto to database");
                _context.Entradaproducs.Add(entradaproducto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveEntradaproducto)}", new { entradaproducto });
                throw;
            }
        }

        public bool UpdateEntradaproducto(int IdProd, Entradaproduc entradaproducto)
        {
            try
            {
                _looger.LogInformation($"Update record for the Entradaproducto number {IdProd}");
                var savedEntradaproducto = _context.Entradaproducs.Where(e => e.IdProd == IdProd).FirstOrDefault();
                if (savedEntradaproducto != null)
                {
                    savedEntradaproducto.Fecha = !savedEntradaproducto.Fecha.Equals(entradaproducto.Fecha) ? entradaproducto.Fecha : entradaproducto.Fecha;
                    savedEntradaproducto.IdLibro = !savedEntradaproducto.IdLibro.Equals(entradaproducto.IdLibro) ? entradaproducto.IdLibro : entradaproducto.IdLibro;
                    savedEntradaproducto.Cantidad = !savedEntradaproducto.Cantidad.Equals(entradaproducto.Cantidad) ? entradaproducto.Cantidad : entradaproducto.Cantidad;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateEntradaproducto)}", new { IdProd, entradaproducto });
                throw;
            }
        }
        public bool DeleteEntradaproducto(int IdProd)
        {
            try
            {
                _looger.LogInformation($"Delete Entradaproducto with number {IdProd}");
                var savedEntradaproducto = _context.Entradaproducs.Where(e => e.IdProd == IdProd).FirstOrDefault();
                if (savedEntradaproducto != null)
                {
                    _context.Entradaproducs.Remove(savedEntradaproducto);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteEntradaproducto)}", new { IdProd });
                throw;
            }
        }
    }
}
