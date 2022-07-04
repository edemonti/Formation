using System.Collections.Generic;

namespace EntityFrameworkLayer.RequestDto
{
    /// <summary>
    /// Dto de recherche d’une entité <see cref="Entities.Product"/>.
    /// </summary>
    public class ProductRequestDto
    {
        #region Properties

        /// <summary>
        /// Voir <see cref="Entities.Product.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Product.Id"/>.
        /// </summary>
        public IList<int> IdList { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Product.Name"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Product.Quantity"/>.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Product.CategoryId"/>.
        /// </summary>
        public int CategoryId { get; set; }

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
        /// Flag indiquant si la propriété <see cref="Quantity"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedQuantity { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="CategoryId"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedCategoryId { get; set; }

        #endregion
    }
}