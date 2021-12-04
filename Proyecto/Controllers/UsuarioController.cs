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
    public class UsuarioController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUsuarioService service, ILogger<UsuarioController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Usuario>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllUsuario()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var usuarios = _service.GetAllUsuario(0, 100);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }
        [HttpGet("api/usuarios/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUsuario(int Id)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {Id}", null);
            try
            {
                var usuario = _service.GetUsuario(Id);
                if (usuario != null)
                {
                    return Ok(
                        new
                        {
                            ApellidoPaterno = usuario.ApellidoPaterno,
                            ApellidoMaterno = usuario.ApellidoMaterno,
                            Nombre = usuario.Nombre,
                            Correo = usuario.Correo,
                            Username = usuario.Username,
                            Password = usuario.Password
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", Id);
                throw;
            }
        }

        [HttpGet("api/usuarios/{Username}/{Password}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetLogin(string Username, string Password)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {Username}", null);
            try
            {
                var usuario = _service.GetLogin(Username,Password);
                if (usuario != null)
                {
                    return Ok(
                        new
                        {
                            ApellidoPaterno = usuario.ApellidoPaterno,
                            ApellidoMaterno = usuario.ApellidoMaterno,
                            Nombre = usuario.Nombre,
                            Correo = usuario.Correo,
                            Username = usuario.Username,
                            Password = usuario.Password
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", Username);
                throw;
            }
        }

        [HttpPost("api/usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveUsuario([FromBody] Usuario usuarios)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SaveUsuario(usuarios);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {usuarios.Id} to database");
                throw;
            }
        }
        [HttpPut("api/usuarios/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUsuario([FromBody] Usuario usuarios, int Id)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating autor number {Id}");
                var updated = _service.UpdateUsuario(Id, usuarios);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Autor update {usuarios.Id}");
                throw;
            }
        }
        [HttpDelete("api/usuarios/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteUsuario(int Id)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting autor number {Id}");
                var deleted = _service.DeleteUsuario(Id);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Autor {Id}");
                throw;
            }
        }
    }
}
