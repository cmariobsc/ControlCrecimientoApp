using System;
using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IRepresentanteRepository : IRepository
    {
        Representante GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno);
        bool ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno);
    }
}
