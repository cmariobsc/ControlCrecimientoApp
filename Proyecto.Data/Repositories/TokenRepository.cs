using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models.Auth;

namespace Proyecto.Data.Repositories
{
    public class TokenRepository : ITokenRepository, IRepository
    {
        public ClientApp FindClientApp(string clientId)
        {
            if (clientId == "proyecto_app")
            {
                return new ClientApp
                {
                    Id = "proyecto_app",
                    Name = "Proyecto app",
                    Active = true,
                    AllowedOrigin = "*",
                    ApplicationType = 0,
                    RefreshTokenLifeTime = 1040,
                    Secret = "secret_secret"
                };
            }

            return null;
        }
        public bool AddToken(RefreshToken token)
        {
            //TODO: Implement
            return true;
        }
        public RefreshToken FindToken(string tokenId)
        {
            //TODO: Implement
            return null;
        }
        public bool RemoveToken(string tokenId)
        {
            //TODO: Implement
            return true;
        }
    }
}
