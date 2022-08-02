namespace TodoBlazor.Models
{ 
    /// <summary>
    /// Entité Todo.
    /// </summary>
    public class TodoModel
    {
        #region Properties

        private string id;
        public string Id
        {
            get => id;
            set => id = value;
        }

        private string title;
        public string Title
        {
            get => title;
            set => title = value;
        }

        private bool isDone;
        public bool IsDone
        {
            get => isDone;
            set => isDone = value;
        }

        #endregion

        #region Constructors

        public TodoModel(string title)
        {
            this.id = Guid.NewGuid().ToString();
            this.title = title;
            this.isDone = false;
        }

        #endregion
    }
}