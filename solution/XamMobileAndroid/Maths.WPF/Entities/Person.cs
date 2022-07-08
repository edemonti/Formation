using EntityFrameworkLayer.Entities;

namespace Maths.WPF.Entities
{
    public class Person : BaseEntity
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

        public Person()
            : base()
        {
        }

        public Person(string name, string surname, int age)
            : base()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        #endregion
    }
}
