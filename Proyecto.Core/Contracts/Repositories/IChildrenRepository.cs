using System.Collections.Generic;
using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IChildrenRepository : IRepository
    {
        IList<Children> GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno);
        bool GuardarChildren(Children Children, out string codError, out string mensajeRetorno);
    }
}
