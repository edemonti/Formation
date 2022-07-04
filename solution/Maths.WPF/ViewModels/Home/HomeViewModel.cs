using System;
using System.Collections.Generic;
using System.Text;
using Maths.WPF.Commands;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Home
{
    /// <summary>
    /// ViewModel associé à la vue <see cref="Views.HomeView"/>.
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="AccessToSetupCommand"/>.
        /// </summary>
        public AccessToSetupCommand AccessToSetupCommand { get; }

        /// <summary>
        /// Voir <see cref="CloseApplicationCommand"/>.
        /// </summary>
        public CloseApplicationCommand CloseApplicationCommand { get; }
        
        #endregion

        #region Constructors

        public HomeViewModel()
            : base()
        {
        }

        #endregion
    }
}