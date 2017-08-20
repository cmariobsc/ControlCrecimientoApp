using System;
using System.Web.Http;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models.Auth;
using Proyecto.Web.Core.Controllers;
using Proyecto.Web.Core.Models;

namespace Proyecto.WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [ActionName("isauth")]
        public ApiResult IsAuthenticated()
        {
            string codError;
            string mensajeRetorno;
            string status;
            var isAuth = false;

            try
            {
                isAuth = ProyectoClaims != null;

                status = JsonStatus.Success();
                codError = "000";
                mensajeRetorno = "";
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, isAuth);
        }

        [HttpGet]
        [ActionName("getUserData")]
        public ApiResult GetUserData(string username, string password)
        {
            string codError;
            string mensajeRetorno;
            string status;
            User user = null;

            try
            {
                user = _authService.FindUser(username, password, GetIp4Address(), out codError, out mensajeRetorno);

                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, user);
        }
    }
}