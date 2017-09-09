using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models.Catalogos;
using Proyecto.Web.Core.Controllers;
using Proyecto.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Proyecto.WebApi.Controllers
{
    public class CatalogoController : BaseApiController
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpPost]
        [ActionName("listParentesco")]
        public ApiResult GetListParentesco()
        {
            string codError = "";
            string mensajeRetorno = "";
            string status;
            IList<Parentesco> lista = null;

            try
            {
                lista = _catalogoService.GetListParentesco(out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, lista);
        }

        [HttpPost]
        [ActionName("listSexo")]
        public ApiResult GetListSexo()
        {
            string codError = "";
            string mensajeRetorno = "";
            string status;
            IList<Sexo> lista = null;

            try
            {
                lista = _catalogoService.GetListSexo(out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, lista);
        }

        [HttpPost]
        [ActionName("listNacionalidad")]
        public ApiResult GetListNacionalidad()
        {
            string codError = "";
            string mensajeRetorno = "";
            string status;
            IList<Nacionalidad> lista = null;

            try
            {
                lista = _catalogoService.GetListNacionalidad(out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, lista);
        }

        [HttpPost]
        [ActionName("listProvincia")]
        public ApiResult GetListProvincia()
        {
            string codError = "";
            string mensajeRetorno = "";
            string status;
            IList<Provincia> lista = null;

            try
            {
                lista = _catalogoService.GetListProvincia(out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, lista);
        }

        [HttpPost]
        [ActionName("listCiudad")]
        public ApiResult GetListCiudad()
        {
            string codError = "";
            string mensajeRetorno = "";
            string status;
            IList<Ciudad> lista = null;

            try
            {
                lista = _catalogoService.GetListCiudad(out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, lista);
        }
    }
}