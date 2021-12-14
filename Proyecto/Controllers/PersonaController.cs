using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Proyecto.Controllers
{
    //[Authorize]
    public class PersonaController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly IPersonaService _service;
        private readonly ILogger<PersonaController> _logger;
        public PersonaController(IPersonaService service, ILogger<PersonaController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/persona")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Persona>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPersona()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var persona = _service.GetAllPersona(0, 100);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }
        [HttpGet("api/persona/{IdPersona}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Persona))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPersona(int IdPersona)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdPersona}", null);
            try
            {
                var persona = _service.GetPersona(IdPersona);
                if (persona != null)
                {
                    return Ok(
                        new
                        {
                            IdPersona = persona.IdPersona,
                            Nombre = persona.Nombre,
                            Apellido = persona.Apellido,
                            Direccion = persona.Direccion,
                            Telefono = persona.Telefono,
                            Correo = persona.Correo,
                            Usuario = persona.Usuario,
                            Password = persona.Password,
                            IdNivel = persona.IdNivel,
                            Nivel = persona.Nivel,
                            Estado = persona.Estado
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", IdPersona);
                throw;
            }
        }
        [HttpPost("api/persona")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SavePersona([FromBody] Persona persona)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SavePersona(persona);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {persona.IdPersona} to database");
                throw;
            }
        }
        [HttpPut("api/persona/{IdPersona}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePersona([FromBody] Persona persona, int IdPersona)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating autor number {IdPersona}");
                var updated = _service.UpdatePersona(IdPersona, persona);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Autor update {persona.IdPersona}");
                throw;
            }
        }
        [HttpDelete("api/persona/{IdPersona}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePersona(int IdPersona)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting autor number {IdPersona}");
                var deleted = _service.DeletePersona(IdPersona);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Autor {IdPersona}");
                throw;
            }
        }
    }
}
