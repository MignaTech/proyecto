using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class EditorialService : IEditorialService
    {
        #region add ILogger and context
        private readonly ILogger<EditorialService> _looger;
        private readonly proyectoContext _context;
        public EditorialService(ILogger<EditorialService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllEditorial(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Editorial from {index} to {take}");

                return _context.Editorials.Skip(index).Take(take).Select(e => new {
                    IdEditorial = e.IdEditorial,
                    Nombre = e.Nombre,
                    Estado = e.Estado == 1 ? "Activo" : "Inactivo"
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllEditorial)}", new { index, take });
                throw;
            }
        }

        public Editorial GetEditorial(int IdEditorial)
        {
            try
            {
                _looger.LogInformation($"Getting information for Editorial with number {IdEditorial}");
                return _context.Editorials.Where(e => e.IdEditorial == IdEditorial).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetEditorial)}", new { IdEditorial });
                throw;
            }
        }

        public bool SaveEditorial(Editorial editoriales)
        {
            try
            {
                _looger.LogInformation($"Adding new Editorial to database");
                _context.Editorials.Add(editoriales);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveEditorial)}", new { editoriales });
                throw;
            }
        }

        public bool UpdateEditorial(int IdEditorial, Editorial editoriales)
        {
            try
            {
                _looger.LogInformation($"Update record for the Editorial number {IdEditorial}");
                var savedEdit = _context.Editorials.Where(e => e.IdEditorial == IdEditorial).FirstOrDefault();
                if (savedEdit != null)
                {
                    savedEdit.Nombre = !savedEdit.Nombre.Equals(editoriales.Nombre) ? editoriales.Nombre : savedEdit.Nombre;
                    savedEdit.Estado = !savedEdit.Estado.Equals(editoriales.Estado) ? editoriales.Estado : savedEdit.Estado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateEditorial)}", new { IdEditorial, editoriales });
                throw;
            }
        }

        public bool DeleteEditorial(int IdEditorial)
        {
            try
            {
                _looger.LogInformation($"Delete Editorial with number {IdEditorial}");
                var savedEdit = _context.Editorials.Where(e => e.IdEditorial == IdEditorial).FirstOrDefault();
                if (savedEdit != null)
                {
                    _context.Editorials.Remove(savedEdit);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteEditorial)}", new { IdEditorial });
                throw;
            }
        }
    }
}
