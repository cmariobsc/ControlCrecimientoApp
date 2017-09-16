using Proyecto.Core.Models;
using System.Collections.Generic;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IOMSInfoRepository : IRepository
    {
        IList<OMSCamposIndicadores> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno);
    }
}
