using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IChildrenSqlService
    {
        DataSet GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno);
        DataSet GetChildren(int idChildren, out string codError, out string mensajeRetorno);
        void GuardarChildren(Children children, out string codError, out string mensajeRetorno);
        void ActualizarChildren(Children children, out string codError, out string mensajeRetorno);
        void EliminarChildren(int idChildren, out string codError, out string mensajeRetorno);
        DataSet GetListHistorialChildren(int idChildren, out string codError, out string mensajeRetorno);
    }
}
