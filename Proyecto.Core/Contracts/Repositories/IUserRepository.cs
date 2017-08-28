using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proyecto.Core.Models.Auth;

namespace Proyecto.Core.Contracts.Repositories
{
    public interface IUserRepository : IRepository
    {
        bool Registro(User usuario, out string codError, out string mensajeRetorno);
        User FindUser(string userName, string password, string ipAddress, out string codError, out string mensajeRetorno);
    }
}
