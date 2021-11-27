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
    public class LibroController : ControllerBase
    {
        #region add Interfaz and ILogger
        private readonly ILibroService _service;
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILibroService service, ILogger<LibroController> logger)
        {
            _service = service;
            _logger = logger;
        }
        #endregion
        [HttpGet("api/libro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Libro>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllLibro()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Getting Autores list", null);
            try
            {
                var libro = _service.GetAllLibro(0, 100);
                return Ok(libro);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get libro information");
                throw;
            }
        }

        [HttpGet("api/libro/{IdLibro}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Libro))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetLibro(int IdLibro)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            _logger.LogInformation($"{userName} - Calling method GetLibro with param {IdLibro}", null);
            try
            {
                var libro = _service.GetLibro(IdLibro);
                if (libro != null)
                {
                    return Ok(
                        new
                        {
                            IdLibro = libro.IdLibro,
                            Titulo = libro.Titulo,
                            //Imagen = libro.imagen,
                            Autor = libro.Autor,
                            Categoria = libro.Categoria,
                            Editorial = libro.Editorial,
                            Ubicacion = libro.Ubicacion,
                            Ejemplares = libro.Ejemplares,
                            Estado = libro.Estado,
                            FechaPublicacion = libro.FechaPublicacion,
                            Costo = libro.Costo,
                            Precio = libro.Precio
                        }
                    );
                }
                return BadRequest("Employee Id was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during query to get libros information", IdLibro);
                throw;
            }
        }
        [HttpPost("api/libro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveLibro([FromBody] Libro libros)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Inserting new libro register");
                var added = _service.SaveLibro(libros);
                if (added)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during add new Libro {libros.IdLibro} to database");
                throw;
            }
        }
        [HttpPut("api/libro/{IdLibro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateLibro([FromBody] Libro libros, int IdLibro)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Updating libros number {IdLibro}");
                var updated = _service.UpdateLibro(IdLibro, libros);
                if (updated)
                    return Ok();
                else
                    return BadRequest("Libro Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during Libro update {libros.IdLibro}");
                throw;
            }
        }
        [HttpDelete("api/libro/{IdLibro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteLibro(int IdLibro)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"{userName} - Deleting libros number {IdLibro}");
                var deleted = _service.DeleteLibro(IdLibro);
                if (deleted)
                    return Ok();
                else
                    return BadRequest("Libro Id not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{userName} - Error during delete Libro {IdLibro}");
                throw;
            }
        }
    }
}
