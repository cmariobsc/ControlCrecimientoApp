using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IChildrenSqlService
    {
        DataSet GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno);
        void GuardarChildren(Children children, out string codError, out string mensajeRetorno);
    }
}
