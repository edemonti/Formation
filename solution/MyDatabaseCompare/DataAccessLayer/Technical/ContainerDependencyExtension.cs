using DataAccessLayer.Impl;
using DataAccessLayer.Interfaces;
using Microsoft.Practices.Unity;
using Models.Impl;
using Models.Technical;

namespace DataAccessLayer.Technical
{
    /// <summary>
    /// Containeur contenant les références vers la couche d’accès aux données.
    /// </summary>
    public class ContainerDependencyExtension : UnityContainerExtension
    {
        /// <summary>
        /// Initialisation des références vers la couche d’accès aux données.
        /// </summary>
        protected override void Initialize()
        {
            Context context = new Context();
            context.InitializeContext();

            Container.RegisterType<IActionDataAccess, ActionDataAccess>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(context));
            Container.RegisterType<IActionDetailDataAccess, ActionDetailDataAccess>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(context));
            Container.RegisterType<IConnectionDataAccess, ConnectionDataAccess>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(context));
            Container.RegisterType<IExecutionActionDataAccess, ExecutionActionDataAccess>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(context));
            Container.RegisterType<IExecutionActionDetailDataAccess, ExecutionActionDetailDataAccess>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(context));
            Container.RegisterType<IQueryDataAccess, QueryDataAccess>(
                new ContainerControlledLifetimeManager(), new InjectionConstructor(context));
        }
    }
}
