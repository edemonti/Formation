using System.Collections.Generic;

namespace EntityFrameworkLayer.ExecuteDto
{
    /// <summary>
    /// Dto de mise à jour d’une entité <see cref="Entities.Element"/>.
    /// </summary>
    public class ElementExecuteDto : BaseExecuteDto
    {
        #region Constructors

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ElementExecuteDto()
            : base()
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ElementExecuteDto(bool isReturnEntityEnabled, bool isSaveEnabled, List<string> includes)
            : base(isReturnEntityEnabled, isSaveEnabled, includes)
        {
        }

        #endregion
    }
}
