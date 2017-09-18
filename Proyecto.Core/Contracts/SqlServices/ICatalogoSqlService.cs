using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface ICatalogoSqlService : ISqlService
    {
        DataSet GetListParentesco(out string codError, out string mensajeRetorno);
        DataSet GetListSexo(out string codError, out string mensajeRetorno);
        DataSet GetListNacionalidad(out string codError, out string mensajeRetorno);
        DataSet GetListProvincia(out string codError, out string mensajeRetorno);
        DataSet GetListCiudad(out string codError, out string mensajeRetorno);
        DataSet GetListDoctor(out string codError, out string mensajeRetorno);
    }
}
