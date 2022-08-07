using Microsoft.AspNetCore.Components;
using TodoBlazor.Models;
using TodoBlazor.Services;

namespace TodoBlazor.Components
{
    /// <summary>
    /// Classe de fonctionnement de la page <see cref="Pages.Todo"/>.
    /// </summary>
    public class TodoComponent : ComponentBase
    {
        #region Private fields

        /// <summary>
        /// Liste des <see cref="TodoModel"/>.
        /// </summary>
        protected TodoModel[] todos;

        #endregion

        #region Properties

        /// <summary>
        /// Voir <see cref="TodoService"/>.
        /// </summary>
        [Inject]
        protected TodoService service { get; set; }

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
