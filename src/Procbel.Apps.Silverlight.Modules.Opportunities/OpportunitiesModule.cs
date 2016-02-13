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
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Procbel.Apps.Silverlight.Infrastructure;

namespace Procbel.Apps.Silverlight.Modules.Opportunities
{
    [ModuleExport(ModuleNames.OpportunitiesModule, typeof(OpportunitiesModule), InitializationMode = InitializationMode.OnDemand)]
    public class OpportunitiesModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
