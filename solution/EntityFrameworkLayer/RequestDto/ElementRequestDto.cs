﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkLayer.RequestDto
{
    /// <summary>
    /// Dto de recherche d’une entité <see cref="Entities.Element"/>.
    /// </summary>
    public class ElementRequestDto
    {
        #region Properties

        /// <summary>
        /// Voir <see cref="Entities.Element.Id"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.Id"/>.
        /// </summary>
        public IList<int> IdList { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.Name"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.Description"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.DueDate"/>.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.ResolutionPercent"/>.
        /// </summary>
        public int ResolutionPercent { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.IsReminder"/>.
        /// </summary>
        public bool IsReminder { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.IsFavorite"/>.
        /// </summary>
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Voir <see cref="Entities.Element.IsClosed"/>.
        /// </summary>
        public bool IsClosed { get; set; }

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
        /// Flag indiquant si la propriété <see cref="Description"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedDescription { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="DueDate"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedDueDate { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="ResolutionPercent"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedResolutionPercent { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="IsReminder"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedIsReminder { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="IsFavorite"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedIsFavorite { get; set; }

        /// <summary>
        /// Flag indiquant si la propriété <see cref="IsClosed"/> est spécifiée.
        /// </summary>
        public bool IsSpecifiedIsClosed { get; set; }

        #endregion
    }
}