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
        [ActionName("listChildren")]
        public ApiResult GetListChildren(int IdRepresentante)
        {
            string codError;
            string mensajeRetorno;
            string status;
            IList<Children> lista = null;

            try
            {
                lista = _childrenService.GetListChildren(IdRepresentante, out codError, out mensajeRetorno);
                status = JsonStatus.Success();
                codError = "000";
                mensajeRetorno = $"{lista.Count} niños en total.";
            }
            catch (Exception exception)
            {
                status = JsonStatus.Error();
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return new ApiResult(status, codError, mensajeRetorno, lista);
        }

        //[HttpPost]
        //[ActionName("get")]
        //public ApiResult GetActividad(int idActividad)
        //{
        //    string codError;
        //    string message = "";
        //    string status;
        //    Actividad actividad = null;

        //    try
        //    {
        //        actividad = _actividadService.GetActividad(idActividad);
        //        status = JsonStatus.Success();
        //        codError = "000";
        //        message = $"Actividad{actividad}";

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Consulta de Actividad", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));

        //    }
        //    catch (Exception exception)
        //    {
        //        status = JsonStatus.Error();
        //        codError = "999";
        //        message = exception.Message;
        //        this.LogService.Insertar(new Log(User.Identity.Name, "Consulta de Actividad Fallido", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));
        //    }

        //    return new ApiResult(status, codError, message, actividad);
        //}

        //[HttpPost]
        //[ActionName("post")]
        //public ApiResult InsertaActividad(Actividad actividad)
        //{
        //    if (actividad == null) throw new ArgumentNullException(nameof(actividad));

        //    string codError;            
        //    string mensajeRetorno = "";
        //    string status;
        //    var result = false;
        //    try
        //    {
        //        var productos = _productoService.GetList();
        //        Producto producto = productos.FirstOrDefault(p => p.Codigo == NeoTrackClaims.Producto);

        //        if (producto == null) throw new ArgumentNullException(nameof(producto));

        //        actividad.IdProducto = producto.Id;

        //        result = _actividadService.InsertarActividad(actividad, out codError, out mensajeRetorno);
        //        status = result
        //            ? JsonStatus.Success() 
        //            : JsonStatus.Error();

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Ingreso de Actividad", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));

        //    }
        //    catch (Exception exception)
        //    {
        //        status = JsonStatus.Error();
        //        codError = "999";
        //        mensajeRetorno = exception.Message;

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Ingreso de Actividad Fallido", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));
        //    }
            
        //    return new ApiResult(status, codError, mensajeRetorno, result);
        //}

        //[HttpPost]
        //[ActionName("actualizar")]
        //public ApiResult ActualizarActividad(Actividad actividad)
        //{
        //    if (actividad == null) throw new ArgumentNullException(nameof(actividad));

        //    string codError;
        //    string mensajeRetorno = "";
        //    string status;
        //    var result = false;
        //    try
        //    {
        //        result = _actividadService.ActualizarActividad(actividad, out codError, out mensajeRetorno);
        //        status = result
        //            ? JsonStatus.Success()
        //            : JsonStatus.Error();

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Actualización de Actividad", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));

        //    }
        //    catch (Exception exception)
        //    {
        //        status = JsonStatus.Error();
        //        codError = "999";
        //        mensajeRetorno = exception.Message;

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Actualización de Actividad", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));
        //    }

        //    return new ApiResult(status, codError, mensajeRetorno, result);
        //}

        //[HttpPost]
        //[ActionName("eliminar")]
        //public ApiResult EliminarActividad(int id, string usuarioModificacion)
        //{
        //    if (id == 0) throw new ArgumentNullException(nameof(id));

        //    string codError;
        //    string mensajeRetorno = "";
        //    string status;
        //    var result = false;
        //    try
        //    {
        //        result = _actividadService.EliminarActividad(id, usuarioModificacion, out codError, out mensajeRetorno);
        //        status = result
        //            ? JsonStatus.Success()
        //            : JsonStatus.Error();

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Eliminación de Actividad", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));

        //    }
        //    catch (Exception exception)
        //    {
        //        status = JsonStatus.Error();
        //        codError = "999";
        //        mensajeRetorno = exception.Message;

        //        this.LogService.Insertar(new Log(User.Identity.Name, "Eliminación de Actividad", GetIp4Address(),
        //            Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), NeoTrackClaims.Opid, codError));
        //    }

        //    return new ApiResult(status, codError, mensajeRetorno, result);
        //}
    }
}