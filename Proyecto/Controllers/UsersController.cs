using System;
using Proyecto.Models;
using Proyecto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Proyecto.Controllers
{
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController (ILogger<UsersController> logger, IUserService service)
        {
            _service = service;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost ("/api/users/authenticate")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Usuario))]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate ([FromBody] Usuario user)
        {
            try
            {
                _logger.LogInformation ($"Trying to authenticate user {user.Usuario1}");
                var userData = _service.Authenticate (user.Usuario1, user.Password);
                if (userData == null)
                {
                    _logger.LogInformation ("Either username or password were incorrect!"); 
                    return BadRequest ("Username or password incorrect!");
                }

                _logger.LogInformation ($"Authentication successful! user: {user.Usuario1}");
                return Ok (userData);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, $"An error occurs while trying to authenticate user {user.Usuario1}");
                throw;
            }
        }
    }
}
