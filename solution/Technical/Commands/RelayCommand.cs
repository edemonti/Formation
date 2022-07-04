using System;
using System.Windows.Input;

namespace Technical.Commands
{
    /// <summary>
    /// Classe de base d’une commande.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Fields

        private readonly Action<object> _actionToExecute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Events

        /// <summary>
        /// Évènement appelé lors d’un changement pouvant affecter l’activation de la commande.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            // TODO EDEMONTI : Voir comment ça marche ?
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur.
        /// </summary>
        public RelayCommand(Action<object> actionToExecute, Predicate<object> canExecute)
        {
            _actionToExecute = actionToExecute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> actionToExecute)
            : this(actionToExecute, null)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// L’action est-elle active ?
        /// Par défaut, l’exécution de l’action est possible.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Exécution de l’action.
        /// </summary>
        public void Execute(object parameter)
        {
            _actionToExecute.Invoke(parameter);
        }

        #endregion

    }
}
