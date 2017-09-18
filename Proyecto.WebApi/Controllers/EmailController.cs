using System;
using System.Web.Http;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using Proyecto.Web.Core.Controllers;
using Proyecto.Web.Core.Models;

namespace Proyecto.WebApi.Controllers
{
    public class EmailController : BaseApiController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [ActionName("send")]
        public ApiResult SendEmail(Email email)
        {
            string codError;
            string mensajeRetorno;
            string status;
            var result = false;
            try
            {
                result = _emailService.SendEmail(email, out codError, out mensajeRetorno);

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