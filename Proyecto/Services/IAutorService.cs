using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IAutorService
    {
        IEnumerable GetAllAutor(int index, int take);
        Autor GetAutor(int IdAutor);
        bool SaveAutor(Autor autores);
        bool UpdateAutor(int IdAutor, Autor autores);
        bool DeleteAutor(int IdAutor);
    }
}

