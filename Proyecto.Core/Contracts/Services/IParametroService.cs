using Proyecto.Core.Models;
using System.Collections.Generic;

namespace Proyecto.Core.Contracts.Services
{
    public interface IParametroService : IService
    {
        Parametro GetParametro(int idParametro);
        IList<Parametro> GetList();
    }
}
