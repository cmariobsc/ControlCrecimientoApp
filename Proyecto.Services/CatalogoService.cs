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
        private readonly ICatalogoRepository _catalogoRepository;

        public CatalogoService(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public IList<Parentesco> GetListParentesco(out string codError, out string mensajeRetorno)
        {
            return _catalogoRepository.GetListParentesco(out codError, out mensajeRetorno);
        }
        public IList<Sexo> GetListSexo(out string codError, out string mensajeRetorno)
        {
            return _catalogoRepository.GetListSexo(out codError, out mensajeRetorno);
        }
        public IList<Nacionalidad> GetListNacionalidad(out string codError, out string mensajeRetorno)
        {
            return _catalogoRepository.GetListNacionalidad(out codError, out mensajeRetorno);
        }
        public IList<Provincia> GetListProvincia(out string codError, out string mensajeRetorno)
        {
            return _catalogoRepository.GetListProvincia(out codError, out mensajeRetorno);
        }
        public IList<Ciudad> GetListCiudad(out string codError, out string mensajeRetorno)
        {
            return _catalogoRepository.GetListCiudad(out codError, out mensajeRetorno);
        }
        public IList<Doctor> GetListDoctor(out string codError, out string mensajeRetorno)
        {
            return _catalogoRepository.GetListDoctor(out codError, out mensajeRetorno);
        }
    }
}
