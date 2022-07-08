using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Impl
{
    /// <summary>
    /// Détail d’une action.
    /// </summary>
    public class ActionDetail: BaseModel
    {
        #region Private fields

        private int id;
        private int idAction;
        private int idConnection;
        private int idQuery;
        private string where;
        private bool isExportCsvEnabled;
        private bool isExportxmlEnabled;

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
        public int IdAction
        {
            get { return idAction; }
            set { SetField(ref idAction, value); }
        }

        /// <summary>
        /// Identifiant de la connexion.
        /// </summary>
        [Required]
        public int IdConnection
        {
            get { return idConnection; }
            set { SetField(ref idConnection, value); }
        }

        /// <summary>
        /// Identifiant de la requête à exécuter.
        /// </summary>
        [Required]
        public int IdQuery
        {
            get { return idQuery; }
            set { SetField(ref idQuery, value); }
        }

        /// <summary>
        /// Clause where à appliquer à la requête.
        /// </summary>
        public string Where
        {
            get { return where; }
            set { SetField(ref where, value); }
        }

        /// <summary>
        /// Flag indiquant si l’export CSV de la requête est activée.
        /// </summary>
        public bool IsExportCsvEnabled
        {
            get { return isExportCsvEnabled; }
            set { SetField(ref isExportCsvEnabled, value); }
        }

        /// <summary>
        /// Flag indiquant si l’export XML de la requête est activée.
        /// </summary>
        public bool IsExportXmlEnabled
        {
            get { return isExportxmlEnabled; }
            set { SetField(ref isExportxmlEnabled, value); }
        }

        /// <summary>
        /// Nom du fichier contenant le résultat de la requête.
        /// </summary>
        public string FileName
        {
            get
            {
                return string.Format(@"{0}_{1}_{2}_{3}", Id, Query.Name, Connection.Name, DateTime.Now.ToString("yyyyMMdd"));
            }
        }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// Action associée au détail.
        /// </summary>
        [Required]
        public Action Action { get; set; }

        /// <summary>
        /// Connection à appliquer lors de l’exécution de la requête.
        /// </summary>
        [Required]
        public Connection Connection { get; set; }

        /// <summary>
        /// Requête à exécuter.
        /// </summary>
        [Required]
        public Query Query { get; set; }

        #endregion

    }
}