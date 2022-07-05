using EntityFrameworkLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Technical.Test
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
        /// Constructeur de la classe permettant la création du contexte.
        /// </summary>
        public BaseTest(string connectionName)
        {
            var options = new DbContextOptionsBuilder<MyFormationContext>().Options;
            // var options = new DbContextOptionsBuilder<MyFormationContext>().UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            Context = new MyFormationContext(options, connectionName);
        }

        #endregion

    }
}