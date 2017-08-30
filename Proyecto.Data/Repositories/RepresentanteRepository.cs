using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models;
using Proyecto.Data.SqlServices;
using System;
using System.Data;

namespace Proyecto.Data.Repositories
{
    public class RepresentanteRepository : IRepresentanteRepository, IRepository
    {
        private readonly RepresentanteSqlService _representanteSqlService;

        public RepresentanteRepository()
        {
            _representanteSqlService = new RepresentanteSqlService();
        }

        public Representante GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno)
        {
            Representante representante = null;
            try
            {
                var response = _representanteSqlService.GetRepresentante(idUsuario, out codError, out mensajeRetorno);

                foreach (DataRow dataRow in response.Tables[0].Rows)
                {
                    representante = new Representante
                    {
                        IdRepresentante = Convert.ToInt32(dataRow["IdRepresentante"]),
                        Identificacion = dataRow["Identificacion"].ToString(),
                        Nombres = dataRow["Nombres"].ToString(),
                        Apellidos = dataRow["Apellidos"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dataRow["FechaNacimiento"].ToString()),
                        Edad = Convert.ToInt32(dataRow["Edad"].ToString()),
                        Direccion = dataRow["Direccion"].ToString(),
                        Email = dataRow["Email"].ToString(),
                        Telefono1 = dataRow["Telefono1"].ToString(),
                        Telefono2 = dataRow["Telefono2"].ToString(),
                        Talla = Convert.ToDecimal(dataRow["Talla"].ToString()),
                        Peso = Convert.ToInt32(dataRow["Peso"].ToString()),
                        NHijos = Convert.ToInt32(dataRow["NHijos"].ToString()),
                        IdUsuario = Convert.ToInt32(dataRow["IdUsuario"].ToString()),
                        IdParentesco = Convert.ToInt32(dataRow["IdParentesco"].ToString()),
                        IdNacionalidad = Convert.ToInt32(dataRow["IdNacionalidad"].ToString()),
                        IdProvincia = Convert.ToInt32(dataRow["IdProvincia"].ToString()),
                        IdCiudad = Convert.ToInt32(dataRow["IdCiudad"].ToString()),
                    };
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return representante;
        }
    }
}
