using Proyecto.Core.Models;
using System.Data;

namespace Proyecto.Core.Contracts.SqlServices
{
    public interface IOMSInfoSqlService : ISqlService
    {
        DataSet GetListOMSTallaxEdadMasculino(out string codError, out string mensajeRetorno);
    }
}
