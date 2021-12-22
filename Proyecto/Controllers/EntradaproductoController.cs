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
    public class EntradaproductoController : ControllerBase
    {

        #region add Interfaz and ILogger
        private readonly IEntradaproductoService _service;
        private readonly ILogger<EntradaproductoController> _logger;
        public EntradaproductoController(IEntradaproductoService service, ILogger<EntradaproductoController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion


        [HttpGet("api/entradaproductos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Entradaproduc>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllEntradaproducto()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var productos = _service.GetAllEntradaproducto(0, 100);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get entradaproducto information");
                throw;
            }
        }

        [HttpGet("api/entradaproductos/{IdProd}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entradaproduc))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEntradaproductos(int IdProd)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetEmployee with param {IdProd}", null);
            try
            {
                var producto = _service.GetEntradaproducto(IdProd);
                if (producto != null)
                {
                    return Ok(
                        new
                        {
                            IdProd = producto.IdProd,
                            Fecha = producto.Fecha,
                            IdLibro = producto.IdLibro,
                            Libro = producto.Titulo,
                            Cantidad = producto.Cantidad
                        }
                    );
                }
                return BadRequest("Entradaproducto Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get entradaproducto information", IdProd);
                throw;
            }
        }

        [HttpPost("api/entradaproductos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveEntradaproducto([FromBody] Entradaproduc entradaproducto)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new autor register");
                var added = _service.SaveEntradaproducto(entradaproducto);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Autor {entradaproducto.IdProd} to database");
                throw;
            }
        }

        [HttpPut("api/entradaproductos/{IdProd}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEntradaproducto([FromBody] Entradaproduc entradaproducto, int IdProd)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating entradaproducto number {IdProd}");
                var updated = _service.UpdateEntradaproducto(IdProd, entradaproducto);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Entradaproducto Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Entradaproducto update {entradaproducto.IdProd}");
                throw;
            }
        }
        
        [HttpDelete("api/entradaproductos/{IdProd}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEntradaproducto(int IdProd)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting entradaproducto number {IdProd}");
                var deleted = _service.DeleteEntradaproducto(IdProd);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Entradaproducto Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Entradaproducto {IdProd}");
                throw;
            }
        }

    }
}
