using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLayer.Entities
{
    /// <summary>
    /// Produit.
    /// </summary>
    public partial class Product : BaseEntity
    {
        #region Private Fields

        private int _id;
        private string _name;
        private int _quantity;
        private int _categoryId;

        #endregion

        #region Properties

        /// <summary>
        /// Identifiant technique.
        /// </summary>
        [Key]
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        /// <summary>
        /// Nom.
        /// </summary>
        [Required]
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Quantité.
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set => SetField(ref _quantity, value);
        }

        /// <summary>
        /// Identifiant de la catégorie.
        /// </summary>
        public int CategoryId
        {
            get => _categoryId;
            set => SetField(ref _categoryId, value);
        }

        /// <summary>
        /// Catégorie associée.
        /// </summary>
        public virtual Category Category { get; set; }

        #endregion

        #region Constrcutors

        public Product(string name)
           : this(name, 0, 0)

        {
            Name = name;
        }

        public Product(string name, int quantity, int categoryId)
        {
            Name = name;
            Quantity = quantity;
            CategoryId = categoryId;
        }

        public Product()
           : this(null, 0, 0)
        {
        }

        #endregion
    }
}