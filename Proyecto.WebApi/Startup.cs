using System;
using System.Configuration;
using System.Web.Http;
using Proyecto.Web.Core.Providers;
using Proyecto.WebApi.Ioc;
using Proyecto.WebApi.Ioc.Installers;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.ServiceLocation;
using Owin;

[assembly: OwinStartup(typeof(Proyecto.WebApi.Startup))]
namespace Proyecto.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SetServiceLocator();
            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
            var config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            config.DependencyResolver = httpDependencyResolver;
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private IWindsorContainer SetServiceLocator()
        {
            var container = new WindsorContainer()
                .Install(
                        new ControllerInstaller(),
                        new DefaultInstaller(),
                        new RepositoryInstaller(),
                        new ServiceInstaller()
                        );

            var windsorServiceLocator = new WindsorServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => windsorServiceLocator);

            return container;
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            double expirationTimeSpan;
            if (!double.TryParse(ConfigurationManager.AppSettings["MinutosExpiracionToken"], out expirationTimeSpan))
            {
                expirationTimeSpan = 20;
            }

            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(expirationTimeSpan),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}