using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Inicio.Helpers
{
    public static class DiagramFactory
    {

        public static void LoadDiagram(RadDiagram diagram, string name)
        {


            diagram.Clear();

            using (var stream = ExtensionUtilities.GetStream(string.Format("{0}.xml", name), "Procbel.Apps.Silverlight.Modules.Inicio"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var xml = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(xml))
                    {
                        diagram.Load(xml);
                    }
                }
            }
#if WPF
            diagram.Dispatcher.BeginInvoke(new Action(() => diagram.AutoFit()), System.Windows.Threading.DispatcherPriority.Loaded);
#else
            diagram.Dispatcher.BeginInvoke(new Action(() => diagram.AutoFit()));
#endif
        }

    }
}
