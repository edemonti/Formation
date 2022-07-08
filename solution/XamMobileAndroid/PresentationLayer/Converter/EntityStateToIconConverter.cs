using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PresentationLayer.Converter
{
    /// <summary>
    /// Converter permettant d’afficher une image en fonction de l’état de l’entité.
    /// </summary>
    [ValueConversion(typeof(EntityState), typeof(BitmapSource))]
    public class EntityStateToIconConverter : IValueConverter
    {
        /// <summary>
        /// Détermine l’image à afficher en fonction de l’état de l’entité.
        /// </summary>
        /// <param name="value">État</param>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imgPath = string.Empty;
            if (value is EntityState state)
            {
                switch (state)
                {
                    case EntityState.Added:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/add.ico";
                        break;
                    case EntityState.Modified:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/edit.ico";
                        break;
                    case EntityState.Deleted:
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
