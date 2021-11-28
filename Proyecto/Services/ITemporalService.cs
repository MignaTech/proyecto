using System;
using System.Collections;
using Proyecto.Models;

namespace Proyecto.Services
{
    public interface ITemporalService
    {
        IEnumerable GetAllTemporal(int index, int take);
        Temporal GetTemporal(int IdTem);
        bool SaveTemporal(Temporal IdTem);
        bool UpdateTemporal(int IdTem, Temporal temporal);
        bool DeleteTemporal(int IdTem);
    }
}
