using System.Collections.Generic;

namespace Models.ExecuteDto
{
    /// <summary>
    /// Classe de base des ExecuteDtos.
    /// </summary>
    public class BaseExecuteDto
    {
        #region Properties 

        /// <summary>
        /// Flag indiquant s’il faut rechercher l’entité après sa mise à jour.
        /// </summary>
        public bool IsReturnEntityEnabled { get; set; }

        /// <summary>
        /// Flag indiquant si la sauvegarde doit être réalisée à la fin de la méthode</param>
        /// </summary>
        public bool IsSaveEnabled { get; set; }

        /// <summary>
        /// Liste des includes à retourner si le flag <see cref="IsReturnEntityEnabled"/> est à true.
        /// </summary>
        public List<string> Includes { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur.
        /// </summary>
        public BaseExecuteDto()
            : this(true, true, null)
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        public BaseExecuteDto(bool isReturnEntityEnabled, bool isSaveEnabled, List<string> includes)
        {
            IsReturnEntityEnabled = isReturnEntityEnabled;
            IsSaveEnabled = isSaveEnabled;
            Includes = includes;
        }

        #endregion
    }
}