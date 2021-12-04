using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class UsuarioService : IUsuarioService
    {
        #region add ILogger and context
        private readonly ILogger<UsuarioService> _looger;
        private readonly proyectoContext _context;
        public UsuarioService(ILogger<UsuarioService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllUsuario(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Autor from {index} to {take}");

                return _context.Usuarios.Skip(index).Take(take).Select(a => new {
                    a.Id,
                    a.ApellidoPaterno,
                    a.ApellidoMaterno,
                    a.Nombre,
                    a.Correo,
                    a.Username,
                    a.Password
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllUsuario)}", new { index, take });
                throw;
            }
        }

        public Usuario GetUsuario(int Id)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {Id}");
                return _context.Usuarios.Where(e => e.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetUsuario)}", new { Id});
                throw;
            }
        }

        public Usuario GetLogin(string Username, string Password)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {Username}");
                return _context.Usuarios.Where(u => u.Username.Equals(Username) && u.Password.Equals(Password)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetUsuario)}", new { Username });
                throw;
            }
        }

        public bool SaveUsuario(Usuario usuarios)
        {
            try
            {
                _looger.LogInformation($"Adding new Autor to database");
                _context.Usuarios.Add(usuarios);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SaveUsuario)}", new { usuarios });
                throw;
            }
        }

        public bool UpdateUsuario(int Id, Usuario usuarios)
        {
            try
            {
                _looger.LogInformation($"Update record for the Autor number {Id}");
                var savedAut = _context.Usuarios.Where(e => e.Id == Id).FirstOrDefault();
                if (savedAut != null)
                {
                    savedAut.ApellidoPaterno = !savedAut.ApellidoPaterno.Equals(usuarios.ApellidoPaterno) ? usuarios.ApellidoPaterno : savedAut.ApellidoPaterno;
                    savedAut.ApellidoMaterno = !savedAut.ApellidoMaterno.Equals(usuarios.ApellidoMaterno) ? usuarios.ApellidoMaterno : savedAut.ApellidoMaterno;
                    savedAut.Nombre = !savedAut.Nombre.Equals(usuarios.Nombre) ? usuarios.Nombre : savedAut.Nombre;
                    savedAut.Correo = !savedAut.Correo.Equals(usuarios.Correo) ? usuarios.Correo : savedAut.Correo;
                    savedAut.Username = !savedAut.Username.Equals(usuarios.Username) ? usuarios.Username : savedAut.Username;
                    savedAut.Password = !savedAut.Password.Equals(usuarios.Password) ? usuarios.Password : savedAut.Password;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdateUsuario)}", new { Id, usuarios });
                throw;
            }
        }

        public bool DeleteUsuario(int Id)
        {
            try
            {
                _looger.LogInformation($"Delete Autor with number {Id}");
                var savedUsu = _context.Usuarios.Where(e => e.Id== Id).FirstOrDefault();
                if (savedUsu != null)
                {
                    _context.Usuarios.Remove(savedUsu);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeleteUsuario)}", new { Id });
                throw;
            }
        }
    }
}
