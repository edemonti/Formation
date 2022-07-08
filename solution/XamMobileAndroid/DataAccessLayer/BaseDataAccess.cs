using System.Xml.Linq;
using EntityFrameworkLayer.Context;

namespace DataAccessLayer
{
    /// <summary>
    /// Voir <see cref="IBaseDataAccess"/>.
    /// </summary>
    public class BaseDataAccess<T, R, E>
        where T : class
        where R : class
        where E : class
    {

        #region Protected Fields

        /// <summary>
        /// Voir <see cref="MyFormationContext"/>.
        /// </summary>
        protected readonly MyFormationContext Context;

        /// <summary>
        /// Fichier xml contenant la liste des tâches.
        /// </summary>
        protected readonly string StoreFile;

        /// <summary>
        /// Document Xml contenant la liste des tâches.
        /// </summary>
        protected XDocument XDocument;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public BaseDataAccess(MyFormationContext context)
        {
            Context = context;
            //_storeFile = $@"{_context.Database.GetDbConnection().ConnectionString}element.xml";
        }

        #endregion

    }
}