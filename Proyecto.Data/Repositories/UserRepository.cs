using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Enumerations;
using Proyecto.Core.Models.Auth;
//using Proyecto.Data.WsNeoTrack;
//using Proyecto.Data.Helpers;
using System;
using System.Configuration;


namespace Proyecto.Data.Repositories
{
    public class UserRepository : IUserRepository, IRepository
    {
        //private readonly NeoTrackService _wService;

        public UserRepository()
        {
            var url = ConfigurationManager.AppSettings.Get("NeoTrackserviceUrl");
            //_wService = new NeoTrackService();
        }

        public User FindUser(
            string userName, string password, string ipAddress,
            out string codError, out string mensajeRetorno)
        {
            User user = null;
            try
            {
                if (userName == "admin" && password == "123456")
                {
                    user = new User
                    {
                        Username = "admin",
                        Nombre = "Carlos",
                        Ciudad = "Guayaquil",
                        Perfil = (TipoPerfil)1,
                        Producto = "Proyecto"
                    };

                    codError = "000";
                    mensajeRetorno = "Login Ok";
                }
                else
                {
                    codError = "001";
                    mensajeRetorno = "Usuario o Contraseña Inválidos";
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
