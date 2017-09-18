using Proyecto.Core.Models;

namespace Proyecto.Core.Contracts.Services
{
    public interface IEmailService : IService
    {
        bool SendEmail(Email email, out string codError, out string mensajeRetorno);
    }
}
