﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.SqlServices;
using Proyecto.Core.Models;
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
        
        public DataSet GetListOMSTallaxEdadMasculino(out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarOMSTallaxEdadMasculino]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }
    }
}
