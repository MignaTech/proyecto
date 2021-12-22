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
    public class EditorialController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly IEditorialService _service;
        private readonly ILogger<EditorialController> _logger;
        public EditorialController(IEditorialService service, ILogger<EditorialController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/editorial")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Editorial>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllEditorial()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var editorial = _service.GetAllEditorial(0, 100);
                return Ok(editorial);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }
        [HttpGet("api/editorial/{IdEditorial}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Editorial))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEditorial(int IdEditorial)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdEditorial}", null);
            try
            {
                var Editorial = _service.GetEditorial(IdEditorial);
                if (Editorial != null)
                {
                    return Ok(
                        new
                        {
                            Nombre = Editorial.Nombre,
                            Estado = Editorial.Estado == 1 ? "Activo" : "Inactivo"
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", IdEditorial);
                throw;
            }
        }
        [HttpPost("api/editorial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveEditorial([FromBody] Editorial editorial)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SaveEditorial(editorial);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {editorial.IdEditorial} to database");
                throw;
            }
        }
        [HttpPut("api/editorial/{IdEditorial}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEditorial([FromBody] Editorial editorial, int IdEditorial)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating autor number {IdEditorial}");
                var updated = _service.UpdateEditorial(IdEditorial, editorial);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Autor update {editorial.IdEditorial}");
                throw;
            }
        }
        
        [HttpDelete("api/editorial/{IdEditorial}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEditorial(int IdEditorial)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting autor number {IdEditorial}");
                var deleted = _service.DeleteEditorial(IdEditorial);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Autor {IdEditorial}");
                throw;
            }
        }
    }
}
