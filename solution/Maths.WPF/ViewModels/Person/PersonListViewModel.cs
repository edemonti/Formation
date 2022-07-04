using System.Collections.ObjectModel;
using Technical.ViewModels;
using Maths.WPF.Models;

namespace Maths.WPF.ViewModels.Person
{
    public class PersonListViewModel : BaseViewModel
    {
        #region Properties

        ///// <summary>
        ///// Liste des personnes.
        ///// </summary>
        //private ObservableCollection<PersonModel> _personModels;
        //public ObservableCollection<PersonModel> PersonModels
        //{
        //    get => _personModels;
        //    set => SetField(ref _personModels, value);
        //}
        //
        ///// <summary>
        ///// Personne sélectionnée.
        ///// </summary>
        //private PersonModel _selectedPersonModels;
        //public PersonModel SelectedPersonModels
        //{
        //    get => _selectedPersonModels;
        //    set => SetField(ref _selectedPersonModels, value);
        //}

        #endregion

        public PersonListViewModel()
        {
            //PersonModels = new ObservableCollection<PersonModel>
            //{
            //    new PersonModel("de MONTI", "Emmanuel", 23),
            //    new PersonModel("de MONTI", "Chloé", 5),
            //    new PersonModel("de MONTI", "Camille", 2)
            //};
        }
    }
}
