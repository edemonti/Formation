using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PresentationLayer.Converter
{
    /// <summary>
    /// Converter permettant de convertir un <see cref="Boolean"/> en <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(Boolean), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Détermine l’image à afficher en fonction de l’état du modèle.
        /// </summary>
        /// <param name="value">État</param>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}