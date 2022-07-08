using BusinessLogicalLayer.Test.Technical;

namespace BusinessLogicalLayer.Test.Impl
{
    /// <summary>
    /// Classe de base pour les tests unitaires.
    /// </summary>
    public class BaseTest
    {
        public BaseTest()
        {
            Bootstrapper.InitializeContainer();
        }
    }
}