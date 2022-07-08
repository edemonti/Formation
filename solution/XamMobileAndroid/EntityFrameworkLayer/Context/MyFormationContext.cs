using EntityFrameworkLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EntityFrameworkLayer.Context
{
    /// <summary>
    /// Context de l’application.
    /// </summary>
    public class MyFormationContext : DbContext
    {
        #region Private Fields

        /// <summary>
        /// Nom de la chaîne de connexion.
        /// </summary>
        public string ConnectionName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur obligatoire.
        /// </summary>
        public MyFormationContext(DbContextOptions<MyFormationContext> options, string connectionName)
            : base(options)
        {
            ConnectionName = connectionName;
        }

        /// <summary>
        /// Constructeur obligatoire.
        /// </summary>
        public MyFormationContext(DbContextOptions<MyFormationContext> options)
            : base(options)
        {
            ConnectionName = "DefaultConnectionString";
        }

        #endregion

        #region Configuration

        /// <summary>
        /// Récuprération de la chaîne de connexion au niveau du fichier de configuration.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configurationRoot = builder.Build();
            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString(ConnectionName));

            //var configurationRoot = builder.Build();
            //ConnectionString = configurationRoot.GetConnectionString(_connectionName).Replace("[applicationBase]", System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
        }

        #endregion

        #region DbSet

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Element> Elements { get; set; }

        #endregion
    }
}