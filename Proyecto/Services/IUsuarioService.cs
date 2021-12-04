using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IUsuarioService
    {
        IEnumerable GetAllUsuario(int index, int take);
        Usuario GetUsuario(int Id);
        Usuario GetLogin(string Username,string Password);
        bool SaveUsuario(Usuario usuarios);
        bool UpdateUsuario(int Id, Usuario usuarios);
        bool DeleteUsuario(int Id);
    }
}
