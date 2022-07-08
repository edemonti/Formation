using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Impl
{
    /// <summary>
    /// Liste des connexions aux différentes bases de données disponibles.
    /// </summary>
    public class Connection : BaseModel
    {
        #region Private fields

        private int id;
        private string name;
        private string provider;
        private bool isProviderImplemented;
        private string connectionString;

        #endregion

        #region Properties

        /// <summary>
        /// Identifiant unique de la connexion.
        /// </summary>
        [Required]
        public int Id
        {
            get { return id; }
            set { SetField(ref id, value); }
        }

        /// <summary>
        /// Nom de la connexion.
        /// </summary>
        [Required]
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }

        /// <summary>
        /// Type de base de données (Oracle, PostgreSql...).
        /// </summary>
        [Required]
        public string Provider
        {
            get { return provider; }
            set { SetField(ref provider, value); }
        }

        /// <summary>
        /// Flag indiquant si le fournisseur de base de données a été implémenté.
        /// </summary>
        public bool IsProviderImplemented
        {
            get { return isProviderImplemented; }
            set { SetField(ref isProviderImplemented, value); }
        }

        /// <summary>
        /// Chaîne de connexion vers la base de données.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { SetField(ref connectionString, value); }
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