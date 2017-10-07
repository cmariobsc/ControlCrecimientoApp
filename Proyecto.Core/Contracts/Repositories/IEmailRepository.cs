using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IEmailRepository : IRepository
    {
        bool SendEmail(Email email, out string codError, out string mensajeRetorno);
    }
}
