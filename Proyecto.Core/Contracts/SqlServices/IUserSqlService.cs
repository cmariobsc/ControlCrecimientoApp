using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IUserSqlService : ISqlService
    {
        void AutenticarUsuario(string usuario, string contrasenia, out string codError, out string mensajeRetorno);
        DataSet ConsultarUsuario(string usuario, out string codError, out string mensajeRetorno);
    }
}
