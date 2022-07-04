namespace EntityFrameworkLayer.RequestDto
{
    /// <summary>
    /// Dto de contrôle d’une entité <see cref="Entities.Element"/>.
    /// </summary>
    public class ElementCheckDto
    {
        /// <summary>
        /// Flag indiquant si toutes les propriétés doivent être contrôlées.
        /// </summary>
        public bool IsCheckedAll { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.Id"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedId { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.Name"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedName { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.Description"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedDescription { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.DueDate"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedDueDate { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.ResolutionPercent"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedResolutionPercent { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.IsReminder"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedIsReminder { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.IsFavorite"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedIsFavorite { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Entities.Element.IsClosed"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedIsClosed { get; set; }
    }
}