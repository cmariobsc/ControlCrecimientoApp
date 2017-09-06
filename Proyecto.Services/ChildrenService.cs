using System;
using System.Collections.Generic;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;

namespace Proyecto.Services
{
    public class ChildrenService : IChildrenService, IService
    {
        private readonly IChildrenRepository _ChildrenRepository;

        public ChildrenService(IChildrenRepository ChildrenRepository)
        {
            _ChildrenRepository = ChildrenRepository;
        }

        public IList<Children> GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno)
        {
            return _ChildrenRepository.GetListChildren(idRepresentante, out codError, out mensajeRetorno);
        }

        public Children GetChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            return _ChildrenRepository.GetChildren(idChildren, out codError, out mensajeRetorno);
        }

        public bool GuardarChildren(Children Children, out string codError, out string mensajeRetorno)
        {
            return _ChildrenRepository.GuardarChildren(Children, out codError, out mensajeRetorno);
        }

        public bool ActualizarChildren(Children children, out string codError, out string mensajeRetorno)
        {
            return _ChildrenRepository.ActualizarChildren(children, out codError, out mensajeRetorno);
        }

        public bool EliminarChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            return _ChildrenRepository.EliminarChildren(idChildren, out codError, out mensajeRetorno);
        }
    }
}
