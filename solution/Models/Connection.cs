using System.IO;
using Microsoft.Extensions.Configuration;

namespace Models
{
    /// <summary>
    /// Connexion aux données de l’application.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Chaîne de connexion.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Contructeur de la classe.
        /// </summary>
        /// <param name="connectionStringName">Nom de la connexion recherchée.</param>
        public Connection(string connectionStringName)
        {
            ConnectionString = GetConnectionString(connectionStringName);
        }

        /// <summary>
        /// Récupération de la chaîne de connexion.
        /// </summary>
        /// <param name="connectionStringName">Nom de la connexion recherchée.</param>
        private string GetConnectionString(string connectionStringName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configurationRoot = builder.Build();
            return configurationRoot.GetConnectionString(connectionStringName).Replace("[applicationBase]", System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
        }
    }
}