using Proyecto.Core.Contracts;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Proyecto.WebApi.Ioc.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Types.FromAssemblyNamed("Proyecto.Services")
                    .BasedOn(typeof(IService))
                    .WithService.DefaultInterfaces());
        }
    }
}