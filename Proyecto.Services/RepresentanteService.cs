using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;

namespace Proyecto.Services
{
    public class RepresentanteService : IRepresentanteService, IService
    {
        private readonly IRepresentanteService _RepresentanteRepository;

        public RepresentanteService(IRepresentanteService RepresentanteRepository)
        {
            _RepresentanteRepository = RepresentanteRepository;
        }

        public Representante GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno)
        {
            return _RepresentanteRepository.GetRepresentante(idUsuario, out codError, out mensajeRetorno);
        }

        //public bool ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno)
        //{
        //    return _RepresentanteRepository.ActualizarRepresentante(representante, out codError, out mensajeRetorno);
        //}
    }
}
