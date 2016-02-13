using Procbel.Apps.Silverlight.Theme;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure
{
    public class ValueExceedingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush myBrush = new SolidColorBrush();
            if ((int)value > 100)
            {
                myBrush.Color = Colors.Red;
                return myBrush;
            }
            else
            {
                myBrush.Color = Color.FromArgb(254,31, 135, 184);
                return myBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
