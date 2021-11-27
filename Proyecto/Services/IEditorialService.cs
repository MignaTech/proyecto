using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface IEditorialService
    {
        IEnumerable GetAllEditorial(int index, int take);
        Editorial GetEditorial(int IdEditorial);
        bool SaveEditorial(Editorial editoriales);
        bool UpdateEditorial(int IdEditorial, Editorial editoriales);
        bool DeleteEditorial(int IdEditorial);
    }
}
