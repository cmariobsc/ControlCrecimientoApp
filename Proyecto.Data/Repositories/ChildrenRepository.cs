using System;
using System.Collections.Generic;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models;
using Proyecto.Data.SqlServices;
using System.Data;

namespace Bg.NeoTrack.Data.Repositories
{
    public class ChildrenRepository : IChildrenRepository, IRepository
    {
        private readonly ChildrenSqlService _childrenSqlService;

        public ChildrenRepository()
        {
            _childrenSqlService = new ChildrenSqlService();
        }

        public IList<Children> GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno)
        {
            var listaChildren = new List<Children>();
            try
            {
                var response = _childrenSqlService.GetListChildren(idRepresentante, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var children = new Children
                    {
                        Identificacion = dataRow["Identificacion"].ToString(),
                        Nombres = dataRow["Nombres"].ToString(),
                        Apellidos = dataRow["Apellidos"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dataRow["FechaNacimiento"].ToString()),
                        Edad = Convert.ToInt32(dataRow["Edad"].ToString()),
                        Talla = Convert.ToDecimal(dataRow["Talla"].ToString()),
                        Peso = Convert.ToInt32(dataRow["Peso"].ToString()),
                        FechaCreacion = Convert.ToDateTime(dataRow["FechaCreacion"].ToString()),
                        FechaModificacion = Convert.ToDateTime(dataRow["FechaModificacion"].ToString()),
                        IdRepresentante = Convert.ToInt32(dataRow["IdRepresentante"]),
                        IdNacionalidad = Convert.ToInt32(dataRow["IdNacionalidad"].ToString()),
                    };

                    listaChildren.Add(children);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaChildren;
        }

        public bool GuardarChildren(Children children, out string codError, out string mensajeRetorno)
        {
            var response = false;
            try
            {
                _childrenSqlService.GuardarChildren(children, out codError, out mensajeRetorno);
                response = true;
            }
            catch (Exception exception)
            {
                response = false;
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return response;
        }

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
