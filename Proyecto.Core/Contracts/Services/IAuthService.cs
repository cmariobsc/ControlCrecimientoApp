using System.Collections.Generic;
using Proyecto.Core.Models;
using Proyecto.Core.Models.Auth;

namespace Proyecto.Core.Contracts.Services
{
    public interface IAuthService : IService
    {
        ClientApp FindClientApp(string clientId);
        bool Registro(User usuario, out string codError, out string mensajeRetorno);
        User FindUser(string userName, string password, string ipAddress, out string codError, out string mensajeRetorno);
        bool AddRefreshToken(RefreshToken token);
        RefreshToken FindToken(string tokenId);
        bool RemoveToken(string tokenId);
    }
}
