using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface ICategoriService
    {
        IEnumerable GetAllCategoria(int index, int take);
        Categorium GetCategoria(int IdCategoria);
        bool SaveCategoria(Categorium categorias);
        bool UpdateCategoria(int IdCategoria, Categorium categorias);
        bool DeleteCategoria(int IdCategoria);
    }
}
