using System.Collections.Generic;
using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IParametroRepository : IRepository
    {
        IList<Parametro> GetList();
        Parametro GetParametro(int idParametro);
    }
}
