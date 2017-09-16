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

        public IList<OMSTallaxEdadMasculino> GetListOMSTallaxEdad(int idEdad, out string codError, out string mensajeRetorno)
        {
            return _OMSInfoRepository.GetListOMSTallaxEdad(idEdad, out codError, out mensajeRetorno);
        }
    }
}
