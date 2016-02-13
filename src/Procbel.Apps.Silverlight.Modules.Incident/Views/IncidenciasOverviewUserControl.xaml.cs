using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Views
{
    [ViewExport(RegionName = "IncidenciasMiscDetailsRegion", IsActiveByDefault = false)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class IncidenciasOverviewUserControl : UserControl
    {
        public IncidenciasOverviewUserControl()
        {
            InitializeComponent();
        }
    }
}
