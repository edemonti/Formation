using System.Collections.Generic;

namespace EntityFrameworkLayer.RequestDto
{
    /// <summary>
    /// Dto de recherche d’une entité <see cref="Entities.Category"/>.
    /// </summary>
    public class CategoryRequestDto
    {
        #region Properties

        /// <summary>
        /// Voir <see cref="Entities.Category.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Category.Id"/>.
        /// </summary>
        public IList<int> IdList { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Category.Name"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Product.Id"/>.
        /// </summary>
        public int ProductId { get; set; }

        #endregion

        #region IsSpecified

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Id"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedId { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="IdList"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedIdList { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Name"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedName { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="ProductId"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedProductId { get; set; }

        #endregion
    }
}