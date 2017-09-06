using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using Proyecto.Web.Core.Controllers;
using Proyecto.Web.Core.Models;
using System.Web;

namespace Proyecto.WebApi.Controllers
{
    public class ChildrenController : BaseApiController
    {
        private readonly IChildrenService _childrenService;

        public ChildrenController(IChildrenService childrenService)
        {
            _childrenService = childrenService;
        }

        [HttpPost]
        [ActionName("getList")]
        public ApiResult GetListChildren(int idRepresentante)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<Children> listaChildren = null;

            try
            {
                listaChildren = _childrenService.GetListChildren(idRepresentante, out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, listaChildren);
        }

        [HttpPost]
        [ActionName("get")]
        public ApiResult GetChildren(int idChildren)
        {
            string codError;
            string mensajeRetorno;
            string status;

            Children children = null;

            try
            {
                children = _childrenService.GetChildren(idChildren, out codError, out mensajeRetorno);
                status = JsonStatus.Success();
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, children);
        }

        [HttpPost]
        [ActionName("save")]
        public ApiResult GuardarChildren(Children children)
        {
            string codError;
            string mensajeRetorno;
            string status;
            var result = false;
            try
            {
                result = _childrenService.GuardarChildren(children, out codError, out mensajeRetorno);

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

        [HttpPost]
        [ActionName("edit")]
        public ApiResult ActualizarChildren(Children children)
        {
            string codError;
            string mensajeRetorno;
            string status;
            var result = false;
            try
            {
                result = _childrenService.ActualizarChildren(children, out codError, out mensajeRetorno);

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

        [HttpPost]
        [ActionName("delete")]
        public ApiResult EliminarChildren(int idChildren)
        {
            string codError;
            string mensajeRetorno;
            string status;
            var result = false;
            try
            {
                result = _childrenService.EliminarChildren(idChildren, out codError, out mensajeRetorno);

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