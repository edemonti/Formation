using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BusinessLogicalLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Models.Impl;
using Models.Impl.RequestDto;
using PresentationLayer.Wpf.BusinessObjects;
using PresentationLayer.Wpf.Technical;
using PresentationLayer.Wpf.View;

namespace PresentationLayer.Wpf.ViewModel
{
    /// <summary>
    /// ViewModel permettant la gestion des <see cref="Connection"/>.
    /// </summary>
    public class ConnectionListViewModel : BaseViewModel
    {
        #region Private fields

        private ObservableCollection<ConnectionBusinessObject> connectionBOList;
        private ConnectionBusinessObject connectionBOSelected;
        private List<Connection> connectionList;
        private readonly IConnectionBusiness connectionBusiness;

        #endregion

        #region Properties

        /// <summary>
        /// Liste d’objets Connection.
        /// </summary>
        public ObservableCollection<ConnectionBusinessObject> ConnectionBOList
        {
            get { return connectionBOList; }
            set { SetField(ref connectionBOList, value); }
        }

        /// <summary>
        /// Objet Connection sélectionné.
        /// </summary>
        public ConnectionBusinessObject ConnectionBOSelected
        {
            get { return connectionBOSelected; }
            set { SetField(ref connectionBOSelected, value); }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Commande permettant d’accéder au formulaire de création d’un enregistrement.
        /// </summary>
        public ICommand AddCommand { get; set; }

        /// <summary>
        /// Commande permettant d’accéder au formulaire de modification d’un enregistrement.
        /// </summary>
        public ICommand UpdateCommand { get; set; }

        /// <summary>
        /// Commande permettant de supprimer l’enregistrement sélectionné.
        /// </summary>
        public ICommand DeleteCommand { get; set; }


        #endregion

        #region Constructor

        public ConnectionListViewModel()
        {
            // Initialisation des commandes.
            AddCommand = new RelayCommand(Add);
            UpdateCommand = new RelayCommand(Update, CanExecuteUpdate);
            DeleteCommand = new RelayCommand(Delete, CanExecuteDelete);

            // Initialisation des variables.
            connectionBusiness = ServiceLocator.Current.GetInstance<IConnectionBusiness>();
            connectionBOList = new ObservableCollection<ConnectionBusinessObject>();
            connectionBOSelected = null;
            connectionList = new List<Connection>();

            // Chargement des données.
            LoadData();
        }

        #endregion

        #region DataLoading

        private void LoadData()
        {
            connectionList = connectionBusiness.GetEntities(new ConnectionRequestDto { }, new List<string>());
            foreach (var connection in connectionList)
            {
                connectionBOList.Add(new ConnectionBusinessObject
                {
                    Id = connection.Id,
                    Name = connection.Name,
                    Provider = connection.Provider,
                    IsProviderImplemented = connection.IsProviderImplemented,
                    ConnectionString = connection.ConnectionString
                });
            }
            connectionBOSelected = connectionBOList.FirstOrDefault();
        }

        #endregion

        #region Commands implementation

        /// <summary>
        /// Accède au formulaire de création d’un enregistrement.
        /// </summary>
        public void Add()
        {
            var connectionViewModelParameters = new NavigationParameter
            {
                Title = "Titre",
                Height = 800,
                Width = 500,
                ViewModel = new ConnectionViewModel(new Connection()),
                Parameters = null
            };
            OpenViewDialog(connectionViewModelParameters);
        }

        /// <summary>
        /// CanExecute associée à la commande <see cref="Update"/>.
        /// </summary>
        /// <returns></returns>
        public bool CanExecuteUpdate()
        {
            return connectionBOSelected != null;
        }

        /// <summary>
        /// Accède au formulaire de modification d’un enregistrement.
        /// </summary>
        public void Update()
        {
            var connectionViewModelParameters = new NavigationParameter
            {
                Title = "Titre",
                Height = 800,
                Width = 500,
                ViewModel = new ConnectionViewModel(connectionBOSelected),
                Parameters = null
            };
            OpenViewDialog(connectionViewModelParameters);
        }

        /// <summary>
        /// CanExecute associée à la commande <see cref="Delete"/>.
        /// </summary>
        /// <returns></returns>
        public bool CanExecuteDelete()
        {
            return connectionBOSelected != null;
        }

        /// <summary>
        /// Supprime l’enregistrement sélectionné.
        /// </summary>
        public void Delete()
        {
            MessageBox.Show("La suppression d’un enregistement n’est pas implémentée.");
        }

        #endregion

    }

}
