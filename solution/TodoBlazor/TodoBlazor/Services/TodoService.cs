using TodoBlazor.Models;

namespace TodoBlazor.Services
{
    /// <summary>
    /// Service de gestion des <see cref="TodoModel"/>.
    /// </summary>
    public class TodoService
    {
        #region Methods

        /// <summary>
        /// Récupération de la liste des <see cref="TodoModel"/>.
        /// TODO EDEMONTI : Utiliser un json.
        /// </summary>
        public async Task<TodoModel[]> GetTodosAsync()
        {
            List<TodoModel> items = new()
            {
                new TodoModel("Tâche 1"),
                new TodoModel("Tâche 2"),
                new TodoModel("Tâche 3"),
                new TodoModel("Tâche 4"),
                new TodoModel("Tâche 5")
            };
            return items.ToArray();
        }

        #endregion
    }
}