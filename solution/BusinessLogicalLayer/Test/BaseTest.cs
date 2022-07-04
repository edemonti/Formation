using System;
using EntityFrameworkLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicalLayer.Test
{
    /// <summary>
    /// Classe de base des tests.
    /// </summary>
    public class BaseTest
    {

        #region Protected Fields

        /// <summary>
        /// Voir <see cref="MyFormationContext"/>.
        /// </summary>
        protected MyFormationContext Context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public BaseTest(string connectionName)
        {
            Context = CreateContext(connectionName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant de créer le context.
        /// </summary>
        private MyFormationContext CreateContext(string connectionName)
        {
            // TODO EDEMONTI : regarder comment marche UseInMemoryDatabase.
            var options = new DbContextOptionsBuilder<MyFormationContext>().Options;
            //var options = new DbContextOptionsBuilder<MyFormationContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            return new MyFormationContext(options, connectionName);
        }

        #endregion
    }
}