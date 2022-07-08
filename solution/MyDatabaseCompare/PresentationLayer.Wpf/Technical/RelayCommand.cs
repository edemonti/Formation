using System;
using System.Windows.Input;

namespace PresentationLayer.Wpf.Technical
{
    /// <summary>
    /// Classe d’implémentation d’une commande.
    /// </summary>
    public class RelayCommand : ICommand
    {

        #region Private fields

        private readonly Action actionToExecute;
        private readonly Func<bool> canExecuteAction;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur permettant d’initialiser une commande.
        /// </summary>
        /// <param name="actionToExecute">Nom de la méthode à exécuter.</param>
        public RelayCommand(Action actionToExecute)
            : this(actionToExecute, DefaultCanExecute)
        {
        }

        /// <summary>
        /// Constructeur permettant d’initialiser une commande et son CanExecute.
        /// </summary>
        /// <param name="actionToExecute">Nom de la méthode à exécuter.</param>
        /// <param name="canExecuteAction">Nom de la méthode permettant de savoir si la commande est active ou non.</param>
        public RelayCommand(Action actionToExecute, Func<bool> canExecuteAction)
        {
            this.actionToExecute = actionToExecute;
            this.canExecuteAction = canExecuteAction;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gestion de l’abonnement à l’évènement CanExecuteChanged.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Récupération du CanExecute par défaut.
        /// </summary>
        /// <returns>True si la commande doit être active par défaut, false sinon.</returns>
        private static bool DefaultCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Flag indiquant qu’une commande est active ou non.
        /// </summary>
        /// <param name="parameter">Paramètre à passer à la commande.</param>
        /// <returns>True si la commande est active, false sinon.</returns>
        public bool CanExecute(object parameter)
        {
            return canExecuteAction != null && canExecuteAction();
        }

        /// <summary>
        /// Exécution d’une commande.
        /// </summary>
        /// <param name="parameter">Paramètre à passer à la commande.</param>
        public void Execute(object parameter)
        {
            actionToExecute();
        }

        #endregion

    }

    /// <summary>
    /// Classe d’implémentation d’une commande, avec un paramètre.
    /// </summary>
    /// <typeparam name="T">Type du paramètre qui sera passé à la commande.</typeparam>
    public class RelayCommand<T> : ICommand where T : class
    {

        #region Private fields

        private readonly Action<T> actionToExecute;
        private readonly Func<T, bool> canExecuteAction;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur permettant d’initialiser une commande.
        /// </summary>
        /// <param name="actionToExecute">Nom de la méthode à exécuter.</param>
        public RelayCommand(Action<T> actionToExecute)
            : this(actionToExecute, DefaultCanExecute)
        {
        }

        /// <summary>
        /// Constructeur permettant d’initialiser une commande et son CanExecute.
        /// </summary>
        /// <param name="actionToExecute">Nom de la méthode à exécuter.</param>
        /// <param name="canExecuteAction">Nom de la méthode permettant de savoir si la commande est active ou non.</param>
        public RelayCommand(Action<T> actionToExecute, Func<T, bool> canExecuteAction)
        {
            this.actionToExecute = actionToExecute;
            this.canExecuteAction = canExecuteAction;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gestion de l’abonnement à l’évènement CanExecuteChanged.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Récupération du CanExecute par défaut.
        /// </summary>
        /// <param name="parameter">Paramètre à passer à la commande.</param>
        /// <returns>True si la commande doit être active par défaut, false sinon.</returns>
        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Flag indiquant qu’une commande est active ou non.
        /// </summary>
        /// <param name="parameter">Paramètre à passer à la commande.</param>
        /// <returns>True si la commande est active, false sinon.</returns>
        public bool CanExecute(object parameter)
        {
            return canExecuteAction != null && canExecuteAction(parameter as T);
        }

        /// <summary>
        /// Exécution d’une commande.
        /// </summary>
        /// <param name="parameter">Paramètre à passer à la commande.</param>
        public void Execute(object parameter)
        {
            actionToExecute(parameter as T);
        }

        #endregion

    }
}