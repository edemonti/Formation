using System.Collections.Generic;

namespace Models.Impl.ExecuteDto
{
    /// <summary>
    /// Classe de base des Dto d’exécution.
    /// </summary>
    public class BaseExecuteDto
    {
        #region Properties 

        /// <summary>
        /// Flag indiquant s’il faut rechercher l’entité après sa création.
        /// </summary>
        public bool ReturnEntity { get; set; }

        /// <summary>
        /// Liste des includes à retourner si le flag "ReturnEntity" est à true.
        /// </summary>
        public List<string> Includes { get; set; }

        #endregion

        #region Properties 
        public BaseExecuteDto()
        {
            ReturnEntity = false;
            Includes = new List<string>();
        }

        #endregion

    }
}