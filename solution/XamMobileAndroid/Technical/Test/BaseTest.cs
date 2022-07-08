using EntityFrameworkLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Technical.Test
{
    /// <summary>
    /// Classe de base des tests.
    /// </summary>
    public class BaseTest
    {
        #region Private Fields

        private static TestContext _testContext;

        #endregion

        #region Protected Fields

        /// <summary>
        /// Voir <see cref="MyFormationContext"/>.
        /// </summary>
        protected MyFormationContext Context;

        /// <summary>
        /// Contexte utilisé pour accéder aux fichiers xml de test.
        /// </summary>
        protected TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

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

        #region Initialization

        /// <summary>
        /// Initialisation de la classe de test.
        /// (appelée une fois avant le lancement de tous les tests)
        /// Permet le lancement de ReSO en arrière plan.
        /// </summary>
        protected static void BaseClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
        }

        /// <summary>
        /// Initialisation de la méthode de test.
        /// (appelé lors du lancement de chaque test)
        /// </summary>
        protected void BaseTestInitialize()
        {
            System.Diagnostics.Debug.Print($"Exécution du test {TestContext.TestName}");
        }

        #endregion

        #region Finalisation

        /// <summary>
        /// Finalisation des tests.
        /// (appelée une fois à la fin de l’exécution de l’ensemble des tests)
        /// </summary>
        protected static void BaseClassCleanup()
        {
        }

        #endregion


    }
}