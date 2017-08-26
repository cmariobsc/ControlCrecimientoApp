﻿using Proyecto.Core.Models.Catalogos;
using System.Collections.Generic;

namespace Proyecto.Core.Contracts.Services
{
    public interface ICatalogoService : IService
    {
        IList<Parentesco> GetListParentesco(out string codError, out string mensajeRetorno);
        IList<Nacionalidad> GetListNacionalidad(out string codError, out string mensajeRetorno);
        IList<Provincia> GetListProvincia(out string codError, out string mensajeRetorno);
        IList<Ciudad> GetListCiudad(out string codError, out string mensajeRetorno);
    }
}
