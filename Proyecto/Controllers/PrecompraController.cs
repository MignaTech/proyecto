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
    public class PrecompraController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly IPrecompraService _service;
        private readonly ILogger<PrecompraController> _logger;
        public PrecompraController(IPrecompraService service, ILogger<PrecompraController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/precompra")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Precompra>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetAllPrecompra()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Precompras list", null);
            try
            {
                var precompra = _service.GetAllPrecompra(0, 100);
                return Ok(precompra);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get autores information");
                throw;
            }
        }

        [HttpGet("api/precompra/{IdPre}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Precompra))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPrecompra(int IdPre)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetPrecompra with param {IdPre}", null);
            try
            {
                var precompra = _service.GetPrecompra(IdPre);
                if (precompra != null)
                {
                    return Ok(
                        new
                        {
                            IdCompra = precompra.IdCompra,
                            Titulo = precompra.Titulo,
                            PrecioUnitario = precompra.PrecioUnitario,
                            Cantidad = precompra.Cantidad,
                            PrecioTotal = precompra.PrecioTotal,                      
                            Estado = precompra.Estado
                        }
                    );
                }
                return BadRequest("Precompra Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get precompra information", IdPre);
                throw;
            }
        }

        [HttpPost("api/precompra")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SavePrecompra([FromBody] Precompra precompra)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new precompra register");
                var added = _service.SavePrecompra(precompra);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Precompra {precompra.IdPre} to database");
                throw;
            }
        }

        [HttpPut("api/precompra/{IdPre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePrecompra([FromBody] Precompra precompra, int IdPre)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating precompra number {IdPre}");
                var updated = _service.UpdatePrecompra(IdPre, precompra);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Precompra Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Precompra update {precompra.IdPre}");
                throw;
            }
        }

        //[Authorize]
        [HttpDelete("api/precompra/{IdPre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePrecompra(int IdPre)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting precompra number {IdPre}");
                var deleted = _service.DeletePrecompra(IdPre);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Precompra Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Precompra {IdPre}");
                throw;
            }
        }

    }
}
