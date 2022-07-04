using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Technical.Enums;

namespace PresentationLayer.Converter
{
    /// <summary>
    /// Converter permettant d’afficher une image en fonction de l’état du modèle.
    /// </summary>
    [ValueConversion(typeof(ModelState), typeof(BitmapSource))]
    public class ModelStateToIconConverter : IValueConverter
    {
        /// <summary>
        /// Détermine l’image à afficher en fonction de l’état du modèle.
        /// </summary>
        /// <param name="value">État</param>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imgPath = string.Empty;
            if (value is ModelState state)
            {
                switch (state)
                {
                    case ModelState.Added:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/add.ico";
                        break;
                    case ModelState.Modified:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/edit.ico";
                        break;
                    case ModelState.Deleted:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/delete.ico";
                        break;
                    default:
                        break;
                }
            }
            return string.IsNullOrEmpty(imgPath) ? null : new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
