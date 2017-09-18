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
        private readonly IChildrenRepository _childrenRepository;

        public ChildrenService(IChildrenRepository childrenRepository)
        {
            _childrenRepository = childrenRepository;
        }

        public IList<Children> GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno)
        {
            return _childrenRepository.GetListChildren(idRepresentante, out codError, out mensajeRetorno);
        }

        public Children GetChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            return _childrenRepository.GetChildren(idChildren, out codError, out mensajeRetorno);
        }

        public bool GuardarChildren(Children Children, out string codError, out string mensajeRetorno)
        {
            return _childrenRepository.GuardarChildren(Children, out codError, out mensajeRetorno);
        }

        public bool ActualizarChildren(Children children, out string codError, out string mensajeRetorno)
        {
            return _childrenRepository.ActualizarChildren(children, out codError, out mensajeRetorno);
        }

        public bool EliminarChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            return _childrenRepository.EliminarChildren(idChildren, out codError, out mensajeRetorno);
        }

        public IList<HistorialChildren> GetListHistorialChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            return _childrenRepository.GetListHistorialChildren(idChildren, out codError, out mensajeRetorno);
        }
    }
}
