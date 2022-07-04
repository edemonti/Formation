using System;
using System.ComponentModel.DataAnnotations;
using Technical.Enums;
using Technical.Models;

namespace Models
{
    /// <summary>
    /// Entité Tâche.
    /// </summary>
    public partial class Element : BaseModel, IEquatable<Element>, ICloneable
    {
        #region Properties 

        /// <summary>
        /// Identifiant technique.
        /// </summary>
        [Required]
        private int _id;
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        /// <summary>
        /// Nom.
        /// </summary>
        [Required]
        private string _name;
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Description.
        /// </summary>
        private string _description;
        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        /// <summary>
        /// Date d’échance.
        /// </summary>
        private DateTime? _dueDate;
        public DateTime? DueDate
        {
            get => _dueDate;
            set
            {
                // Validation Rule.
                if (value.GetValueOrDefault() != DateTime.MinValue && value.GetValueOrDefault().CompareTo(new DateTime(2000, 1, 1)) < 0)
                    throw new ArgumentException("La date d’échéance doit être supérieure au 01/01/2000.");
                SetField(ref _dueDate, value);
            }
        }

        /// <summary>
        /// Pourcentage de résolution de la tâche.
        /// </summary>
        private int _resolutionPercent;
        public int ResolutionPercent
        {
            get => _resolutionPercent;
            set => SetField(ref _resolutionPercent, value);
        }

        /// <summary>
        /// Flag indiquant si un rappel est actif.
        /// </summary>
        private bool _isReminder;
        public bool IsReminder
        {
            get => _isReminder;
            set => SetField(ref _isReminder, value);
        }

        /// <summary>
        /// Flag indiquant si la tâche doit apparaître dans les favoris.
        /// </summary>
        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set => SetField(ref _isFavorite, value);
        }

        /// <summary>
        /// Flag indiquant si la tâche a été fermée.
        /// </summary>
        private bool _isClosed;
        public bool IsClosed
        {
            get => _isClosed;
            set => SetField(ref _isClosed, value);
        }

        /// <summary>
        /// Voir <see cref="BaseModel.IsReadOnly"/>.
        /// </summary>
        public override bool IsReadOnly => State == ModelState.Deleted;

        /// <summary>
        /// Voir <see cref="BaseModel.IsEnabled"/>.
        /// </summary>
        public override bool IsEnabled => State != ModelState.Deleted;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public Element(int id, string name, string description, DateTime? dueDate, int resolutionPercent, bool isReminder, bool isFavorite, bool isClosed)
            : base()
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

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public Element(int id, string name, string description)
            : this(id, name, description, null, 0, false, false, false)
        {
        }

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public Element(int id, string name)
            : this(id, name, null, null, 0, false, false, false)
        {
        }

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public Element(int id, string name, ModelState state)
            : this(id, name, null, null, 0, false, false, false)
        {
            base.State = state;
        }

        #endregion

        #region IEquatable

        bool IEquatable<Element>.Equals(Element other)
        {
            return other is Element Element && Equals(Element);
        }

        public bool Equals(Element other)
        {
            return Id.Equals(other.Id);
        }

        #endregion

        #region ICloneable

        public Element Clone()
        {
            Element Element = new Element(_id, _name, _description, _dueDate, _resolutionPercent, _isReminder, _isFavorite, _isClosed);
            Element.State = base.State;
            Element.IsReadOnly = base.IsReadOnly;
            Element.IsEnabled = this.IsEnabled;
            return Element;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

    }
}
