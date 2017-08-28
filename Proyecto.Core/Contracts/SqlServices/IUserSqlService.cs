using Proyecto.Core.Models.Auth;
using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IUserSqlService : ISqlService
    {
        void Registro(User usuario, out string codError, out string mensajeRetorno);
        void AutenticarUsuario(string usuario, string contrasenia, out string codError, out string mensajeRetorno);
        DataSet ConsultarUsuario(string usuario, out string codError, out string mensajeRetorno);
    }
}
