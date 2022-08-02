using Microsoft.AspNetCore.Components;
using TodoBlazor.Models;
using TodoBlazor.Services;

namespace TodoBlazor.Pages
{
    public partial class Todo
	{
        #region Private fields

        /// <summary>
        /// Liste des <see cref="TodoModel"/>.
        /// </summary>
        private TodoModel[] todos;

        #endregion

        #region Properties

        /// <summary>
        /// Voir <see cref="TodoService"/>.
        /// </summary>
        [Inject]
        private TodoService service { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initialisation des données de la page.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            todos = await service.GetTodosAsync();
        }

        #endregion
    }
}
