using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLayer.Entities
{
    /// <summary>
    /// Catégorie.
    /// </summary>
    public partial class Category : BaseEntity
    {
        #region Private Fields

        private int _id;
        private string _name;
        private string _email;

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
        [Required, MaxLength(25)]
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Email (pour test).
        /// </summary>
        [EmailAddress]
        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        /// <summary>
        /// Liste des produits associées à la catégorie.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        #endregion

        #region Constructors

        public Category(string name)
        {
            Name = name;
        }

        public Category()
            : this(null)
        {
        }

        #endregion

    }
}