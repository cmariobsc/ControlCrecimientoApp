using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models.Catalogos;
using System;
using System.Collections.Generic;

namespace Proyecto.Services
{
    public class CatalogoService : ICatalogoService, IService
    {
        private readonly ICatalogoRepository _CatalogoRepository;

        public CatalogoService(ICatalogoRepository CatalogoRepository)
        {
            _CatalogoRepository = CatalogoRepository;
        }

        public IList<Parentesco> GetListParentesco(out string codError, out string mensajeRetorno)
        {
            return _CatalogoRepository.GetListParentesco(out codError, out mensajeRetorno);
        }
        public IList<Sexo> GetListSexo(out string codError, out string mensajeRetorno)
        {
            return _CatalogoRepository.GetListSexo(out codError, out mensajeRetorno);
        }
        public IList<Nacionalidad> GetListNacionalidad(out string codError, out string mensajeRetorno)
        {
            return _CatalogoRepository.GetListNacionalidad(out codError, out mensajeRetorno);
        }
        public IList<Provincia> GetListProvincia(out string codError, out string mensajeRetorno)
        {
            return _CatalogoRepository.GetListProvincia(out codError, out mensajeRetorno);
        }
        public IList<Ciudad> GetListCiudad(out string codError, out string mensajeRetorno)
        {
            return _CatalogoRepository.GetListCiudad(out codError, out mensajeRetorno);
        }
    }
}
