using System;
using System.Collections.Generic;
using System.Text;
using Maths.WPF.Commands;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Test
{
    /// <summary>
    /// ViewModel associé à la vue <see cref="Views.TestView"/>.
    /// </summary>
    public class TestViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        /// <summary>
        /// Voir <see cref="TestAdvancementViewModel"/>.
        /// </summary>
        public TestAdvancementViewModel TestAdvancementViewModel { get;  }

        /// <summary>
        /// Voir <see cref="TestOperationViewModel"/>.
        /// </summary>
        public TestOperationViewModel TestOperationViewModel { get;  }

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="AccessToTestCommand"/>.
        /// </summary>
        public AccessToTestCommand AccessToTestCommand { get; }

        /// <summary>
        /// Voir <see cref="AccessToHomeCommand"/>.
        /// </summary>
        public AccessToHomeCommand AccessToHomeCommand { get; }

        #endregion

        #region Constructors

        public TestViewModel()
            : base()
        {
        }

        #endregion
    }
}