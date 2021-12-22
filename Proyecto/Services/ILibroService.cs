using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface ILibroService
    {
        IEnumerable GetAllLibro(int index, int take);
        Verlibro GetLibro(int IdLibro);
        bool SaveLibro(Libro libros);
        bool UpdateLibro(int IdLibro, Libro libros);
        bool Stock(int IdLibro, Libro libros);
        bool DeleteLibro(int IdLibro);
    }
}
