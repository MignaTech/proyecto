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
    public class ComprasController : ControllerBase
    {

        #region add Interfaz and ILogger
        private readonly ICompraService _service;
        private readonly ILogger<ComprasController> _logger;
        public ComprasController(ICompraService service, ILogger<ComprasController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/compra")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Compra>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCompra()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Compras list", null);
            try
            {
                var compra = _service.GetAllCompra(0, 100);
                return Ok(compra);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get compras information");
                throw;
            }
        }

        [HttpGet("api/compra/{IdCompra}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compra))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCompra(int IdCompra)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetCompra with param {IdCompra}", null);
            try
            {
                var compra = _service.GetCompra(IdCompra);
                if (compra != null)
                {
                    return Ok(
                        new
                        {
                            Fecha = compra.Fecha,
                            IdEmpleado = compra.IdEmpleado,
                            TotalCompra = compra.TotalCompra
                }
                    );
                }
                return BadRequest("Compra Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get compra information", IdCompra);
                throw;
            }
        }

        [HttpPost("api/compra")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveCompra([FromBody] Compra compra)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new compra register");
                var added = _service.SaveCompra(compra);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Compra {compra.IdCompra} to database");
                throw;
            }
        }

        [HttpPut("api/compra/{IdCompra}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCompra([FromBody] Compra compra, int IdCompra)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating compra number {IdCompra}");
                var updated = _service.UpdateCompra(IdCompra, compra);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Compra Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Compra update {compra.IdCompra}");
                throw;
            }
        }

        
        [HttpDelete("api/compra/{IdCompra}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCompra(int IdCompra)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting compra number {IdCompra}");
                var deleted = _service.DeleteCompra(IdCompra);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Compra Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Compra {IdCompra}");
                throw;
            }
        }

    }
}
