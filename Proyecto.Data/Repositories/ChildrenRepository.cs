using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models;
//using Proyecto.Data.Helpers;

namespace Bg.NeoTrack.Data.Repositories
{
    public class ChildrenRepository : IChildrenRepository, IRepository
    {
        //private readonly ProyectoService _wService;

        public ChildrenRepository()
        {
            var url = ConfigurationManager.AppSettings.Get("NeoTrackserviceUrl");
            //_wService = new NeoTrackService();
        }

        //public Children GetChildren(int idChildren)
        //{
        //    string codError;
        //    string mensajeRetorno;

        //    var Children = new Children();

        //    var response = _wService.ConsultaChildren(idChildren, out codError, out mensajeRetorno);

        //    foreach (DataRow dataRow in response.Tables[0].Rows)
        //    {
        //        Children = ChildrenHelper.WsChildrenToChildren(dataRow);
        //    }

        //    return Children;
        //}

        public IList<Children> GetListChildren(int IdRepresentante, out string codError, out string mensajeRetorno)
        {
            var listaChildren = new List<Children>();
            try
            {
                for (var i = 0; i < 2; i++)
                {
                    listaChildren.Add(new Children
                    {
                        IdChildren = i,
                        Identificacion = "Value_" + i,
                        IdNacionalidad = i,
                        Nombres = "Value_" + i,
                        Apellidos = "Value_" + i,
                        FechaNacimiento = new DateTime(),
                        Edad = i,
                        Talla = i,
                        Peso = i
                    });
                }
                codError = "000";
                mensajeRetorno = "Consulta Ok";
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaChildren;
        }

        //public bool InsertarChildren(Children Children, out string codError, out string mensajeRetorno)
        //{
        //    var response = false;
        //    try
        //    {
        //        var request = ChildrenHelper.ChildrenToWsChildren(Children);
        //        response = _wService.CrearChildren(request, out codError, out mensajeRetorno);
        //    }
        //    catch (Exception exception)
        //    {
        //        codError = "999";
        //        mensajeRetorno = exception.Message;
        //    }

        //    return response;
        //}

        //public bool ActualizarChildren(Children Children, out string codError, out string mensajeRetorno)
        //{
        //    var response = false;
        //    try
        //    {
        //        var request = ChildrenHelper.ChildrenToWsChildren(Children);
        //        response = _wService.ActualizarChildren(request, out codError, out mensajeRetorno);
        //    }
        //    catch (Exception exception)
        //    {
        //        codError = "999";
        //        mensajeRetorno = exception.Message;
        //    }

        //    return response;
        //}

        //public bool EliminarChildren(int id, string usuarioModificacion, out string codError, out string mensajeRetorno)
        //{
        //    var response = false;
        //    try
        //    {
        //        response = _wService.EliminarChildren(id, usuarioModificacion, out codError, out mensajeRetorno);
        //    }
        //    catch (Exception exception)
        //    {
        //        codError = "999";
        //        mensajeRetorno = exception.Message;
        //    }

        //    return response;
        //}
    }
}
