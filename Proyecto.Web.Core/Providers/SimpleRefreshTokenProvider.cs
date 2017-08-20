using Microsoft.Owin.Security.Infrastructure;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models.Auth;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Threading.Tasks;

namespace Proyecto.Web.Core.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IAuthService _authService;

        public SimpleRefreshTokenProvider()
        {
            _authService = ServiceLocator.Current.GetInstance<IAuthService>();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {

            var clientId = context.Ticket.Properties.Dictionary["as:client_id"];
            if (string.IsNullOrEmpty(clientId)) return;

            var refreshTokenId = Guid.NewGuid().ToString("n");

            var refreshTokenLifeTime = context.OwinContext.Get<int>("as:clientRefreshTokenLifeTime");
            var token = new RefreshToken
            {
                Id = Helpers.CommonHelper.GetHash(refreshTokenId),
                ClientAppId = clientId,
                Username = context.Ticket.Identity.Name,
                CreatedDateUtc = DateTime.UtcNow,
                ExpirationDateUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.CreatedDateUtc;
            context.Ticket.Properties.ExpiresUtc = token.ExpirationDateUtc;

            token.ProtectedTicket = context.SerializeTicket();

            var result = _authService.AddRefreshToken(token);

            if (result)
                context.SetToken(refreshTokenId);
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var hashedTokenId = Helpers.CommonHelper.GetHash(context.Token);


            var refreshToken = _authService.FindToken(hashedTokenId);
            if (refreshToken != null)
            {
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                var result = _authService.RemoveToken(hashedTokenId);
            }
        }

        #region NOT IMPLEMENTED

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new System.NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
