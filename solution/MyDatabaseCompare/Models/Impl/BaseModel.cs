using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.Impl
{
    /// <summary>
    /// Classe de base des models.
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Évènement indiquant qu’une propriété a été modifiée.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode permettant de lancer l’évènement 
        /// <seealso cref="PropertyChanged"/> sur le propriété de nom <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">Le nom de la propriété qui a été modifiée.</param>
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        /// <param name="propertyName">Paramètre valorisé automatiquement grâce à l’attribut
        /// CallerMemberName</param>
        /// <returns>Indique si l’assignation a eu lieu</returns>
        protected virtual bool SetField<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

    }
}