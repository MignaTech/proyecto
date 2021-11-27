using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class CategoriService : ICategoriService
    {
        #region add ILogger and context
        private readonly ILogger<CategoriService> _looger;
        private readonly proyectoContext _context;
        public CategoriService(ILogger<CategoriService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllCategoria(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Categoria from {index} to {take}");

                return _context.Categoria.Skip(index).Take(take).Select(e => new {
                    IdCategoria = e.IdCategoria,
                    Nombre = e.Nombre,
                    Estado = e.Estado == 1 ? "Activo" : "Inactivo"
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllCategoria)}", new { index, take });
                throw;
            }
        }

        public Categorium GetCategoria(int IdCategoria)
        {
            try
            {
                _looger.LogInformation($"Getting information for Categoria with number {IdCategoria}");
                return _context.Categoria.Where(e => e.IdCategoria == IdCategoria).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetCategoria)}", new { IdCategoria });
                throw;
            }
        }

        public bool SaveCategoria(Categorium categorias)
        {
            try
            {
                _looger.LogInformation($"Adding new Categoria to database");
                _context.Categoria.Add(categorias);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveCategoria)}", new { categorias });
                throw;
            }
        }

        public bool UpdateCategoria(int IdCategoria, Categorium categorias)
        {
            try
            {
                _looger.LogInformation($"Update record for the Categoria number {IdCategoria}");
                var savedCat = _context.Categoria.Where(e => e.IdCategoria == IdCategoria).FirstOrDefault();
                if (savedCat != null)
                {
                    savedCat.Nombre = !savedCat.Nombre.Equals(categorias.Nombre) ? categorias.Nombre : savedCat.Nombre;
                    savedCat.Estado = !savedCat.Estado.Equals(categorias.Estado) ? categorias.Estado : savedCat.Estado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateCategoria)}", new { IdCategoria, categorias });
                throw;
            }
        }

        public bool DeleteCategoria(int IdCategoria)
        {
            try
            {
                _looger.LogInformation($"Delete Categoria with number {IdCategoria}");
                var savedCat = _context.Categoria.Where(e => e.IdCategoria == IdCategoria).FirstOrDefault();
                if (savedCat != null)
                {
                    _context.Categoria.Remove(savedCat);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteCategoria)}", new { IdCategoria });
                throw;
            }
        }

    }
}
