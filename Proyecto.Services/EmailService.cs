using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;

namespace Proyecto.Services
{
    public class EmailService : IEmailService, IService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }
        public bool SendEmail(Email Email, out string codError, out string mensajeRetorno)
        {
            return _emailRepository.SendEmail(Email, out codError, out mensajeRetorno);
        }
    }
}
