using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BusinessLogicalLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.ExecuteDto;
using PresentationLayer.Wpf.BusinessObjects;
using PresentationLayer.Wpf.Technical;

namespace PresentationLayer.Wpf.ViewModel
{
    /// <summary>
    /// ViewModel permettant la gestion des <see cref="Connection"/>.
    /// </summary>
    public class ConnectionViewModel : BaseViewModel
    {
        #region Private fields

        private ConnectionBusinessObject connectionBO;
        private Connection connection;
        private readonly IConnectionBusiness connectionBusiness;

        #endregion

        #region Properties

        /// <summary>
        /// Objet Connection.
        /// </summary>
        public ConnectionBusinessObject ConnectionBO
        {
            get { return connectionBO; }
            set { SetField(ref connectionBO, value); }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Commande permettant la sauvegarde l’enregistrement.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Commande permettant de supprimer l’enregistrement.
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Commande permettant d’annuler les modifications apportées à la fenêtre.
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commande permettant la fermeture de la fenêtre.
        /// </summary>
        public ICommand ExitCommand { get; set; }

        #endregion

        #region Constructor

        public ConnectionViewModel(Connection connection)
        {
            // Initialisation des commandes.
            SaveCommand = new RelayCommand(Save, CanExecuteSave);
            CancelCommand = new RelayCommand(Cancel, CanExecuteCancel);
            ExitCommand = new RelayCommand<Window>(Exit);

            // Initialisation des variables.
            connectionBusiness = ServiceLocator.Current.GetInstance<IConnectionBusiness>();

            // Chargement des données.
            LoadData(connection);
        }

        #endregion

        #region DataLoading

        /// <summary>
        /// Charge la connexion.
        /// </summary>
        /// <param name="id">Identifiant de la connexion à récupérer.</param>
        private void LoadData(Connection connection)
        {
            var includes = new List<string>();

            if (connection == null || connection.Id == 0)
            {
                connectionBO = new ConnectionBusinessObject();
                this.connection = new Connection();
            }
            else
            {
                this.connection = connectionBusiness.GetEntity(connection.Id, includes);
                if (connection != null)
                {
                    connectionBO = new ConnectionBusinessObject
                    {
                        Id = connection.Id,
                        Name = connection.Name,
                        Provider = connection.Provider,
                        IsProviderImplemented = connection.IsProviderImplemented,
                        ConnectionString = connection.ConnectionString
                    };
                }
                else
                {
                    connectionBO = new ConnectionBusinessObject();
                    this.connection = new Connection();
                }
            }
        }

        #endregion

        #region Commands implementation

        /// <summary>
        /// CanExecute associée à la commande <see cref="Save"/>.
        /// </summary>
        /// <returns></returns>
        public bool CanExecuteSave()
        {
            return !string.IsNullOrWhiteSpace(connection.Name) &&
                !string.IsNullOrWhiteSpace(connection.Provider) &&
                !string.IsNullOrWhiteSpace(connection.ConnectionString);
        }

        /// <summary>
        /// Enregistre les modifications apportées.
        /// </summary>
        public void Save()
        {
            var entity = new Connection
            {
                Id = connectionBO.Id,
                Name = connectionBO.Name,
                Provider = connectionBO.Provider,
                IsProviderImplemented = connectionBO.IsProviderImplemented,
                ConnectionString = connectionBO.ConnectionString,
            };
            var executeDto = new BaseExecuteDto
            {
                ReturnEntity = true
            };

            if (connection.Id == 0)
            {
                entity = connectionBusiness.InsertEntity(entity, executeDto);
                if (entity != null && entity.Id > 0)
                    MessageBox.Show("La connexion a été créée.");
                else
                    MessageBox.Show("La connexion n’a pas été créée.");
            }
            else
            {
                MessageBox.Show("La modification d’un enregistrement n’est pas implémentée.");
            }
        }

        /// <summary>
        /// CanExecute associée à la commande <see cref="Cancel"/>.
        /// </summary>
        /// <returns></returns>
        public bool CanExecuteCancel()
        {
            return connection.Name != connectionBO.Name ||
                connection.Provider != connectionBO.Provider ||
                connection.IsProviderImplemented != connectionBO.IsProviderImplemented ||
                connection.ConnectionString != connectionBO.ConnectionString;
        }

        /// <summary>
        /// Annule les modifications apportées.
        /// </summary>
        public void Cancel()
        {
            ConnectionBO = new ConnectionBusinessObject
            {
                Id = connection.Id,
                Name = connection.Name,
                Provider = connection.Provider,
                IsProviderImplemented = connection.IsProviderImplemented,
                ConnectionString = connection.ConnectionString,
            };
        }

        /// <summary>
        /// Ferme la fenêtre.
        /// </summary>
        /// <param name="win">Fenêtre à fermer.</param>
        public void Exit(Window win)
        {
            win.Close();
        }

        #endregion

    }
}
