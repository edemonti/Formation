using BusinessLogicalLayer;
using BusinessLogicalLayer.Interface;
using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Technical.Commands;
using Technical.Enums;
using Technical.Exceptions;
using Technical.ViewModels;

namespace Wpf.ViewModels
{
    /// <summary>
    /// ViewModel permettant la gestion de la liste des <see cref="Element"/>.
    /// </summary>
    public class ElementViewModel : BaseViewModel
    {
        #region Private Fields

        /// <summary>
        /// Voir <see cref="IElementBusinessLogical"/>.
        /// </summary>
        private readonly IElementBusinessLogical _elementBusinessLogical;

        #endregion

        #region Properties

        /// <summary>
        /// <see cref="Element"/> sélectionné.
        /// </summary>
        private Element _selectedElement;

        public Element SelectedElement
        {
            get => _selectedElement;
            set => SetField(ref _selectedElement, value);
        }

        /// <summary>
        /// Liste des <see cref="Element"/>.
        /// </summary>
        private ObservableCollection<Element> _Elements;
        public ObservableCollection<Element> Elements
        {
            get => _Elements;
            set => SetField(ref _Elements, value);
        }

        /// <summary>
        /// Flag indiquant si des modifications sont en cours.
        /// </summary>
        public bool HasModifications => _Elements.Any(w => w.State != EntityState.Unchanged);

        #endregion

        #region Commands

        /// <summary>
        /// Action d’ajout d’une tâche.
        /// </summary>
        public ICommand InsertCommand { get; }

        /// <summary>
        /// Action de suppression d’une tâche.
        /// La suppression d’une tâche consiste à la marquer à l’état 'Deleted'.
        /// Elle sera réellement supprimée lors de la sauvegarde.
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Action de sauvegarde des modifications en cours sur les tâches.
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// Action d’annulation des modifications en cours sur la tâche sélectionné.
        /// </summary>
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Action de rafraîchissement des tâches.
        /// </summary>
        public ICommand RefreshCommand { get; }

        #endregion

        #region Constructors

        public ElementViewModel()
            : base()
        {
            _elementBusinessLogical = new ElementBusinessLogical(new Connection("PCManuConnection"));

            Elements = new ObservableCollection<Element>();

            // Initialisation des commandes.
            InsertCommand = new RelayCommand(ExecuteInsertCommand, CanExecuteInsertCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            RefreshCommand = new RelayCommand(ExecuteRefreshCommand, CanExecuteRefreshCommand);

            // Récupération de la liste des tâches.
            ExecuteRefreshCommand(null);
        }

        #endregion

        #region Commands implementation

        /// <summary>
        /// Peut-exécuter la commande <see cref="InsertCommand"/> ?
        /// Cette action est toujours possible.
        /// </summary>
        private bool CanExecuteInsertCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Exécution de la commande <see cref="InsertCommand"/>.
        /// </summary>
        public void ExecuteInsertCommand(object obj)
        {
            // Initialisation d’une nouvelle tâche.
            Elements.Add(new Element(0, string.Empty, EntityState.Added));

            // Sélection de cette tâche.
            SelectedElement = Elements.Last();
        }

        /// <summary>
        /// Peut-exécuter la commande <see cref="DeleteCommand"/> ?
        /// C’est le cas si l’enregsitrement sélectionné n’est pas déjà supprimé.
        /// </summary>
        private bool CanExecuteDeleteCommand(object obj)
        {
            return SelectedElement != null && SelectedElement.State != EntityState.Deleted;
        }

        /// <summary>
        /// Exécution de la commande <see cref="DeleteCommand"/>.
        /// </summary>
        public void ExecuteDeleteCommand(object obj)
        {
            SelectedElement.State = EntityState.Deleted;
        }

        /// <summary>
        /// Peut-exécuter la commande <see cref="CancelCommand"/> ?
        /// C’est le cas si des modifications sont en cours sur la tâche sélectionnée.
        /// </summary>
        private bool CanExecuteCancelCommand(object obj)
        {
            return SelectedElement != null && SelectedElement.State != EntityState.Unchanged;
        }

        /// <summary>
        /// Exécution de la commande <see cref="CancelCommand"/>.
        /// </summary>
        public void ExecuteCancelCommand(object obj)
        {
            try
            {
                SelectedElement = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.GetEntity(SelectedElement.Id, new List<string>(), false));
            }
            catch (BusinessException ex)
            {
                BusinessMessage = ex.BusinessMessage;
            }
        }

        /// <summary>
        /// Peut-exécuter la commande <see cref="SaveCommand"/> ?
        /// C’est le cas si des modifications sont en cours sur la liste des tâches.
        /// </summary>
        private bool CanExecuteSaveCommand(object obj)
        {
            return HasModifications;
        }

        /// <summary>
        /// Exécution de la commande <see cref="SaveCommand"/>.
        /// </summary>
        public void ExecuteSaveCommand(object obj)
        {
            try
            {
                // Sauvegarde.
                _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.Save(Elements.Where(w => w.State != EntityState.Unchanged), new ElementExecuteDto()));

                // Rafraîchissement des données.
                ExecuteRefreshCommand(null);
            }
            catch (BusinessException ex)
            {
                BusinessMessage = ex.BusinessMessage;
            }
        }

        /// <summary>
        /// Peut-exécuter la commande <see cref="RefreshCommand"/> ?
        /// Cette action est toujours possible.
        /// </summary>
        private bool CanExecuteRefreshCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Exécution de la commande <see cref="RefreshCommand"/>.
        /// </summary>
        public void ExecuteRefreshCommand(object obj)
        {
            try
            {
                // Mémorisation de l’enregistrement sélectionné.
                var id = SelectedElement?.Id;

                // Réinitialisation des listes des tâches.
                Elements.Clear();

                // Récupération des tâches.
                var entities = _elementBusinessLogical.ExecuteMethod(() => _elementBusinessLogical.GetEntities(new ElementRequestDto(), new List<string>(), false));
                foreach (var entity in entities)
                    entity.IsChangeStateActivated = true;
                Elements = new ObservableCollection<Element>(entities);

                // Sélection de l’enregistrement précédemment sélectionné.
                SelectedElement = _Elements.FirstOrDefault(w => id == null || w.Id == id);
            }
            catch (BusinessException ex)
            {
                BusinessMessage = ex.BusinessMessage;
            }
        }

        #endregion
    }
}
