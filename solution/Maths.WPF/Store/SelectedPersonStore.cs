using System;
using Maths.WPF.Models;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Person
{
    public class SelectedPersonStore : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Personne sélectionnée.
        /// </summary>
        private PersonModel _selectedPersonModels;
        public PersonModel SelectedPersonModels
        {
            get => _selectedPersonModels;
            set
            {
                SetField(ref _selectedPersonModels, value);
                SelectedPersonStoreChanged?.Invoke();
            }
        }

        #endregion

        #region Events

        public event Action SelectedPersonStoreChanged;

        #endregion
    }
}
