﻿using EntityFrameworkLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Technical.Messages;

namespace Technical.ViewModels
{
    /// <summary>
    /// Classe de base des ViewModels.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region Protected Fields

        /// <summary>
        /// Voir <see cref="MyFormationContext"/>.
        /// </summary>
        protected MyFormationContext Context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur de la classe permettant la création du contexte.
        /// </summary>
        public BaseViewModel(string connectionName)
        {
            var options = new DbContextOptionsBuilder<MyFormationContext>().Options;
            // var options = new DbContextOptionsBuilder<MyFormationContext>().UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            Context = new MyFormationContext(options, connectionName);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Flag indiquant si la popup affichant les messages métiers est visible.
        /// </summary>
        private bool _isBusinessMessageVisible;
        public bool IsBusinessMessageVisible
        {
            get => _isBusinessMessageVisible;
            set => SetField(ref _isBusinessMessageVisible, value);
        }

        /// <summary>
        /// Exception métiers.
        /// </summary>
        private BusinessMessage _businessMessage;
        public BusinessMessage BusinessMessage
        {
            get => _businessMessage;
            set
            {
                SetField(ref _businessMessage, value);
                IsBusinessMessageVisible = _businessMessage != null;
            }
        }

        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Évènement indiquant qu’une propriété a été modifiée.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
            return true;
        }

        #endregion
    }
}