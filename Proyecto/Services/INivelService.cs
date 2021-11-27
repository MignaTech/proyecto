using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface INivelService
    {
        IEnumerable GetAllNivel(int index, int take);
        NivelUser GetNivel(int IdNivelUser);
        bool SaveNivel(NivelUser NivelUsers);
        bool UpdateNivel(int IdNivelUser, NivelUser NivelUsers);
        bool DeleteNivel(int IdNivelUser);
    }
}
