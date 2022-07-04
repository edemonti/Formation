using System.Collections.Generic;

namespace EntityFrameworkLayer6.Entities
{
    /// <summary>
    /// Catégorie.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identifiant technique.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Liste des produits.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}