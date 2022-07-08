using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Impl
{
    /// <summary>
    /// Résultats d’exécution des actions.
    /// </summary>
    public class ExecutionAction: BaseModel
    {
        #region Private fields

        private int id;
        private int idAction;
        private int idExecutionActionDetail1;
        private int idExecutionActionDetail2;
        private DateTime executionDate;
        private string errorMessage;

        #endregion

        #region Properties

        /// <summary>
        /// Identifiant unique.
        /// </summary>
        [Required]
        public int Id
        {
            get { return id; }
            set { SetField(ref id, value); }
        }

        /// <summary>
        /// Action traitée
        /// </summary>
        [Required]
        public int IdAction
        {
            get { return idAction; }
            set { SetField(ref idAction, value); }
        }

        /// <summary>
        /// Détail de l’exécution de la première action.
        /// </summary>
        [Required]
        public int IdExecutionActionDetail1
        {
            get { return idExecutionActionDetail1; }
            set { SetField(ref idExecutionActionDetail1, value); }
        }

        /// <summary>
        /// Détail de l’exécution de la deuxième action.
        /// </summary>
        [Required]
        public int IdExecutionActionDetail2
        {
            get { return idExecutionActionDetail2; }
            set { SetField(ref idExecutionActionDetail2, value); }
        }

        /// <summary>
        /// Date d’exécution de l’action.
        /// </summary>
        public DateTime ExecutionDate
        {
            get { return executionDate; }
            set { SetField(ref executionDate, value); }
        }

        /// <summary>
        /// Flag indiquant si le résultat des requêtes des deux actions sont identiques.
        /// </summary>
        public bool? IsActionsEquals
        {
            get
            {
                if (ExecutionActionDetail1 == null ||
                    ExecutionActionDetail2 == null ||
                    string.IsNullOrEmpty(ExecutionActionDetail1.DigitalSignature) ||
                    string.IsNullOrEmpty(ExecutionActionDetail2.DigitalSignature))
                {
                    return null;
                }
                else
                {
                    return ExecutionActionDetail1.DigitalSignature.CompareTo(ExecutionActionDetail2.DigitalSignature) == 0;
                }
            }
        }

        /// <summary>
        /// Message d’erreur remontée lors du traitement de l’action.
        ///</summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetField(ref errorMessage, value); }
        }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// Action traitée.
        /// </summary>
        [Required]
        public Action Action { get; set; }

        /// <summary>
        /// Détail de l’exécution de la première action.
        /// </summary>
        [Required]
        public ExecutionActionDetail ExecutionActionDetail1 { get; set; }

        /// <summary>
        /// Détail de l’exécution de la deuxième action.
        /// </summary>
        [Required]
        public ExecutionActionDetail ExecutionActionDetail2 { get; set; }

        #endregion

    }
}