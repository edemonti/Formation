namespace Models.Technical
{
    public class Context
    {
        /// <summary>
        /// Fichier xml contenant les entités<see cref="Action"/>
        /// </summary>
        public string ActionXmlFile { get; set; }

        /// <summary>
        /// Fichier xml contenant les entités<see cref="ActionDetail"/>.
        /// </summary>
        public string ActionDetailXmlFile { get; set; }

        /// <summary>
        /// Fichier xml contenant les entités <see cref="Connection"/>.
        /// </summary>
        public string ConnectionXmlFile { get; set; }

        /// <summary>
        /// Fichier xml contenant les entités <see cref="Action"/>.
        /// </summary>
        public string ExecutionActionXmlFile { get; set; }

        /// <summary>
        /// Fichier xml contenant les entités <see cref="ExecutionActionDetail"/>.
        /// </summary>
        public string ExecutionActionDetailXmlFile { get; set; }

        /// <summary>
        /// Fichier xml contenant les entités <see cref="Query"/>.
        /// </summary>
        public string QueryXmlFile { get; set; }

        /// <summary>
        /// Initialisation du contexte.
        /// </summary>
        public void InitializeContext()
        {
            ActionXmlFile = @"D:\Utilisateurs\EMDI.NETDOM\Desktop\Nouveau dossier (2)\MyDatabaseCompare\Models\Ressources\action.xml";
            ConnectionXmlFile = @"D:\Utilisateurs\EMDI.NETDOM\Desktop\Nouveau dossier (2)\MyDatabaseCompare\Models\Ressources\connection.xml";
            ActionDetailXmlFile = @"D:\Utilisateurs\EMDI.NETDOM\Desktop\Nouveau dossier (2)\MyDatabaseCompare\Models\Ressources\actionDetail.xml";
            ExecutionActionXmlFile = @"D:\Utilisateurs\EMDI.NETDOM\Desktop\Nouveau dossier (2)\MyDatabaseCompare\Models\Ressources\executionAction.xml";
            ExecutionActionDetailXmlFile = @"D:\Utilisateurs\EMDI.NETDOM\Desktop\Nouveau dossier (2)\MyDatabaseCompare\Models\Ressources\executionActionDetail.xml";
            QueryXmlFile = @"D:\Utilisateurs\EMDI.NETDOM\Desktop\Nouveau dossier (2)\MyDatabaseCompare\Models\Ressources\query.xml";
        }
    }
}