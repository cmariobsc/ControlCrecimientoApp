using System.Collections.Generic;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Contracts.Services;
using Proyecto.Core.Models;

namespace Proyecto.Services
{
    public class ParametroService : IParametroService, IService
    {
        private readonly IParametroRepository _parametroRepository;
        public ParametroService(IParametroRepository parametroRepository)
        {
            _parametroRepository = parametroRepository;
        }
        public IList<Parametro> GetList()
        {
            return _parametroRepository.GetList();
        }
        public Parametro GetParametro(int idParametro)
        {
            return _parametroRepository.GetParametro(idParametro);
        }
    }
}
