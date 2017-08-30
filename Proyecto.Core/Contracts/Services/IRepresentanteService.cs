using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Services
{
    public interface IRepresentanteService : IService
    {
        Representante GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno);
        //bool ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno);
    }
}
