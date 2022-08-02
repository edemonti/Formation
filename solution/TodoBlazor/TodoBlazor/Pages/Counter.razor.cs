using TodoBlazor.Models;

namespace TodoBlazor.Pages
{
    public partial class Counter
    {
        #region Private fields

        /// <summary>
        /// Liste des <see cref="TodoModel"/>.
        /// </summary>
        private int currentCount = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Incrémentation du compteur.
        /// </summary>
        protected void IncrementCount()
        {
            currentCount++;
        }

        #endregion
    }
}
