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
    public class NivelController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly INivelService _service;
        private readonly ILogger<NivelController> _logger;
        public NivelController(INivelService service, ILogger<NivelController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/nivel")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NivelUser>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllNivel()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var nivel = _service.GetAllNivel(0, 100);
                return Ok(nivel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }
        [HttpGet("api/nivel/{IdNivelUser}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NivelUser))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNivel(int IdNivelUser)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdNivelUser}", null);
            try
            {
                var nivel = _service.GetNivel(IdNivelUser);
                if (nivel != null)
                {
                    return Ok(
                        new
                        {
                            Nombre = nivel.Nombre
                        }
                    );
                }
                return BadRequest("Autor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autor information", IdNivelUser);
                throw;
            }
        }
        [HttpPost("api/nivel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveNivel([FromBody] NivelUser nivelUser)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SaveNivel(nivelUser);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {nivelUser.IdNivelUser} to database");
                throw;
            }
        }
        [HttpPut("api/nivel/{IdNivelUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateNivel([FromBody] NivelUser nivelUser, int IdNivelUser)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating autor number {IdNivelUser}");
                var updated = _service.UpdateNivel(IdNivelUser, nivelUser);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Autor update {nivelUser.IdNivelUser}");
                throw;
            }
        }
        
        [HttpDelete("api/nivel/{IdNivelUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteNivel(int IdNivelUser)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting autor number {IdNivelUser}");
                var deleted = _service.DeleteNivel(IdNivelUser);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Autor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Autor {IdNivelUser}");
                throw;
            }
        }
    }
}
