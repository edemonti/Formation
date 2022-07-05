using System;
using System.Collections.Generic;
using System.Text;
using Maths.WPF.Commands;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Setup
{
    /// <summary>
    /// ViewModel associé à la vue <see cref="Views.SetupView"/>.
    /// </summary>
    public class SetupViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        ///// <summary>
        ///// Voir <see cref="SetupTestListingViewModel"/>.
        ///// </summary>
        //public SetupTestListViewModel SetupTestListingViewModel { get; }
        //
        ///// <summary>
        ///// Voir <see cref="SetupTestDetailViewModel"/>.
        ///// </summary>
        //public SetupTestDetailViewModel SetupTestDetailViewModel { get; }

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="AddTestCommand"/>.
        /// </summary>
        public AddTestCommand AddTestCommand { get; }

        /// <summary>
        /// Voir <see cref="AccessToTestCommand"/>.
        /// </summary>
        public AddTestCommand AccessToTestCommand { get; }

        /// <summary>
        /// Voir <see cref="AccessToHomeCommand"/>.
        /// </summary>
        public CloseApplicationCommand AccessToHomeCommand { get; }

        #endregion

        #region Constructors

        public SetupViewModel()
            : base("DefaultConnectionString")
        {
            //SetupTestListingViewModel = new SetupTestListViewModel();
            //SetupTestDetailViewModel = new SetupTestDetailViewModel();
        }

        #endregion
    }
}