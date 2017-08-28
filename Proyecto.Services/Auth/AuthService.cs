using System.Collections.Generic;
using System.Linq;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;
using Proyecto.Core.Models.Auth;

namespace Proyecto.Services.Auth
{
    public class AuthService : IAuthService, IService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _authRepository;
        private readonly IParametroService _parametroService;

        public AuthService(
            ITokenRepository tokenRepository,
            IUserRepository authRepository,
            IParametroService parametroService)
        {
            _tokenRepository = tokenRepository;
            _authRepository = authRepository;
            _parametroService = parametroService;
        }

        public ClientApp FindClientApp(string clientId)
        {
            return _tokenRepository.FindClientApp(clientId);
        }

        public bool Registro(User usuario, out string codError, out string mensajeRetorno)
        {
            return _authRepository.Registro(usuario, out codError, out mensajeRetorno);
        }

        public User FindUser(string userName, string password, string ipAddress, out string codError, out string mensajeRetorno)
        {
            return _authRepository.FindUser(userName, password, ipAddress, out codError, out mensajeRetorno);
        }

        public bool AddRefreshToken(RefreshToken token)
        {
            return _tokenRepository.AddToken(token);
        }

        public RefreshToken FindToken(string tokenId)
        {
            return _tokenRepository.FindToken(tokenId);
        }

        public bool RemoveToken(string tokenId)
        {
            return _tokenRepository.RemoveToken(tokenId);
        }


        #region Acciones por Perfil
        public IList<Accion> FindAcciones(string perfil)
        {
            IList<Accion> acciones = new List<Accion>();

            var parametros = _parametroService.GetList();

            if (parametros != null && parametros.Count > 0)
            {
                var paramAcciones = parametros.Where(p => p.Codigo.Contains(perfil)).ToList();

                foreach (var parametro in paramAcciones)
                {
                    var accion = new Accion
                    {
                        Codigo = parametro.Codigo,
                        Descripcion = parametro.Descripcion,
                        Id = parametro.Id,
                        Nombre = parametro.Nombre,
                        Url = parametro.Valor
                    };
                    acciones.Add(accion);
                }
            }
            return acciones;
        }
        #endregion
    }
}
