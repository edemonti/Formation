using System;
using System.Collections.Generic;
using System.Text;
using Maths.WPF.Commands;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Test
{
    /// <summary>
    /// ViewModel associé à l’UC <see cref="Views.Test.TestOperationUC"/>.
    /// </summary>
    public class TestOperationViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="SelectResponseCommand"/>.
        /// </summary>
        public SelectResponseCommand SelectResponseCommand { get; }

        #endregion

        #region Constructors

        public TestOperationViewModel()
            : base("DefaultConnectionString")
        {
        }

        #endregion
    }
}
