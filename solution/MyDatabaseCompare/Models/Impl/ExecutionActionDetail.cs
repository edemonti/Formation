using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Models.Impl
{
    /// <summary>
    /// Détail d’exécution d’une action.
    /// </summary>
    public class ExecutionActionDetail : BaseModel
    {
        #region Private fields

        private int id;
        private int idExecutionAction;
        private DataTable dataTable;
        private DataSet dataSet;
        private string digitalSignature;
        private int count;

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
        /// Identifiant de l’action associée au détail.
        /// </summary>
        [Required]
        public int IdExecutionAction
        {
            get { return idExecutionAction; }
            set { SetField(ref idExecutionAction, value); }
        }

        /// <summary>
        /// Résultat de la requête sout la forme d’un objet "DataTable".
        /// </summary>
        public DataTable DataTable
        {
            get { return dataTable; }
            set { SetField(ref dataTable, value); }
        }

        /// <summary>
        /// Résultat de la requête sous la forme d’un objet "DataSet".
        /// </summary>
        public DataSet DataSet
        {
            get { return dataSet; }
            set { SetField(ref dataSet, value); }
        }

        /// <summary>
        /// Signature numérique du résultat de la requête.
        /// </summary>
        public string DigitalSignature
        {
            get { return digitalSignature; }
            set { SetField(ref digitalSignature, value); }
        }

        /// <summary>
        /// Nombre d’enregistrements retournés par la requête.
        /// </summary>
        public int Count
        {
            get { return count; }
            set { SetField(ref count, value); }
        }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// Action associée au détail.
        /// </summary>
        [Required]
        public ExecutionAction ExecutionAction { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Initialisation des propriétés de navigation.
        /// </summary>
        public ExecutionActionDetail()
        {
            this.DataTable = new DataTable();
            this.DataSet = new DataSet();
        }

        #endregion
    }
}