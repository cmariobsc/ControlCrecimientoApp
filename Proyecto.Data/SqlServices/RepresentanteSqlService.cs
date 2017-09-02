using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.SqlServices;
using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Data.SqlServices
{
    public class RepresentanteSqlService : IRepresentanteSqlService, ISqlService
    {
        private Database _database;
        public RepresentanteSqlService()
        {
            var _connection = new SqlConnection();
            _database = _connection.InitDatabase();
        }

        public DataSet GetRepresentante(int idUsuario, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarRepresentante]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdUsuario", DbType.Int32, idUsuario);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public void ActualizarRepresentante(Representante representante, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ActualizarRepresentante]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdRepresentante", DbType.String, representante.IdRepresentante);
            _database.AddInParameter(command, "@Identificacion", DbType.String, representante.Identificacion);
            _database.AddInParameter(command, "@Nombres", DbType.String, representante.Nombres);
            _database.AddInParameter(command, "@Apellidos", DbType.String, representante.Apellidos);
            _database.AddInParameter(command, "@FechaNacimiento", DbType.DateTime, representante.FechaNacimiento);
            _database.AddInParameter(command, "@Edad", DbType.String, representante.Edad);
            _database.AddInParameter(command, "@Direccion", DbType.String, representante.Direccion);
            _database.AddInParameter(command, "@Email", DbType.String, representante.Email);
            _database.AddInParameter(command, "@Telefono1", DbType.String, representante.Telefono1);
            _database.AddInParameter(command, "@Telefono2", DbType.String, representante.Telefono2);
            _database.AddInParameter(command, "@Talla", DbType.String, representante.Talla);
            _database.AddInParameter(command, "@Peso", DbType.String, representante.Peso);
            _database.AddInParameter(command, "@NHijos", DbType.String, representante.NHijos);
            _database.AddInParameter(command, "@IdParentesco", DbType.String, representante.IdParentesco);
            _database.AddInParameter(command, "@IdNacionalidad", DbType.String, representante.IdNacionalidad);
            _database.AddInParameter(command, "@IdProvincia", DbType.String, representante.IdProvincia);
            _database.AddInParameter(command, "@IdCiudad", DbType.String, representante.IdCiudad);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            _database.ExecuteNonQuery(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();
        }
    }
}
