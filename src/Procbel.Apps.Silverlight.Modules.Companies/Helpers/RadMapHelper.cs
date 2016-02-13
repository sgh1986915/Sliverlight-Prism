using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Procbel.Apps.Silverlight.Modules.Companies.Helpers
{
    public class RadMapHelper
    {
        // Using a DependencyProperty as the backing store for SearchProvider.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchProviderProperty =
            DependencyProperty.RegisterAttached("SearchProvider", typeof(BingSearchProvider), typeof(RadMapHelper), new PropertyMetadata(null, new PropertyChangedCallback(OnSearchProviderPropertyChanged)));

        // Using a DependencyProperty as the backing store for LocationBestView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LocationBestViewProperty =
            DependencyProperty.RegisterAttached("LocationBestView", typeof(LocationRect), typeof(RadMapHelper), new PropertyMetadata(OnLocationBestViewPropertyChanged));

        public static BingSearchProvider GetSearchProvider(DependencyObject obj)
        {
            return (BingSearchProvider)obj.GetValue(SearchProviderProperty);
        }

        public static void SetSearchProvider(DependencyObject obj, int value)
        {
            obj.SetValue(SearchProviderProperty, value);
        }

        public static LocationRect GetLocationBestView(DependencyObject obj)
        {
            return (LocationRect)obj.GetValue(LocationBestViewProperty);
        }

        public static void SetLocationBestView(DependencyObject obj, LocationRect value)
        {
            obj.SetValue(LocationBestViewProperty, value);
        }

        private static void OnSearchProviderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var map = d as RadMap;
            var searchProvider = e.NewValue as BingSearchProvider;

            searchProvider.MapControl = map;
        }

        private static void OnLocationBestViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RadMap).SetView((LocationRect)e.NewValue);
        }
    }
}
