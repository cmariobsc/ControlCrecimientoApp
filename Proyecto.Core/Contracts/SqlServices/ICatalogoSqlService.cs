using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface ICatalogoSqlService : ISqlService
    {
        DataSet ConsultarParentesco(out string codError, out string mensajeRetorno);
        DataSet ConsultarNacionalidad(out string codError, out string mensajeRetorno);
        DataSet ConsultarProvincia(out string codError, out string mensajeRetorno);
        DataSet ConsultarCiudad(out string codError, out string mensajeRetorno);
    }
}
