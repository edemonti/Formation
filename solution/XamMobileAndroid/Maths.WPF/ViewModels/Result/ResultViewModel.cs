using System;
using System.Collections.Generic;
using System.Text;
using Maths.WPF.Commands;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Result
{
    /// <summary>
    /// ViewModel associé à la vue <see cref="Views.ResultView"/>.
    /// </summary>
    public class ResultViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        /// <summary>
        /// Voir <see cref="ResultAppreciationViewModel"/>.
        /// </summary>
        public ResultAppreciationViewModel ResultAppreciationViewModel { get; }

        /// <summary>
        /// Voir <see cref="ResultDetailViewModel"/>.
        /// </summary>
        public ResultDetailViewModel ResultDetailViewModel { get; }

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="AccessToSetupCommand"/>.
        /// </summary>
        public AccessToSetupCommand AccessToSetupCommand { get; }

        /// <summary>
        /// Voir <see cref="AccessToHomeCommand"/>.
        /// </summary>
        public AccessToHomeCommand AccessToHomeCommand { get; }

        #endregion

        #region Constructors

        public ResultViewModel()
            : base("DefaultConnectionString")
        {
        }

        #endregion
    }
}