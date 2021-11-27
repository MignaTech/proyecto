using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class LibroService : ILibroService
    {
        #region add ILogger and context
        private readonly ILogger<LibroService> _looger;
        private readonly proyectoContext _context;
        public LibroService(ILogger<LibroService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllLibro(int index=5, int take=50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Autor from {index} to {take}");
                return _context.Verlibros.Skip(index).Take(take).Select(a => a);
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllLibro)}", new { index, take });
                throw;
            }
        }

        public Verlibro GetLibro(int IdLibro)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {IdLibro}");
                return _context.Verlibros.Where(e => e.IdLibro == IdLibro).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetLibro)}", new { IdLibro });
                throw;
            }
        }

        public bool SaveLibro(Libro libros)
        {
            try
            {
                _looger.LogInformation($"Adding new Autor to database");
                _context.Libros.Add(libros);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveLibro)}", new { libros });
                throw;
            }
        }

        public bool UpdateLibro(int IdLibro, Libro libros)
        {
            try
            {
                _looger.LogInformation($"Update record for the Autor number { IdLibro }");
                var saved = _context.Libros.Where(e => e.IdLibro == IdLibro).FirstOrDefault();
                if (saved != null)
                {
                    saved.Titulo = !saved.Titulo.Equals(libros.Titulo) ? libros.Titulo : saved.Titulo;
                    saved.Imagen = !saved.Imagen.Equals(libros.Imagen) ? libros.Imagen : saved.Imagen;
                    saved.IdAutor = !saved.IdAutor.Equals(libros.IdAutor) ? libros.IdAutor : saved.IdAutor;
                    saved.IdCategoria = !saved.IdCategoria.Equals(libros.IdCategoria) ? libros.IdCategoria : saved.IdCategoria;
                    saved.IdEditorial = !saved.IdEditorial.Equals(libros.IdEditorial) ? libros.IdEditorial : saved.IdEditorial;
                    saved.Ubicacion = !saved.Ubicacion.Equals(libros.Ubicacion) ? libros.Ubicacion : saved.Ubicacion;
                    saved.Ejemplares = !saved.Ejemplares.Equals(libros.Ejemplares) ? libros.Ejemplares : saved.Ejemplares;
                    saved.Estado = !saved.Estado.Equals(libros.Estado) ? libros.Estado : saved.Estado;
                    saved.FechaPublicacion = !saved.FechaPublicacion.Equals(libros.FechaPublicacion) ? libros.FechaPublicacion : saved.FechaPublicacion;
                    saved.Costo = !saved.Costo.Equals(libros.Costo) ? libros.Costo : saved.Costo;
                    saved.Precio = !saved.Precio.Equals(libros.Precio) ? libros.Precio : saved.Precio;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateLibro)}", new { IdLibro, libros });
                throw;
            }
        }

        public bool DeleteLibro(int IdLibro)
        {
            try
            {
                _looger.LogInformation($"Delete Autor with number {IdLibro}");
                var saved = _context.Libros.Where(e => e.IdLibro == IdLibro).FirstOrDefault();
                if (saved != null)
                {
                    _context.Libros.Remove(saved);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteLibro)}", new { IdLibro });
                throw;
            }
        }
    }
}
