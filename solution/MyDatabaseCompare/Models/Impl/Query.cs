using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Impl
{
    /// <summary>
    /// Liste des requêtes disponibles.
    /// </summary>
    public class Query : BaseModel
    {
        #region Private fields

        private int id;
        private string name;
        private string command;

        #endregion

        #region Properties

        /// <summary>
        /// Identifiant unique de la requête.
        /// </summary>
        [Required]
        public int Id
        {
            get { return id; }
            set { SetField(ref id, value); }
        }

        /// <summary>
        /// Nom de la requête.
        /// </summary>
        [Required]
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }

        /// <summary>
        /// Requête SQL à exécuter.
        /// </summary>
        public string Command
        {
            get { return command; }
            set { SetField(ref command, value); }
        }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// Liste des actions utilisant cette requête.
        /// </summary>
        public List<ActionDetail> ActionDetailList { get; set; }

        #endregion
    }
}