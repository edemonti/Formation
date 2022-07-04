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
    [ValueConversion(typeof(MessageType), typeof(BitmapSource))]
    public class MessageTypeToIconConverter : IValueConverter
    {
        /// <summary>
        /// Détermine l’image à afficher en fonction de l’état du modèle.
        /// </summary>
        /// <param name="value">État</param>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imgPath = string.Empty;
            if (value is MessageType type)
            {
                switch (type)
                {
                    case MessageType.Information:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/information.ico";
                        break;
                    case MessageType.Warning:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/warning.ico";
                        break;
                    case MessageType.Error:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/error.ico";
                        break;
                    case MessageType.Success:
                        imgPath = @"pack://application:,,,/PresentationLayer;component/Images/success.ico";
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
