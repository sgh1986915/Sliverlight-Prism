using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    [ViewExport(RegionName = "CompaniesListRegion")]
    public partial class CompaniesListUserControl : UserControl
    {
        public CompaniesListUserControl()
        {
            InitializeComponent();
        }
    }
}
