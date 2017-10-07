using Proyecto.Core.Models;
using System.Collections.Generic;

namespace Proyecto.Core.Contracts.Services
{
    public interface IOMSInfoService : IService
    {
        IList<OMSCamposIndicadores> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno);
        IList<OMSCamposIndicadores> GetListOMSPesoxEdad(int idSexo, out string codError, out string mensajeRetorno);
        IList<OMSCamposIndicadores> GetListOMSIMCxEdad(int idSexo, out string codError, out string mensajeRetorno);
        IList<OMSCamposIndicadores> GetListOMSPCxEdad(int idSexo, out string codError, out string mensajeRetorno);
        IList<OMSCamposIndicadores> GetListOMSPMBxEdad(int idSexo, out string codError, out string mensajeRetorno);
    }
}
