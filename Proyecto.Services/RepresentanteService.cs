using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;

namespace Proyecto.Services
{
    public class RepresentanteService : IRepresentanteService, IService
    {
        private readonly IRepresentanteRepository _RepresentanteRepository;

        public RepresentanteService(IRepresentanteRepository RepresentanteRepository)
        {
            _RepresentanteRepository = RepresentanteRepository;
        }

        public Representante GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno)
        {
            return _RepresentanteRepository.GetRepresentante(idUsuario, out codError, out mensajeRetorno);
        }

        public bool ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno)
        {
            return _RepresentanteRepository.ActualizarRepresentante(representante, out codError, out mensajeRetorno);
        }
    }
}
