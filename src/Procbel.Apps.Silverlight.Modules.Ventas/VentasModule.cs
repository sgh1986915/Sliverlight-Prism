﻿using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Procbel.Apps.Silverlight.Infrastructure;
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


namespace Procbel.Apps.Silverlight.Modules.Ventas
{
    [ModuleExport(ModuleNames.VentasModule, typeof(VentasModule), InitializationMode = InitializationMode.OnDemand)]
    public class VentasModule : IModule
    {
        public void Initialize()
        {

        }
    }
}