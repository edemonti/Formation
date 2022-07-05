using Maths.WPF.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Person
{
    public class PersonViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Liste des personnes.
        /// </summary>
        private ObservableCollection<Entities.Person> _personModels;
        public ObservableCollection<Entities.Person> PersonModels
        {
            get => _personModels;
            set => SetField(ref _personModels, value);
        }

        /// <summary>
        /// Personne sélectionnée.
        /// </summary>
        private Entities.Person _selectedPersonModels;
        public Entities.Person SelectedPersonModels
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
            : base("DefaultConnectionString")
        {
            PersonModels = new ObservableCollection<Entities.Person>
            {
                new Entities.Person("de MONTI", "Emmanuel", 23),
                new Entities.Person("de MONTI", "Chloé", 5),
                new Entities.Person("de MONTI", "Camille", 2)
            };

            SelectedPersonModels = PersonModels.First();

            //PersonListViewModel = new PersonListViewModel();
            ////PersonDetailViewModel = new PersonDetailViewModel();
        }

        #endregion
    }
}