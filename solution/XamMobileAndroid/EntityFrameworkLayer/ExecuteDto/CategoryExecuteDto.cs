using System.Collections.Generic;

namespace EntityFrameworkLayer.ExecuteDto
{
    /// <summary>
    /// Dto de mise à jour d’une entité <see cref="Entities.Category"/>.
    /// </summary>
    public class CategoryExecuteDto : BaseExecuteDto
    {
        #region Constructors

        /// <summary>
        /// Constructeur.
        /// </summary>
        public CategoryExecuteDto()
            : base()
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        public CategoryExecuteDto(bool isReturnEntityEnabled, bool isSaveEnabled, List<string> includes)
            : base(isReturnEntityEnabled, isSaveEnabled, includes)
        {
        }

        #endregion
    }
}
