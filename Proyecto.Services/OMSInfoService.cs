using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using System.Collections.Generic;

namespace Proyecto.Services
{
    public class OMSInfoService : IOMSInfoService, IService
    {
        private readonly IOMSInfoRepository _OMSInfoRepository;

        public OMSInfoService(IOMSInfoRepository omsInfoRepository)
        {
            _OMSInfoRepository = omsInfoRepository;
        }

        public IList<OMSCamposIndicadores> GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            return _OMSInfoRepository.GetListOMSTallaxEdad(idSexo, out codError, out mensajeRetorno);
        }
    }
}
