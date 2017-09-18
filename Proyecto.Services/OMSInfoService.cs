using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using System.Collections.Generic;

namespace Proyecto.Services
{
    public class OMSInfoService : IOMSInfoService, IService
    {
        private readonly IOMSInfoRepository _omsInfoRepository;

        public OMSInfoService(IOMSInfoRepository omsInfoRepository)
        {
            _omsInfoRepository = omsInfoRepository;
        }

        public IList<OMSCamposIndicadores> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            return _omsInfoRepository.GetListOMSTallaxEdad(idSexo, out codError, out mensajeRetorno);
        }
        public IList<OMSCamposIndicadores> GetListOMSPesoxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            return _omsInfoRepository.GetListOMSPesoxEdad(idSexo, out codError, out mensajeRetorno);
        }
        public IList<OMSCamposIndicadores> GetListOMSIMCxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            return _omsInfoRepository.GetListOMSIMCxEdad(idSexo, out codError, out mensajeRetorno);
        }
        public IList<OMSCamposIndicadores> GetListOMSPCxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            return _omsInfoRepository.GetListOMSPCxEdad(idSexo, out codError, out mensajeRetorno);
        }
        public IList<OMSCamposIndicadores> GetListOMSPMBxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            return _omsInfoRepository.GetListOMSPMBxEdad(idSexo, out codError, out mensajeRetorno);
        }
    }
}
