using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models.Auth;
using Proyecto.Data.SqlServices;
using System;
using System.Data;

namespace Proyecto.Data.Repositories
{
    public class UserRepository : IUserRepository, IRepository
    {
        private readonly UserSqlService _userSqlService;

        public UserRepository()
        {
            _userSqlService = new UserSqlService();
        }

        public bool Registro(User usuario, out string codError, out string mensajeRetorno)
        {
            var response = false;
            try
            {
                _userSqlService.Registro(usuario, out codError, out mensajeRetorno);
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

        public User FindUser(
            string usuario, string contrasenia, string ipAddress,
            out string codError, out string mensajeRetorno)
        {
            User user = null;
            try
            {
                _userSqlService.AutenticarUsuario(usuario, contrasenia, out codError, out mensajeRetorno);

                if (codError == "000")
                {
                    var response = _userSqlService.ConsultarUsuario(usuario, out codError, out mensajeRetorno);

                    foreach (DataRow dataRow in response.Tables[0].Rows)
                    {
                        user = new User
                        {
                            IdUsuario = Convert.ToInt32(dataRow["IdUsuario"]),
                            Usuario = dataRow["Usuario"].ToString(),
                            Nombres = dataRow["Nombres"].ToString(),
                            Apellidos = dataRow["Apellidos"].ToString(),
                            Email = dataRow["Email"].ToString(),
                        };
                    }
                }
            }
            catch (Exception exception)
            {
                codError = "999";
                mensajeRetorno = exception.Message;
            }

            return user;
        }
    }
}
