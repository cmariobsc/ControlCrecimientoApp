using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.SqlServices;
using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Data.SqlServices
{
    public class ChildrenSqlService : IChildrenSqlService, ISqlService
    {
        private Database _database;
        public ChildrenSqlService()
        {
            var _connection = new SqlConnection();
            _database = _connection.InitDatabase();
        }
        
        public DataSet GetListChildren(int idRepresentante, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarChildren]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdRepresentante", DbType.Int32, idRepresentante);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public DataSet GetChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ConsultarChildren]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdChildren", DbType.Int32, idChildren);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }

        public void GuardarChildren(Children children, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_GuardarChildren]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@FechaCreacion", DbType.DateTime, children.FechaCreacion);
            _database.AddInParameter(command, "@Identificacion", DbType.String, children.Identificacion);
            _database.AddInParameter(command, "@Nombres", DbType.String, children.Nombres);
            _database.AddInParameter(command, "@Apellidos", DbType.String, children.Apellidos);
            _database.AddInParameter(command, "@FechaNacimiento", DbType.DateTime, children.FechaNacimiento);
            _database.AddInParameter(command, "@EdadAnios", DbType.Int32, children.EdadAnios);
            _database.AddInParameter(command, "@EdadMeses", DbType.Int32, children.EdadMeses);
            _database.AddInParameter(command, "@EdadTotalMeses", DbType.Int32, children.EdadTotalMeses);
            _database.AddInParameter(command, "@Talla", DbType.Decimal, children.Talla);
            _database.AddInParameter(command, "@Peso", DbType.Decimal, children.Peso);
            _database.AddInParameter(command, "@IMC", DbType.Decimal, children.IMC);
            _database.AddInParameter(command, "@DetalleIMC", DbType.String, children.DetalleIMC);
            _database.AddInParameter(command, "@PerimCefalico", DbType.Decimal, children.PerimCefalico);
            _database.AddInParameter(command, "@PerimMedioBrazo", DbType.Decimal, children.PerimMedioBrazo);
            _database.AddInParameter(command, "@Observaciones", DbType.String, children.Observaciones);
            _database.AddInParameter(command, "@IdSexo", DbType.Int32, children.IdSexo);
            _database.AddInParameter(command, "@IdRepresentante", DbType.Int32, children.IdRepresentante);
            _database.AddInParameter(command, "@IdNacionalidad", DbType.Int32, children.IdNacionalidad);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            _database.ExecuteNonQuery(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();
        }

        public void ActualizarChildren(Children children, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ActualizarChildren]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdChildren", DbType.Int32, children.IdChildren);
            _database.AddInParameter(command, "@Identificacion", DbType.String, children.Identificacion);
            _database.AddInParameter(command, "@Nombres", DbType.String, children.Nombres);
            _database.AddInParameter(command, "@Apellidos", DbType.String, children.Apellidos);
            _database.AddInParameter(command, "@FechaNacimiento", DbType.DateTime, children.FechaNacimiento);
            _database.AddInParameter(command, "@EdadAnios", DbType.Int32, children.EdadAnios);
            _database.AddInParameter(command, "@EdadMeses", DbType.Int32, children.EdadMeses);
            _database.AddInParameter(command, "@EdadTotalMeses", DbType.Int32, children.EdadTotalMeses);
            _database.AddInParameter(command, "@Talla", DbType.Decimal, children.Talla);
            _database.AddInParameter(command, "@Peso", DbType.Decimal, children.Peso);
            _database.AddInParameter(command, "@IMC", DbType.Decimal, children.IMC);
            _database.AddInParameter(command, "@DetalleIMC", DbType.String, children.DetalleIMC);
            _database.AddInParameter(command, "@PerimCefalico", DbType.Decimal, children.PerimCefalico);
            _database.AddInParameter(command, "@PerimMedioBrazo", DbType.Decimal, children.PerimMedioBrazo);
            _database.AddInParameter(command, "@Observaciones", DbType.String, children.Observaciones);
            _database.AddInParameter(command, "@FechaCreacion", DbType.DateTime, children.FechaCreacion);
            _database.AddInParameter(command, "@IdSexo", DbType.Int32, children.IdSexo);
            _database.AddInParameter(command, "@IdNacionalidad", DbType.Int32, children.IdNacionalidad);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            _database.ExecuteNonQuery(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();
        }

        public void EliminarChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_EliminarChildren]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdChildren", DbType.Int32, idChildren);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            _database.ExecuteNonQuery(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();
        }

        public DataSet GetListHistorialChildren(int idChildren, out string codError, out string mensajeRetorno)
        {
            var storedProcedure = "[dbo].[SP_ListarHistorialChildren]";

            var command = _database.GetStoredProcCommand(storedProcedure);
            command.CommandType = CommandType.StoredProcedure;

            _database.AddInParameter(command, "@IdChildren", DbType.Int32, idChildren);
            _database.AddOutParameter(command, "@codError", DbType.String, 3);
            _database.AddOutParameter(command, "@mensajeRetorno", DbType.String, 100);

            var result = _database.ExecuteDataSet(command);

            codError = _database.GetParameterValue(command, "@codError").ToString();
            mensajeRetorno = _database.GetParameterValue(command, "@mensajeRetorno").ToString();

            return result;
        }
    }
}
