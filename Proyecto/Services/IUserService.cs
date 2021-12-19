using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IUserService
    {
        Usuario Authenticate (string username, string password);
    }
}
