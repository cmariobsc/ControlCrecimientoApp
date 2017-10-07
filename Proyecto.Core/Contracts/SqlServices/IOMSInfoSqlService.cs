using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IOMSInfoSqlService : ISqlService
    {
        DataSet GetListOMSTallaxEdad(int idSexo, out string codError, out string mensajeRetorno);
        DataSet GetListOMSPesoxEdad(int idSexo, out string codError, out string mensajeRetorno);
        DataSet GetListOMSIMCxEdad(int idSexo, out string codError, out string mensajeRetorno);
        DataSet GetListOMSPCxEdad(int idSexo, out string codError, out string mensajeRetorno);
        DataSet GetListOMSPMBxEdad(int idSexo, out string codError, out string mensajeRetorno);
    }
}
