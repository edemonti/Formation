using System;
using System.Globalization;
using System.Windows.Data;

namespace PresentationLayer.Converter
{
    /// <summary>
    /// Converter permettant de convertir une date en chaîne de caractère.
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeToStringConverter : IValueConverter
    {
        /// <summary>
        /// Convertion d’une date en texte.
        /// </summary>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
                return date == DateTime.MinValue ? null : date.ToString(parameter.ToString());
            else
                return null;
        }

        /// <summary>
        /// Convertion d’un texte en date.
        /// </summary>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Distinction des types DateTime? et DateTime.
            if (string.IsNullOrEmpty(value.ToString()))
            {
                if (targetType.Name == typeof(DateTime).Name)
                    return DateTime.MinValue;
                else
                    return null;
            }

            // Si la valeur n’est pas une date, on retourne la valeur car elle est sans doute en cours de saisie.
            return DateTime.TryParse(value.ToString(), out DateTime result) ? result : value;
        }
    }
}
