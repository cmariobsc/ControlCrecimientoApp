using System;
using System.Collections.Generic;
using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Services
{
    public interface IChildrenService : IService
    {
        //bool ActualizarChildren(Children Children, out string codError, out string mensajeRetorno);
        IList<Children> GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno);
        bool GuardarChildren(Children children, out string codError, out string mensajeRetorno);
        //Children GetChildren(int idChildren);
        //bool EliminarChildren(int id, string usuarioModificacion, out string codError, out string mensajeRetorno);
    }
}
