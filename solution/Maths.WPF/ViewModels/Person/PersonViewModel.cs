using System.Collections.ObjectModel;
using System.Linq;
using Maths.WPF.Commands;
using Maths.WPF.Models;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Person
{
    public class PersonViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Liste des personnes.
        /// </summary>
        private ObservableCollection<PersonModel> _personModels;
        public ObservableCollection<PersonModel> PersonModels
        {
            get => _personModels;
            set => SetField(ref _personModels, value);
        }

        /// <summary>
        /// Personne sélectionnée.
        /// </summary>
        private PersonModel _selectedPersonModels;
        public PersonModel SelectedPersonModels
        {
            get => _selectedPersonModels;
            set => SetField(ref _selectedPersonModels, value);
        }

        //
        //public SelectedPersonStore PersonListViewModel { get; set; }
        //public PersonDetailViewModel PersonDetailViewModel { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="AddTestCommand"/>.
        /// </summary>
        public AddTestCommand AddTestCommand { get; }

        #endregion

        #region Constructors

        public PersonViewModel()
        {
            PersonModels = new ObservableCollection<PersonModel>
            {
                new PersonModel("de MONTI", "Emmanuel", 23),
                new PersonModel("de MONTI", "Chloé", 5),
                new PersonModel("de MONTI", "Camille", 2)
            };

            SelectedPersonModels = PersonModels.First();

            //PersonListViewModel = new PersonListViewModel();
            ////PersonDetailViewModel = new PersonDetailViewModel();
        }

        #endregion
    }
}