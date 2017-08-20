using Proyecto.Core.Models.Auth;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface ITokenRepository : IRepository
    {
        ClientApp FindClientApp(string clientId);
        bool AddToken(RefreshToken token);
        RefreshToken FindToken(string tokenId);
        bool RemoveToken(string tokenId);
    }
}
