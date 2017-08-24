using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IRepresentanteSqlService : ISqlService
    {
        DataSet ConsultarRepresentante(int idUsuario, out string codError, out string mensajeRetorno);
    }
}
