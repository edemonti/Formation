namespace Models.RequestDto
{
    /// <summary>
    /// Dto de contrôle d’une entité <see cref="Element"/>.
    /// </summary>
    public class ElementCheckDto
    {
        /// <summary>
        /// Flag indiquant si toutes les propriétés doivent être contrôlées.
        /// </summary>
        public bool IsCheckedAll { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.Id"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedId { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.Name"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedName { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.Description"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedDescription { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.DueDate"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedDueDate { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.ResolutionPercent"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedResolutionPercent { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.IsReminder"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedIsReminder { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.IsFavorite"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedIsFavorite { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="Element.IsClosed"/> doit être contrôlée.
        /// </summary>
        public bool IsCheckedIsClosed { get; set; }
    }
}