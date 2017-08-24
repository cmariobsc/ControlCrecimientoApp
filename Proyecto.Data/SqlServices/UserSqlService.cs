using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.SqlServices;
using System.Data;

namespace Proyecto.Data.SqlServices
{
    public class UserSqlService : IUserSqlService, ISqlService
    {
        private Database _database;
        public UserSqlService()
        {
            var _connection = new SqlConnection();
            _database = _connection.InitDatabase();
        }

        public void AutenticarUsuario(string usuario, string contrasenia, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_AutenticarUsuario]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@Usuario", DbType.String, usuario);
            _database.AddInParameter(command, "@Contrasenia", DbType.String, contrasenia);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            _database.ExecuteNonQuery(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();
        }

        public DataSet ConsultarUsuario(string usuario, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarUsuario]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@Usuario", DbType.String, usuario);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }
    }
}
