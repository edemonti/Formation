using System;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Person
{
    public class SelectedPersonStore : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Personne sélectionnée.
        /// </summary>
        private Entities.Person _selectedPersonModels;
        public Entities.Person SelectedPersonModels
        {
            get => _selectedPersonModels;
            set
            {
                SetField(ref _selectedPersonModels, value);
                SelectedPersonStoreChanged?.Invoke();
            }
        }

        #endregion

        public SelectedPersonStore()
            : base("DefaultConnectionString")
        {
        }

        #region Events

        public event Action SelectedPersonStoreChanged;

        #endregion
    }
}
