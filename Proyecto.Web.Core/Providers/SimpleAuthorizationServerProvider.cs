using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Contracts.Enumerations;
using Proyecto.Web.Core.Helpers;
using System.Security.Claims;
using Proyecto.Core.Models.Auth;
using Microsoft.Practices.ServiceLocation;

namespace Proyecto.Web.Core.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService _authService;

        public SimpleAuthorizationServerProvider()
        {
            _authService = ServiceLocator.Current.GetInstance<IAuthService>();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.Validated();
                return Task.FromResult<object>(null);
            }

            var clientApp = _authService.FindClientApp(context.ClientId);
            if (clientApp == null)
            {
                context.SetError("invalid_clientId", $"Cliente '{context.ClientId}' no esta autorizado para usar el API.");
                return Task.FromResult<object>(null);
            }

            if (clientApp.ApplicationType == (short)ApplicationType.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Código de Acceso Incorrecto");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (clientApp.Secret != CommonHelper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Codigo de acceso invalido");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            if (!clientApp.Active)
            {
                context.SetError("invalid_clientId", "App Cliente Deshabilitada.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set("as:clientAllowedOrigin", clientApp.AllowedOrigin);
            context.OwinContext.Set("as:clientRefreshTokenLifeTime", clientApp.RefreshTokenLifeTime);

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin")
                ?? "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            User user;
            try
            {
                string codError;
                string mensajeRetorno;
                var userIp = context.Request.RemoteIpAddress;

                user = _authService.FindUser(context.UserName, context.Password, userIp, out codError, out mensajeRetorno);

                if (user == null && codError != "000")
                {
                    context.SetError("invalid_grant", mensajeRetorno);
                    return;
                }

            }
            catch (Exception exception)
            {
                context.SetError("invalid_grant", exception.Message);
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("username", user.Username));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("nombre", user.Nombre));
            identity.AddClaim(new Claim("usuario", user.Username));
            identity.AddClaim(new Claim("perfil", user.Perfil.ToString()));
            identity.AddClaim(new Claim("producto", user.Producto));

            var props = new AuthenticationProperties(
                new Dictionary<string, string>
                {
                    {"as:client_id",context.ClientId ?? string.Empty },
                    {"userName",context.UserName }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;
            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token generado para otro cliente.");
                return Task.FromResult<object>(null);
            }

            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            var newClaim = newIdentity.Claims.FirstOrDefault(c => c.Type == "newClaim");
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
