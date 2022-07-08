using DataAccessLayer.Impl;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Technical;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace DataAccessLayer.Test.Technical
{
    /// <summary>
    /// Classe appelée au lancement de l’application permettant d’initialiser le container Unity.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Initialisation du container.
        /// </summary>
        public static void InitializeContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IActionDataAccess, ActionDataAccess>();
            container.RegisterType<IActionDetailDataAccess, ActionDetailDataAccess>();
            container.RegisterType<IConnectionDataAccess, ConnectionDataAccess>();
            container.RegisterType<IExecutionActionDataAccess, ExecutionActionDataAccess>();
            container.RegisterType<IExecutionActionDetailDataAccess, ExecutionActionDetailDataAccess>();
            container.RegisterType<IQueryDataAccess, QueryDataAccess>();
            container.AddExtension(new ContainerDependencyExtension());
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}