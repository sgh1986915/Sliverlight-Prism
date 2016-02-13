using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Linq;

namespace Procbel.Apps.Silverlight.Infrastructure.Helpers
{
    public static class AssemblyCache
    {
        private static readonly List<string> loadedAssemblyNamesCache = new List<string>();

        internal static void Initialize()
        {
            // populate the assembly names cache with the assemblies inside this XAP
            foreach (AssemblyPart ap in Deployment.Current.Parts)
            {
                StreamResourceInfo sri = Application.GetResourceStream(new Uri(ap.Source, UriKind.Relative));
                Assembly a = new AssemblyPart().Load(sri.Stream);
                loadedAssemblyNamesCache.Add(a.FullName.Split(',').First());
            }

            // populate the assembly names cache with the assembly parts referred from thisXAP
            foreach (var ep in Deployment.Current.ExternalParts)
            {
                string assemblyName = ep.Source.OriginalString.Replace(".zip", "");
                loadedAssemblyNamesCache.Add(assemblyName);
            }
        }

        internal static bool HasLoadedAssembly(string assemblyName)
        {
            return loadedAssemblyNamesCache.Contains(assemblyName);
        }

        internal static void AddAssemblyName(string assemblyName)
        {
            loadedAssemblyNamesCache.Add(assemblyName);
        }
    }
}
