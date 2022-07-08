using BusinessLogicalLayer.Impl;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Technical;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace BusinessLogicalLayer.Test.Technical
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
            container.RegisterType<IActionBusiness, ActionBusiness>();
            container.RegisterType<IActionDetailBusiness, ActionDetailBusiness>();
            container.RegisterType<IConnectionBusiness, ConnectionBusiness>();
            container.RegisterType<IExecutionActionBusiness, ExecutionActionBusiness>();
            container.RegisterType<IExecutionActionDetailBusiness, ExecutionActionDetailBusiness>();
            container.RegisterType<IQueryBusiness, QueryBusiness>();
            container.AddExtension(new ContainerDependencyExtension());
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}