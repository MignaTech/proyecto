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
    public class CategoriController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly ICategoriService _service;
        private readonly ILogger<CategoriController> _logger;
        public CategoriController(ICategoriService service, ILogger<CategoriController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/categorias")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Categorium>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCategoria()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var categorias = _service.GetAllCategoria(0, 100);
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }
        [HttpGet("api/categorias/{IdCategoria}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categorium))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCategoria(int IdCategoria)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdCategoria}", null);
            try
            {
                var categoria = _service.GetCategoria(IdCategoria);
                if (categoria != null)
                {
                    return Ok(
                        new
                        {
                            Nombre = categoria.Nombre,
                            Estado = categoria.Estado == 1 ? "Activo" : "Inactivo"
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", IdCategoria);
                throw;
            }
        }
        [HttpPost("api/categorias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveCategoria([FromBody] Categorium categorias)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SaveCategoria(categorias);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {categorias.IdCategoria} to database");
                throw;
            }
        }
        [HttpPut("api/categorias/{IdCategoria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCategoria([FromBody] Categorium categorias, int IdCategoria)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating autor number {IdCategoria}");
                var updated = _service.UpdateCategoria(IdCategoria, categorias);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Autor update {categorias.IdCategoria}");
                throw;
            }
        }
        [HttpDelete("api/categorias/{IdCategoria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCategoria(int IdCategoria)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting autor number {IdCategoria}");
                var deleted = _service.DeleteCategoria(IdCategoria);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Autor {IdCategoria}");
                throw;
            }
        }
    }
}
