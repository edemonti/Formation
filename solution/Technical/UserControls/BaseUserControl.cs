using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Technical.UserControls
{
    /// <summary>
    /// Classe de base des UserControls.
    /// </summary>
    public class BaseUserControl : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        /// <summary>
        /// Évènement indiquant qu’une propriété a été modifiée.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode destinée à être utilisée dans les setter de propriétés. Elle permet d’assigner
        /// la valeur <paramref name="value"/> à la propriété <paramref name="property"/>.
        /// Suite à ça, RaisePropertyChanged() est appelé pour indiquer que la propriété associée a été modifiée.
        /// </summary>
        protected virtual void SetValueDp(DependencyProperty property, object value, [CallerMemberName] string p = null)
        {
            SetValue(property, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        #endregion
    }
}