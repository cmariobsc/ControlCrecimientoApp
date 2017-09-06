﻿using System.Collections.Generic;
using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IChildrenRepository : IRepository
    {
        IList<Children> GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno);
        Children GetChildren(int idChildren, out string codError, out string mensajeRetorno);
        bool GuardarChildren(Children children, out string codError, out string mensajeRetorno);
        bool ActualizarChildren(Children children, out string codError, out string mensajeRetorno);
        bool EliminarChildren(int idChildren, out string codError, out string mensajeRetorno);
    }
}
