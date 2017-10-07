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
                        IdChildren = Convert.ToInt32(dataRow["IdChildren"]),
                        Identificacion = dataRow["Identificacion"].ToString(),
                        Nombres = dataRow["Nombres"].ToString(),
                        Apellidos = dataRow["Apellidos"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dataRow["FechaNacimiento"].ToString()),
                        EdadAnios = Convert.ToInt32(dataRow["EdadAnios"].ToString()),
                        EdadMeses = Convert.ToInt32(dataRow["EdadMeses"].ToString()),
                        EdadTotalMeses = Convert.ToInt32(dataRow["EdadTotalMeses"].ToString()),
                        Talla = Convert.ToDecimal(dataRow["Talla"].ToString()),
                        Peso = Convert.ToDecimal(dataRow["Peso"].ToString()),
                        IMC = Convert.ToDecimal(dataRow["IMC"].ToString()),
                        DetalleIMC = dataRow["DetalleIMC"].ToString(),
                        PerimCefalico = Convert.ToDecimal(dataRow["PerimCefalico"].ToString()),
                        PerimMedioBrazo = Convert.ToDecimal(dataRow["PerimMedioBrazo"].ToString()),
                        Observaciones = dataRow["Observaciones"].ToString(),
                        FechaCreacion = Convert.ToDateTime(dataRow["FechaCreacion"].ToString()),
                        FechaModificacion = Convert.ToDateTime(dataRow["FechaModificacion"].ToString()),
                        IdSexo = Convert.ToInt32(dataRow["IdSexo"]),
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

        public Children GetChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            Children children = null;
            try
            {
                var response = _childrenSqlService.GetChildren(idChildren, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    children = new Children
                    {
                        IdChildren = Convert.ToInt32(dataRow["IdChildren"]),
                        Identificacion = dataRow["Identificacion"].ToString(),
                        Nombres = dataRow["Nombres"].ToString(),
                        Apellidos = dataRow["Apellidos"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dataRow["FechaNacimiento"].ToString()),
                        EdadAnios = Convert.ToInt32(dataRow["EdadAnios"].ToString()),
                        EdadMeses = Convert.ToInt32(dataRow["EdadMeses"].ToString()),
                        EdadTotalMeses = Convert.ToInt32(dataRow["EdadTotalMeses"].ToString()),
                        Talla = Convert.ToDecimal(dataRow["Talla"].ToString()),
                        Peso = Convert.ToDecimal(dataRow["Peso"].ToString()),
                        IMC = Convert.ToDecimal(dataRow["IMC"].ToString()),
                        DetalleIMC = dataRow["DetalleIMC"].ToString(),
                        PerimCefalico = Convert.ToDecimal(dataRow["PerimCefalico"].ToString()),
                        PerimMedioBrazo = Convert.ToDecimal(dataRow["PerimMedioBrazo"].ToString()),
                        Observaciones = dataRow["Observaciones"].ToString(),
                        FechaCreacion = Convert.ToDateTime(dataRow["FechaCreacion"].ToString()),
                        FechaModificacion = Convert.ToDateTime(dataRow["FechaModificacion"].ToString()),
                        IdSexo = Convert.ToInt32(dataRow["IdSexo"]),
                        IdRepresentante = Convert.ToInt32(dataRow["IdRepresentante"]),
                        IdNacionalidad = Convert.ToInt32(dataRow["IdNacionalidad"].ToString()),
                    };
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return children;
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

        public bool ActualizarChildren(Children children, out string codError, out string mensajeRetorno)
        {
            var response = false;
            try
            {
                _childrenSqlService.ActualizarChildren(children, out codError, out mensajeRetorno);
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

        public bool EliminarChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            var response = false;
            try
            {
                _childrenSqlService.EliminarChildren(idChildren, out codError, out mensajeRetorno);
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

        public IList<HistorialChildren> GetListHistorialChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            var listaHistorialChildren = new List<HistorialChildren>();
            try
            {
                var response = _childrenSqlService.GetListHistorialChildren(idChildren, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    var historialChildren = new HistorialChildren
                    {
                        IdHistorialChildren = Convert.ToInt32(dataRow["IdHistorialChildren"]),
                        NombreCompleto = dataRow["NombreCompleto"].ToString(),
                        IdSexo = Convert.ToInt32(dataRow["IdSexo"].ToString()),
                        EdadAnios = Convert.ToInt32(dataRow["EdadAnios"].ToString()),
                        EdadMeses = Convert.ToInt32(dataRow["EdadMeses"].ToString()),
                        EdadTotalMeses = Convert.ToInt32(dataRow["EdadTotalMeses"].ToString()),
                        Talla = Convert.ToDecimal(dataRow["Talla"].ToString()),
                        Peso = Convert.ToDecimal(dataRow["Peso"].ToString()),
                        IMC = Convert.ToDecimal(dataRow["IMC"].ToString()),
                        DetalleIMC = dataRow["DetalleIMC"].ToString(),
                        PerimCefalico = Convert.ToDecimal(dataRow["PerimCefalico"].ToString()),
                        PerimMedioBrazo = Convert.ToDecimal(dataRow["PerimMedioBrazo"].ToString()),
                        Observaciones = dataRow["Observaciones"].ToString(),
                        FechaCreacion = Convert.ToDateTime(dataRow["FechaCreacion"].ToString()),
                        FechaModificacion = Convert.ToDateTime(dataRow["FechaModificacion"].ToString()),
                        IdChildren = Convert.ToInt32(dataRow["IdChildren"]),
                    };

                    listaHistorialChildren.Add(historialChildren);
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaHistorialChildren;
        }
    }
}
