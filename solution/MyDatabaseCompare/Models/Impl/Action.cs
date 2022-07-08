using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Impl
{
    /// <summary>
    /// Liste des actions pouvant être traitées.
    /// </summary>
    public class Action : BaseModel
    {

        #region Private fields

        private int id;
        private int idActionDetail1;
        private int idActionDetail2;
        private bool isActionEnabled;

        #endregion

        #region Properties

        /// <summary>
        /// Identifiant unique de l’action.
        /// </summary>
        [Required]
        public int Id
        {
            get { return id; }
            set { SetField(ref id, value); }
        }

        /// <summary>
        /// Identifiant unique du détail 1 de l’action.
        /// </summary>
        [Required]
        public int IdActionDetail1
        {
            get { return idActionDetail1; }
            set { SetField(ref idActionDetail1, value); }
        }

        /// <summary>
        /// Identifiant unique du détail 2 de l’action.
        /// </summary>
        [Required]
        public int IdActionDetail2
        {
            get { return idActionDetail2; }
            set { SetField(ref idActionDetail2, value); }
        }

        /// <summary>
        /// Flag indiquant si l’action est activée.
        /// </summary>
        [Required]
        public bool IsActionEnabled
        {
            get { return isActionEnabled; }
            set { SetField(ref isActionEnabled, value); }
        }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// Détail de la première action à traiter.
        /// </summary>
        [Required]
        public ActionDetail ActionDetail1 { get; set; }

        /// <summary>
        /// Détail de la deuxième action à traiter.
        /// </summary>
        [Required]
        public ActionDetail ActionDetail2 { get; set; }

        /// <summary>
        /// Liste des résultats d’exécution de cette action.
        /// </summary>
        public List<ExecutionAction> ExecutionActionList { get; set; }

        #endregion

    }
}