using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class AutorService : IAutorService
    {
        #region add ILogger and context
        private readonly ILogger<AutorService> _looger;
        private readonly proyectoContext _context;
        public AutorService(ILogger<AutorService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

		public IEnumerable GetAllAutor(int index=0, int take=50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Autor from {index} to {take}");

                return _context.Autors.Skip(index).Take(take).Select(a => new {
                    IdAutor = a.IdAutor,
                    Nombre = a.Nombre,
                    Estado = a.Estado == 1 ? "Activo" : "Inactivo"
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllAutor)}", new { index, take });
                throw;
            }
        }

        public Autor GetAutor(int IdAutor)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {IdAutor}");
                return _context.Autors.Where(e => e.IdAutor == IdAutor).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAutor)}", new { IdAutor });
                throw;
            }
        }

        public bool SaveAutor(Autor autores)
        {
            try
            {
                _looger.LogInformation($"Adding new Autor to database");
                _context.Autors.Add(autores);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveAutor)}", new { autores});
                throw;
            }
        }

        public bool UpdateAutor(int IdAutor, Autor autores)
        {
            try
            {
                _looger.LogInformation($"Update record for the Autor number {IdAutor}");
                var savedAut = _context.Autors.Where(e => e.IdAutor == IdAutor).FirstOrDefault();
                if (savedAut != null)
                {
                    savedAut.Nombre = !savedAut.Nombre.Equals(autores.Nombre) ? autores.Nombre : savedAut.Nombre;
                    savedAut.Estado = !savedAut.Estado.Equals(autores.Estado) ? autores.Estado : savedAut.Estado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateAutor)}", new { IdAutor, autores });
                throw;
            }
        }

        public bool DeleteAutor(int IdAutor)
        {
            try
            {
                _looger.LogInformation($"Delete Autor with number {IdAutor}");
                var savedAut = _context.Autors.Where(e => e.IdAutor == IdAutor).FirstOrDefault();
                if (savedAut != null)
                {
                    _context.Autors.Remove(savedAut);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteAutor)}", new { IdAutor });
                throw;
            }
        }

    }
}


