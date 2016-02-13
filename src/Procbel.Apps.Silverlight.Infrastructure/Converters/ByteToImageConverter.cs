using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Infrastructure.Converters
{
    public class ByteToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage image = new BitmapImage();
            if (value != null && value is byte[])
            {
                MemoryStream stream = new MemoryStream(value as byte[]);
                image.SetSource(stream);
            }
            else if (value == null && parameter.ToString().Length > 0)
            {

                image.UriSource = new Uri((parameter as TextBlock).Text, UriKind.Relative);
            }
            return image;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
