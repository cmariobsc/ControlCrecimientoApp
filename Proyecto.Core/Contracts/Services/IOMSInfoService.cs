using Proyecto.Core.Models;
using System.Collections.Generic;

namespace Proyecto.Core.Contracts.Services
{
    public interface IOMSInfoService : IService
    {
        IList<OMSTallaxEdadMasculino> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno);
    }
}
