using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.SqlServices;
using System.Data;

namespace Proyecto.Data.SqlServices
{
    public class CatalogoSqlService : ICatalogoSqlService, ISqlService
    {
        private Database _database;
        public CatalogoSqlService()
        {
            var _connection = new SqlConnection();
            _database = _connection.InitDatabase();
        }

        public DataSet GetListParentesco(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarParentesco]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            command.Dispose();

            return result;
        }
        public DataSet GetListSexo(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarSexo]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            command.Dispose();

            return result;
        }
        public DataSet GetListNacionalidad(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarNacionalidad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            command.Dispose();

            return result;
        }
        public DataSet GetListProvincia(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarProvincia]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            command.Dispose();

            return result;
        }
        public DataSet GetListCiudad(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarCiudad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            command.Dispose();

            return result;
        }

        public DataSet GetListDoctor(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarDoctor]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            command.Dispose();

            return result;
        }
    }
}
