using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using System;
using System.Configuration;

namespace Proyecto.Data
{
    public class SqlConnection : IRepository
    {
        public Database InitDatabase()
        {
            var databaseConnection = ConfigurationManager.AppSettings["DatabaseConnection"];
            if (string.IsNullOrEmpty(databaseConnection))
                throw new Exception("Hace falta configuracion de databaseConnection en web.config");

            var factory = new DatabaseProviderFactory();
            return factory.Create(databaseConnection);
        }
    }
}
