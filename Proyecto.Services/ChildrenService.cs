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

        //public Children GetChildren(int idChildren)
        //{
        //    return _ChildrenRepository.GetChildren(idChildren);
        //}

        public IList<Children> GetListChildren(int IdRepresentante, out string codError, out string mensajeRetorno)
        {
            return _ChildrenRepository.GetListChildren(IdRepresentante, out codError, out mensajeRetorno);
        }

        //public bool InsertarChildren(Children Children, out string codError, out string mensajeRetorno)
        //{
        //   return   _ChildrenRepository.InsertarChildren(Children, out codError, out mensajeRetorno);
        //}

        //public bool ActualizarChildren(Children Children, out string codError, out string mensajeRetorno)
        //{
        //    return _ChildrenRepository.ActualizarChildren(Children, out codError, out mensajeRetorno);
        //}

        //public bool EliminarChildren(int id, string usuarioModificacion, out string codError, out string mensajeRetorno)
        //{
        //    return _ChildrenRepository.EliminarChildren(id, usuarioModificacion, out codError, out mensajeRetorno);
        //}
    }
}
