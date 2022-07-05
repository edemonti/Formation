using System;
using System.Collections.Generic;
using System.Text;
using Maths.WPF.Commands;
using Technical.ViewModels;

namespace Maths.WPF.ViewModels.Setup
{
    /// <summary>
    /// ViewModel associé à un item de la liste présente dans au niveau de l’UC <see cref="Views.Setup.SetupTestListUC"/>.
    /// </summary>
    public class SetupTestListItemViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Properties

        /// <summary>
        /// Nom du test.
        /// </summary>
        public string TestName { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Voir <see cref="EditTestCommand"/>.
        /// </summary>
        public EditTestCommand EditTestCommand { get; }

        /// <summary>
        /// Voir <see cref="DeleteTestCommand"/>.
        /// </summary>
        public DeleteTestCommand DeleteTestCommand { get; }

        #endregion

        #region Constructors

        public SetupTestListItemViewModel(string testName)
            : base("DefaultConnectionString")
        {
            TestName = testName;
        }

        #endregion
    }
}
