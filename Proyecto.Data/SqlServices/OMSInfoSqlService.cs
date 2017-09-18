using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.SqlServices;
using System.Data;

namespace Proyecto.Data.SqlServices
{
    public class OMSInfoSqlService : IOMSInfoSqlService, ISqlService
    {
        private Database _database;
        public OMSInfoSqlService()
        {
            var _connection = new SqlConnection();
            _database = _connection.InitDatabase();
        }
        
        public DataSet GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarOMSTallaxEdad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@idSexo", DbType.Int32, idSexo);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public DataSet GetListOMSPesoxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarOMSPesoxEdad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@idSexo", DbType.Int32, idSexo);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public DataSet GetListOMSIMCxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarOMSIMCxEdad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@idSexo", DbType.Int32, idSexo);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public DataSet GetListOMSPCxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarOMSPCxEdad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@idSexo", DbType.Int32, idSexo);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public DataSet GetListOMSPMBxEdad(int idSexo, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarOMSPMBxEdad]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@idSexo", DbType.Int32, idSexo);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }
    }
}
