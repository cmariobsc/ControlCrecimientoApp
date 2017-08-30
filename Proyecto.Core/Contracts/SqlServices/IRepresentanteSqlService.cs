using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IRepresentanteSqlService : ISqlService
    {
        //void ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno);
        DataSet GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno);
    }
}
