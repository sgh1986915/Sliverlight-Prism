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

namespace Procbel.Apps.Silverlight.Infrastructure.Converters
{
    public class StatusToDataTemplateConverter : IValueConverter
    {
        private static readonly ResourceDictionary resourceDictionary;

        static StatusToDataTemplateConverter()
        {
            // assumes that a reference to RadGridView's assemblies have been loaded
            resourceDictionary = new ResourceDictionary() { Source = new Uri("/Procbel.Apps.Silverlight.Theme;component/Styles/RadGridViewStyle.xaml", UriKind.Relative) };
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return resourceDictionary["ActivityNotStartedDataTemplate"] as DataTemplate;
            }

            switch (value.ToString())
            {
                case "0":
                    return resourceDictionary["ActivityNotStartedDataTemplate"] as DataTemplate;
                case "1":
                    return resourceDictionary["ActivityInProgressDataTemplate"] as DataTemplate;
                case "2":
                    return resourceDictionary["ActivityDoneDataTemplate"] as DataTemplate;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
