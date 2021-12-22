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
    public class TemporalController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly ITemporalService _service;
        private readonly ILogger<TemporalController> _logger;
        public TemporalController(ITemporalService service, ILogger<TemporalController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/temporal")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Temporal>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetAllTemporal()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Temporal list", null);
            try
            {
                var temporal = _service.GetAllTemporal(0, 100);
                return Ok(temporal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get temporal information");
                throw;
            }
        }

        [HttpGet("api/temporal/{IdTem}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Temporal))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTemporal(int IdTem)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetTemporal with param {IdTem}", null);
            try
            {
                var temporal = _service.GetTemporal(IdTem);
                if (temporal != null)
                {
                    return Ok(
                        new
                        {
                            IdCompra = temporal.IdCompra,
                            IdLibro = temporal.IdLibro,
                            Cantidad = temporal.Cantidad,
                            PrecioTotal = temporal.PrecioTotal,
                            Estado = temporal.Estado
                        }
                    );
                }
                return BadRequest("Temporal Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get Temporal information", IdTem);
                throw;
            }
        }

        [HttpPost("api/temporal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveTemporal([FromBody] Temporal temporal)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new temporal register");
                var added = _service.SaveTemporal(temporal);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Temporal {temporal.IdTem} to database");
                throw;
            }
        }

        [HttpPut("api/temporal/{IdTem}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTemporal([FromBody] Temporal temporal, int IdTem)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating temporal number {IdTem}");
                var updated = _service.UpdateTemporal(IdTem, temporal);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Temporal Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Temporal update {temporal.IdTem}");
                throw;
            }
        }

        
        [HttpDelete("api/temporal/{IdTem}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTemporal(int IdTem)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting temporal number {IdTem}");
                var deleted = _service.DeleteTemporal(IdTem);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Temporal Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Temporal {IdTem}");
                throw;
            }
        }

    }
}
