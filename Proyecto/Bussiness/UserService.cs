using System;
using System.Linq;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Proyecto.Bussiness
{
    public class UserService : IUserService
    {
        #region add ILogger and context
        private readonly proyectoContext _context;
        private readonly JwtSettings _jwtSettings;
        public UserService(proyectoContext context, IOptions<JwtSettings> options)
        {
            _context = context;
            _jwtSettings = options.Value;
        }
        #endregion

        Usuario IUserService.Authenticate(string username, string password)
        {
            var user = _context.Usuarios.SingleOrDefault(u => u.Usuario1 == username && u.Password == password);
            if (user == null) return user;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim (ClaimTypes.Name, user.Usuario1),
                        new Claim ("dns", user.IdUser.ToString())
                    }
                ),
                Expires = DateTime.Now.AddHours(1),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }
    }
}
