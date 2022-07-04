namespace EntityFrameworkLayer6.Entities
{
    /// <summary>
    /// Produit.
    /// </summary>
    public class Product
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
        /// Quantité.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Identifiant de la catégorie.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Catégorie associée.
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
