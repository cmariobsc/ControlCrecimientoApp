using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using Proyecto.Web.Core.Controllers;
using Proyecto.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Proyecto.WebApi.Controllers
{
    public class OMSInfoController : BaseApiController
    {
        private readonly IOMSInfoService _omsInfoService;

        public OMSInfoController(IOMSInfoService omsInfoService)
        {
            _omsInfoService = omsInfoService;
        }

        [HttpPost]
        [ActionName("getListTallaxEdad")]
        public ApiResult GetListOMSTallaxEdad(int idSexo)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<OMSCamposIndicadores> lista = null;

            try
            {
                lista = _omsInfoService.GetListOMSTallaxEdad(idSexo, out codError, out mensajeRetorno);
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
        [ActionName("getListPesoxEdad")]
        public ApiResult GetListOMSPesoxEdad(int idSexo)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<OMSCamposIndicadores> lista = null;

            try
            {
                lista = _omsInfoService.GetListOMSPesoxEdad(idSexo, out codError, out mensajeRetorno);
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
        [AllowAnonymous]
        [HttpPost]
        [ActionName("getListIMCxEdad")]
        public ApiResult GetListOMSIMCxEdad(int idSexo)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<OMSCamposIndicadores> lista = null;

            try
            {
                lista = _omsInfoService.GetListOMSIMCxEdad(idSexo, out codError, out mensajeRetorno);
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
        [ActionName("getListPCxEdad")]
        public ApiResult GetListOMSPCxEdad(int idSexo)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<OMSCamposIndicadores> lista = null;

            try
            {
                lista = _omsInfoService.GetListOMSPCxEdad(idSexo, out codError, out mensajeRetorno);
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
        [ActionName("getListPMBxEdad")]
        public ApiResult GetListOMSPMBxEdad(int idSexo)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<OMSCamposIndicadores> lista = null;

            try
            {
                lista = _omsInfoService.GetListOMSPMBxEdad(idSexo, out codError, out mensajeRetorno);
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