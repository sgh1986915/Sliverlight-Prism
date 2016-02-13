using Microsoft.Practices.Prism.Regions;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Infrastructure.Extensions
{
    public static class IRegionExtensions
    {
        public static void ClearActiveViews(this IRegion region)
        {
            foreach (var v in region.ActiveViews)
            {
                region.Deactivate(v);
            }
        }

        public static void RemoveActiveViews(this IRegion region)
        {
            foreach (var v in region.ActiveViews)
            {
                region.Remove(v);
            }
        }
    }
}
