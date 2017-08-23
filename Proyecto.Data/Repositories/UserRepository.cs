using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Enumerations;
using Proyecto.Core.Models.Auth;
using System;
using System.Data;

namespace Proyecto.Data.Repositories
{
    public class UserRepository : IUserRepository, IRepository
    {
        private Database _database;

        public UserRepository()
        {
            var _conexion = new Conexion();
            _database = _conexion.InitDatabase();
        }

        public User FindUser(
            string userName, string password, string ipAddress,
            out string codError, out string mensajeRetorno)
        {
            User user = null;
            try
            {
                var storedProcedure = "[dbo].[SP_AutenticarUsuario]";

                var command = _database.GetStoredProcCommand(storedProcedure);
                command.CommandType = CommandType.StoredProcedure;

                _database.AddInParameter(command, "@Usuario", DbType.String, userName);
                _database.AddInParameter(command, "@Contrasenia", DbType.String, password);
                _database.AddOutParameter(command, "@codError", DbType.String, 3);
                _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

                _database.ExecuteNonQuery(command);

                codError = _database.GetParameterValue(command, "@codError").ToString();
                mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

                if (codError == "000")
                {
                    user = new User
                    {
                        Username = "admin",
                        Nombre = "Carlos",
                        Ciudad = "Guayaquil",
                        Perfil = (TipoPerfil)1,
                        Producto = "Proyecto"
                    };
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
