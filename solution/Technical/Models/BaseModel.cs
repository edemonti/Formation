using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Technical.Enums;

namespace Technical.Models
{
    /// <summary>
    /// Classe de base des Models.
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {
        #region Properties 

        /// <summary>
        /// État du modèle.
        /// </summary>
        private ModelState _state;
        public virtual ModelState State
        {
            get => _state;
            set
            {
                SetField(ref _state, value);
                RaisePropertyChanged("IsReadOnly");
                RaisePropertyChanged("IsEnabled");
            }
        }

        /// <summary>
        /// Flag indiquant si l’enregistrement est en lecture seul.
        /// </summary>
        private bool _isReadOnly;
        public virtual bool IsReadOnly
        {
            get => _isReadOnly;
            set => SetField(ref _isReadOnly, value);
        }

        /// <summary>
        /// Flag indiquant si l’enregistrement est modifiable.
        /// </summary>
        private bool _isEnabled;
        public virtual bool IsEnabled
        {
            get => _isEnabled;
            set => SetField(ref _isEnabled, value);
        }

        /// <summary>
        /// Flag indiquant si la modification de l’état de l’enregistrement est activée.
        /// </summary>
        public bool IsChangeStateActivated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public BaseModel()
            : this(ModelState.Unchanged, false, true, false)
        {
        }

        /// <summary>
        /// Initialisation des propriétés de la classe.
        /// </summary>
        public BaseModel(ModelState state, bool isReadOnly, bool isEnabled, bool isChangeStateActivated)
        {
            _state = state;
            _isReadOnly = isReadOnly;
            _isEnabled = isEnabled;
            IsChangeStateActivated = isChangeStateActivated;
        }

        #endregion

        #region Events

        /// <summary>
        /// Évènement indiquant qu’une propriété a été modifiée.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Méthode permettant de lancer l’évènement <seealso cref="PropertyChanged"/>
        /// sur le propriété de nom <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">Le nom de la propriété qui a été modifiée</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Méthode destinée à être utilisée dans les setter de propriétés. Elle permet d’assigner
        /// la valeur <paramref name="value"/> au champ <paramref name="field"/> si la valeur de ce
        /// dernier est différente de celle passée en paramètre. Suite à ça, RaisePropertyChanged()
        /// est appelé pour indiquer que la propriété associée a été modifiée.
        /// </summary>
        /// <typeparam name="T">Type de l’objet encapsulé par la propriété appelante</typeparam>
        /// <param name="field">Référence vers le champ de stockage de la propriété</param>
        /// <param name="value">Valeur à assigner</param>
        /// <param name="propertyName">Paramètre valorisé automatiquement grâce à l’attribut CallerMemberName</param>
        /// <returns>Indique si l’assignation a eu lieu</returns>
        protected virtual bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            RaisePropertyChanged(propertyName);

            // Modification de l’état.
            if (IsChangeStateActivated && !new[] { ModelState.Added, ModelState.Deleted }.Contains(State))
                State = ModelState.Modified;

            return true;
        }

        #endregion

    }
}