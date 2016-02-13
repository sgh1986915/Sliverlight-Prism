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

using System.Linq;

namespace Procbel.Apps.Silverlight.Infrastructure.Extensions
{
    public static class PresentationFrameworkCollectionExtensions
    {
        public static void AddIfMissing(this PresentationFrameworkCollection<ResourceDictionary> collection, ResourceDictionary resourceDictionary)
        {
            if (!collection.Any(rd => rd.Source.OriginalString.Equals(resourceDictionary.Source.OriginalString)))
            {
                collection.Add(resourceDictionary);
            }
        }
    }
}
