using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class NivelService : INivelService
    {
        #region add ILogger and context
        private readonly ILogger<NivelService> _looger;
        private readonly proyectoContext _context;
        public NivelService(ILogger<NivelService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllNivel(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Nivel de Usuario from {index} to {take}");

                return _context.NivelUsers.Skip(index).Take(take).Select(e => new {
                    IdNivelUser = e.IdNivelUser,
                    Nombre = e.Nombre
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllNivel)}", new { index, take });
                throw;
            }
        }

        public NivelUser GetNivel(int IdNivelUser)
        {
            try
            {
                _looger.LogInformation($"Getting information for Nivel de Usuario with number {IdNivelUser}");
                return _context.NivelUsers.Where(e => e.IdNivelUser == IdNivelUser).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetNivel)}", new { IdNivelUser });
                throw;
            }
        }

        public bool SaveNivel(NivelUser NivelUsers)
        {
            try
            {
                _looger.LogInformation($"Adding new Nivel de Usuario to database");
                _context.NivelUsers.Add(NivelUsers);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveNivel)}", new { NivelUsers });
                throw;
            }
        }

        public bool UpdateNivel(int IdNivelUser, NivelUser NivelUsers)
        {
            try
            {
                _looger.LogInformation($"Update record for the Nivel de Usuario number {IdNivelUser}");
                var savedNiv = _context.NivelUsers.Where(e => e.IdNivelUser == IdNivelUser).FirstOrDefault();
                if (savedNiv != null)
                {
                    savedNiv.Nombre = !savedNiv.Nombre.Equals(NivelUsers.Nombre) ? NivelUsers.Nombre : savedNiv.Nombre;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateNivel)}", new { IdNivelUser, NivelUsers });
                throw;
            }
        }

        public bool DeleteNivel(int IdNivelUser)
        {
            try
            {
                _looger.LogInformation($"Delete Nivel de Usuario with number {IdNivelUser}");
                var savedNiv = _context.NivelUsers.Where(e => e.IdNivelUser == IdNivelUser).FirstOrDefault();
                if (savedNiv != null)
                {
                    _context.NivelUsers.Remove(savedNiv);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteNivel)}", new { IdNivelUser });
                throw;
            }
        }

    }
}
