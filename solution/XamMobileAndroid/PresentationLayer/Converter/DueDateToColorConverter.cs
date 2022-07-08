using System;
using System.Globalization;
using System.Windows.Data;

namespace PresentationLayer.Converter
{
    /// <summary>
    /// Converter permettant d’afficher une couleur en fonction d’une date d’échéance.
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DueDateToColorConverter : IValueConverter
    {
        /// <summary>
        /// Détermine la couleur de retour en fonction de la date d’échéance : 
        ///   - si la date d’échéance est absente : #000 (noir)
        ///   - si la date est dépassée : #F00 (rouge)
        ///   - si la date d’échéance correspond à la date du jour : #FC0 (jaune)
        ///   - si la date d’échéance est inférieure à la date du jour : #0F0 (vert)
        /// </summary>
        /// <param name="value">Date d’échéance</param>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime dateToCompare))
                return "#000";

            // Récupération du nombre de jours entre la date passée en paramètre et la date du jour.
            int days = (int)(DateTime.Today - dateToCompare).TotalDays;

            if (days < 0)
                return "#F00";
            else if (days == 0)
                return "#FC0";
            else
                return "#0F0";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
