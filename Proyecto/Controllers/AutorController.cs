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
    [Authorize]
    public class AutorController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly IAutorService _service;
        private readonly ILogger<AutorController> _logger;
        public AutorController(IAutorService service, ILogger<AutorController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/autores")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Autor>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllAutor()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var autores = _service.GetAllAutor(0, 100);
                return Ok(autores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }
        [HttpGet("api/autores/{IdAutor}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Autor))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAutor(int IdAutor)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdAutor}", null);
            try
            {
                var autor = _service.GetAutor(IdAutor);
                if (autor != null)
                {
                    return Ok(
                        new
                        {
                            Nombre = autor.Nombre,
                            Estado = autor.Estado == 1 ? "Activo" : "Inactivo"
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", IdAutor);
                throw;
            }
        }
        [HttpPost("api/autores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveAutor([FromBody] Autor autor)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SaveAutor(autor);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {autor.IdAutor} to database");
                throw;
            }
        }
        [HttpPut("api/autores/{IdAutor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateAutor([FromBody] Autor autor, int IdAutor)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating autor number {IdAutor}");
                var updated = _service.UpdateAutor(IdAutor, autor);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Autor update {autor.IdAutor}");
                throw;
            }
        }
        [HttpDelete("api/autores/{IdAutor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAutor(int IdAutor)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting autor number {IdAutor}");
                var deleted = _service.DeleteAutor(IdAutor);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Autor {IdAutor}");
                throw;
            }
        }
    }
}
