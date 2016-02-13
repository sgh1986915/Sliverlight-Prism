using Microsoft.Practices.Prism.Modularity;
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
using Procbel.Apps.Silverlight.Infrastructure;

namespace Procbel.Apps.Silverlight.Modules.Inicio
{
    [ModuleExport(ModuleNames.InicioModule, typeof(InicioModule), InitializationMode = InitializationMode.OnDemand)]
    public class InicioModule : IModule
    {
        public void Initialize()
        {

        }
    }
}
