using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using Proyecto.Web.Core.Controllers;
using Proyecto.Web.Core.Models;
using System;
using System.Web.Http;

namespace Proyecto.WebApi.Controllers
{
    public class RepresentanteController : BaseApiController
    {
        private readonly IRepresentanteService _representanteService;

        public RepresentanteController(IRepresentanteService representanteService)
        {
            _representanteService = representanteService;
        }

        [HttpPost]
        [ActionName("get")]
        public ApiResult GetRepresentante(int idUsuario)
        {
            string codError;
            string mensajeRetorno;
            string status;

            Representante representante = null;

            try
            {
                representante = _representanteService.GetRepresentante(idUsuario, out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, representante);
        }

        [HttpPost]
        [ActionName("edit")]
        public ApiResult ActualizarRepresentante(Representante representante)
        {
            string codError;
            string mensajeRetorno;
            string status;
            var result = false;
            try
            {
                result = _representanteService.ActualizarRepresentante(representante, out codError, out mensajeRetorno);

                status = result
                    ? JsonStatus.Success()
                    : JsonStatus.Error();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, result);
        }
    }
}