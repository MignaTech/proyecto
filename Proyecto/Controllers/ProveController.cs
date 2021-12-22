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
    public class ProveController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly IProveService _service;
        private readonly ILogger<ProveController> _logger;
        public ProveController(IProveService service, ILogger<ProveController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet("api/prove")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Proveedor>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllProveedor()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var prov = _service.GetAllProveedor(0, 100);
                return Ok(prov);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get Proveedores information");
                throw;
            }
        }
        [HttpGet("api/prove/{IdProv}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Proveedor))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProveedor(int IdProv)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdProv}", null);
            try
            {
                var prov = _service.GetProveedor(IdProv);
                if (prov != null)
                {
                    return Ok(
                        new
                        {
                            IdProv = prov.IdProv,
                            IdEditorial = prov.IdEditorial,
                            Editorial = prov.Editorial,
                            Nombre = prov.Nombre,
                            Telefono = prov.Telefono,
                            Direccion = prov.Direccion,
                            Correo = prov.Correo
                        }
                    );
                }
                return BadRequest("Proveedor Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get Proveedor information", IdProv);
                throw;
            }
        }
        [HttpPost("api/prove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveProveedor([FromBody] Proveedor prov)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new Proveedor register");
                var added = _service.SaveProveedor(prov);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Proveedor {prov.IdProv} to database");
                throw;
            }
        }
        [HttpPut("api/prove/{IdProv}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProveedor([FromBody] Proveedor prov, int IdProv)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating Proveedor number {IdProv}");
                var updated = _service.UpdateProveedor(IdProv, prov);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Proveedor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Proveedor update {prov.IdProv}");
                throw;
            }
        }
        
        [HttpDelete("api/prove/{IdProv}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProveedor(int IdProv)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting Proveedor number {IdProv}");
                var deleted = _service.DeleteProveedor(IdProv);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Proveedor Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Proveedor {IdProv}");
                throw;
            }
        }
    }
}
