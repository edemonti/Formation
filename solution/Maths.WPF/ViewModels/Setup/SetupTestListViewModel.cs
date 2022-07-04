using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Setup
{
    /// <summary>
    /// ViewModel associé à l’UC <see cref="Views.Setup.SetupTestListUC"/>.
    /// </summary>
    public class SetupTestListViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        private ObservableCollection<SetupTestListItemViewModel> _setupTestListItemViewModels;
        public ObservableCollection<SetupTestListItemViewModel> SetupTestListItemViewModels// => _setupTestListItemViewModels;
        {
            get => _setupTestListItemViewModels;
            set => SetField(ref _setupTestListItemViewModels, value);
        }

        #endregion

        #region Constructors

        public SetupTestListViewModel()
            : base()
        {
            SetupTestListItemViewModels = new ObservableCollection<SetupTestListItemViewModel>();
            SetupTestListItemViewModels.Add(new SetupTestListItemViewModel("Multiplication 1"));
            SetupTestListItemViewModels.Add(new SetupTestListItemViewModel("Multiplication 2"));
            SetupTestListItemViewModels.Add(new SetupTestListItemViewModel("Multiplication 3"));
            SetupTestListItemViewModels.Add(new SetupTestListItemViewModel("Multiplication 4"));
            SetupTestListItemViewModels.Add(new SetupTestListItemViewModel("Multiplication 5"));
        }

        #endregion
    }
}
