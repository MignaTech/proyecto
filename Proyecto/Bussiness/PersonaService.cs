using System;
using System.Linq;
using System.Collections;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.Extensions.Logging;

namespace Proyecto.Bussiness
{
    public class PersonaService : IPersonaService
    {
        #region add ILogger and context
        private readonly ILogger<PersonaService> _looger;
        private readonly proyectoContext _context;
        public PersonaService(ILogger<PersonaService> logger, proyectoContext context)
        {
            _context = context;
            _looger = logger;
        }
        #endregion

        public IEnumerable GetAllPersona(int index = 0, int take = 50)
        {
            try
            {
                _looger.LogInformation($"Fetching information for Autor from {index} to {take}");

                return _context.Personas.Skip(index).Take(take).Select(e => new {
                    IdPersona = e.IdPersona,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Direccion = e.Direccion,
                    Telefono = e.Telefono,
                    Correo = e.Correo,
                    Usuario = e.Usuario,
                    Password = e.Password,
                    IdNivel = e.IdNivel,
                    Estado = e.Estado
                });
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetAllPersona)}", new { index, take });
                throw;
            }
        }

        public Persona GetPersona(int IdPersona)
        {
            try
            {
                _looger.LogInformation($"Getting information for Autor with number {IdPersona}");
                return _context.Personas.Where(e => e.IdPersona == IdPersona).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(GetPersona)}", new { IdPersona });
                throw;
            }
        }

        public bool SavePersona(Persona persona)
        {
            try
            {
                _looger.LogInformation($"Adding new Autor to database");
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(SavePersona)}", new { persona });
                throw;
            }
        }

        public bool UpdatePersona(int IdPersona, Persona persona)
        {
            try
            {
                _looger.LogInformation($"Update record for the Autor number {IdPersona}");
                var savedPer = _context.Personas.Where(e => e.IdPersona == IdPersona).FirstOrDefault();
                if (savedPer != null)
                {
                    savedPer.Nombre = !savedPer.Nombre.Equals(persona.Nombre) ? persona.Nombre : savedPer.Nombre;
                    savedPer.Apellido = !savedPer.Apellido.Equals(persona.Apellido) ? persona.Apellido : savedPer.Apellido;
                    savedPer.Direccion = !savedPer.Direccion.Equals(persona.Direccion) ? persona.Direccion : savedPer.Direccion;
                    savedPer.Telefono = !savedPer.Telefono.Equals(persona.Telefono) ? persona.Telefono : savedPer.Telefono;
                    savedPer.Correo = !savedPer.Correo.Equals(persona.Correo) ? persona.Correo : savedPer.Correo;
                    savedPer.Usuario = !savedPer.Usuario.Equals(persona.Usuario) ? persona.Usuario : savedPer.Usuario;
                    savedPer.Password = !savedPer.Password.Equals(persona.Password) ? persona.Password : savedPer.Password;
                    savedPer.IdNivel = !savedPer.IdNivel.Equals(persona.IdNivel) ? persona.IdNivel : savedPer.IdNivel;
                    savedPer.Estado = !savedPer.Estado.Equals(persona.Estado) ? persona.Estado : savedPer.Estado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(UpdatePersona)}", new { IdPersona, persona });
                throw;
            }
        }

        public bool DeletePersona(int IdPersona)
        {
            try
            {
                _looger.LogInformation($"Delete Autor with number {IdPersona}");
                var savedPer = _context.Personas.Where(e => e.IdPersona == IdPersona).FirstOrDefault();
                if (savedPer != null)
                {
                    _context.Personas.Remove(savedPer);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _looger.LogError(ex, $"An error ocurred in method {nameof(DeletePersona)}", new { IdPersona });
                throw;
            }
        }
    }
}
