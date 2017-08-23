using Microsoft.Practices.EnterpriseLibrary.Data;
using Proyecto.Core.Contracts;
using System;
using System.Configuration;

namespace Proyecto.Data
{
    public class Conexion : IRepository
    {
        public Database InitDatabase()
        {
            var databaseConnection = ConfigurationManager.AppSettings["databaseConnection"];
            if (string.IsNullOrEmpty(databaseConnection))
                throw new Exception("Hace falta configuracion de databaseConnection en web.config");

            var factory = new DatabaseProviderFactory();
            return factory.Create(databaseConnection);
        }
    }
}
