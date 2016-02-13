using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Companies.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    [ViewExport(RegionName = "SubMenuRegion", IsActiveByDefault = false)]
    public partial class SubMenuView : UserControl
    {
        [Import]
        public CompaniesViewModel ViewModel
        {
            get
            {
                return this.DataContext as CompaniesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public SubMenuView()
        {
            InitializeComponent();
        }
    }
}
