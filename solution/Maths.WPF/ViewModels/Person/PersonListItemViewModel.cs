using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Person
{
    public class PersonListItemViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Nom de la personne.
        /// </summary>
        private string _name;
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Prénom de la personne.
        /// </summary>
        private string _surname;
        public string Surname
        {
            get => _surname;
            set => SetField(ref _surname, value);
        }

        #endregion

        #region Constructors

        public PersonListItemViewModel(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        #endregion
    }
}
