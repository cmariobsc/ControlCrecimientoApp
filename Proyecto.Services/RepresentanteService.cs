using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;

namespace Proyecto.Services
{
    public class RepresentanteService : IRepresentanteService, IService
    {
        private readonly IRepresentanteRepository _representanteRepository;

        public RepresentanteService(IRepresentanteRepository representanteRepository)
        {
            _representanteRepository = representanteRepository;
        }

        public Representante GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno)
        {
            return _representanteRepository.GetRepresentante(idUsuario, out codError, out mensajeRetorno);
        }

        public bool ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno)
        {
            return _representanteRepository.ActualizarRepresentante(representante, out codError, out mensajeRetorno);
        }
    }
}
