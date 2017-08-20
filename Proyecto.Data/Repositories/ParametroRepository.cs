using System;
using System.Collections.Generic;
using Proyecto.Core.Contracts;
using Proyecto.Core.Contracts.Repositories;
using Proyecto.Core.Models;

namespace Proyecto.Data.Repositories
{
    public class ParametroRepository : IParametroRepository, IRepository
    {
        public IList<Parametro> GetList()
        {
            throw new NotImplementedException();
        }

        public Parametro GetParametro(int idParametro)
        {
            throw new NotImplementedException();
        }
    }
}
