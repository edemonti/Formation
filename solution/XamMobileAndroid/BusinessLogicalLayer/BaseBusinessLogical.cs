using System.Xml.Linq;
using EntityFrameworkLayer.Context;

namespace BusinessLogicalLayer
{
    /// <summary>
    /// Voir <see cref="IBaseBusinessLogicalLayer"/>.
    /// </summary>
    public class BaseBusinessLogical<T, R, E, C>
        where T : class
        where R : class
        where E : class
        where C : class
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
        public BaseBusinessLogical(MyFormationContext context)
        {
            Context = context;
            //_storeFile = $@"{_context.Database.GetDbConnection().ConnectionString}element.xml";
        }

        #endregion

    }
}
