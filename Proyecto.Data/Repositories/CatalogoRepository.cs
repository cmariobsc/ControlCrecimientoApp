using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models.Catalogos;
using Proyecto.Data.SqlServices;
using System;
using System.Collections.Generic;
using System.Data;

namespace Proyecto.Data.Repositories
{
    public class CatalogoRepository : ICatalogoRepository, IRepository
    {
        private readonly CatalogoSqlService _catalogoSqlService;
        public CatalogoRepository()
        {
            _catalogoSqlService = new CatalogoSqlService();
        }
        public IList<Parentesco> GetListParentesco(out string codError, out string mensajeRetorno)
        {
            var listaParentesco = new List<Parentesco>();
            try
            {
                var response = _catalogoSqlService.GetListParentesco(out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    listaParentesco.Add(new Parentesco
                    {
                        IdParentesco = Convert.ToInt32(dataRow["IdParentesco"]),
                        Descripcion = dataRow["Descripcion"].ToString(),
                    });
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaParentesco;
        }
        public IList<Sexo> GetListSexo(out string codError, out string mensajeRetorno)
        {
            var listaSexo = new List<Sexo>();
            try
            {
                var response = _catalogoSqlService.GetListSexo(out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    listaSexo.Add(new Sexo
                    {
                        IdSexo = Convert.ToInt32(dataRow["IdSexo"]),
                        Descripcion = dataRow["Descripcion"].ToString(),
                    });
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaSexo;
        }
        public IList<Nacionalidad> GetListNacionalidad(out string codError, out string mensajeRetorno)
        {
            var listaNacionalidad = new List<Nacionalidad>();
            try
            {
                var response = _catalogoSqlService.GetListNacionalidad(out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    listaNacionalidad.Add(new Nacionalidad
                    {
                        IdNacionalidad = Convert.ToInt32(dataRow["IdNacionalidad"]),
                        Descripcion = dataRow["Descripcion"].ToString(),
                    });
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaNacionalidad;
        }
        public IList<Provincia> GetListProvincia(out string codError, out string mensajeRetorno)
        {
            var listaProvincia = new List<Provincia>();
            try
            {
                var response = _catalogoSqlService.GetListProvincia(out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    listaProvincia.Add(new Provincia
                    {
                        IdProvincia = Convert.ToInt32(dataRow["IdProvincia"]),
                        Descripcion = dataRow["Descripcion"].ToString(),
                        CodigoArea = dataRow["CodigoArea"].ToString(),
                    });
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaProvincia;
        }
        public IList<Ciudad> GetListCiudad(out string codError, out string mensajeRetorno)
        {
            var listaCiudad = new List<Ciudad>();
            try
            {
                var response = _catalogoSqlService.GetListCiudad(out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    listaCiudad.Add(new Ciudad
                    {
                        IdCiudad = Convert.ToInt32(dataRow["IdCiudad"]),
                        Descripcion = dataRow["Descripcion"].ToString(),
                        IdProvincia = Convert.ToInt32(dataRow["IdProvincia"]),
                    });
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaCiudad;
        }

        public IList<Doctor> GetListDoctor(out string codError, out string mensajeRetorno)
        {
            var listaDoctor = new List<Doctor>();
            try
            {
                var response = _catalogoSqlService.GetListDoctor(out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    listaDoctor.Add(new Doctor
                    {
                        IdDoctor = Convert.ToInt32(dataRow["IdDoctor"]),
                        Nombre = dataRow["Nombre"].ToString(),
                        Especialidad = dataRow["Especialidad"].ToString(),
                        LugarTrabajo = dataRow["LugarTrabajo"].ToString(),
                        IdProvincia = Convert.ToInt32(dataRow["IdProvincia"]),
                        IdCiudad = Convert.ToInt32(dataRow["IdCiudad"]),
                        Direccion = dataRow["Direccion"].ToString(),
                        Email = dataRow["Email"].ToString(),
                    });
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return listaDoctor;
        }
    }
}
