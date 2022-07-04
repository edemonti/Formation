using System;
using EntityFrameworkLayer.Entities;
using Technical.BusinessObjects;

namespace Wpf.BusinessObjects
{
    /// <summary>
    /// Objet utilisé pour la gestion des <see cref="Element"/>.
    /// </summary>
    public class ElementBusinessObject : BaseBusinessObject
    {
        #region Private Fields

        private int _id;
        private string _name;
        private string _description;
        private DateTime? _dueDate;
        private int _resolutionPercent;
        private bool _isReminder;
        private bool _isFavorite;
        private bool _isClosed;

        #endregion

        #region Properties 

        /// <summary>
        /// Voir <see cref="Task.Id"/>.
        /// </summary>
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        /// <summary>
        /// Voir <see cref="Task.Name"/>.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Voir <see cref="Task.Description"/>.
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        /// <summary>
        /// Voir <see cref="Task.DueDate"/>.
        /// </summary>
        public DateTime? DueDate
        {
            get => _dueDate;
            set => SetField(ref _dueDate, value);
        }

        /// <summary>
        /// Voir <see cref="Task.ResolutionPercent"/>.
        /// </summary>
        public int ResolutionPercent
        {
            get => _resolutionPercent;
            set => SetField(ref _resolutionPercent, value);
        }

        /// <summary>
        /// Voir <see cref="Task.IsReminder"/>.
        /// </summary>
        public bool IsReminder
        {
            get => _isReminder;
            set => SetField(ref _isReminder, value);
        }

        /// <summary>
        /// Voir <see cref="Task.IsFavorite"/>.
        /// </summary>
        public bool IsFavorite
        {
            get => _isFavorite;
            set => SetField(ref _isFavorite, value);
        }

        /// <summary>
        /// Voir <see cref="Task.IsClosed"/>.
        /// </summary>
        public bool IsClosed
        {
            get => _isClosed;
            set => SetField(ref _isClosed, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public ElementBusinessObject(int id, string name, string description, DateTime? dueDate, int resolutionPercent, bool isReminder, bool isFavorite, bool isClosed)
        {
            Id = id;
            Name = name;
            Description = description;
            DueDate = dueDate;
            ResolutionPercent = resolutionPercent;
            IsReminder = isReminder;
            IsFavorite = isFavorite;
            IsClosed = isClosed;
        }

        #endregion
    }
}
