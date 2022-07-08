using System.Collections.Generic;

namespace EntityFrameworkLayer.ExecuteDto
{
    /// <summary>
    /// Dto de mise à jour d’une entité <see cref="Entities.Product"/>.
    /// </summary>
    public class ProductExecuteDto : BaseExecuteDto
    {
        #region Constructors

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ProductExecuteDto()
            : base()
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        public ProductExecuteDto(bool isReturnEntityEnabled, bool isSaveEnabled, List<string> includes)
            : base(isReturnEntityEnabled, isSaveEnabled, includes)
        {
        }

        #endregion
    }
}
