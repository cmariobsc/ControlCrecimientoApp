using Proyecto.Core.Contracts;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Proyecto.WebApi.Ioc.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Types.FromAssemblyNamed("Proyecto.Data")
                    .BasedOn(typeof(IRepository))
                    .WithService.DefaultInterfaces());
        }
    }
}