﻿using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Person
{
    public class PersonDetailViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Personne sélectionnée.
        /// </summary>
        private Entities.Person _selectedPersonModels;
        public Entities.Person SelectedPersonModels
        {
            get => _selectedPersonModels;
            set => SetField(ref _selectedPersonModels, value);
        }

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

        /// <summary>
        /// Age de la personne.
        /// </summary>
        private int _age;
        public int Age
        {
            get => _age;
            set => SetField(ref _age, value);
        }

        #endregion

        #region Constructors

        public PersonDetailViewModel()
            : base("DefaultConnectionString")
        {
            Name = "[Name]";
            Surname = "[Surname]";
            Age = -1;
        }

        public PersonDetailViewModel(string name, string surname, int age)
            : base("DefaultConnectionString")
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        #endregion
    }
}
