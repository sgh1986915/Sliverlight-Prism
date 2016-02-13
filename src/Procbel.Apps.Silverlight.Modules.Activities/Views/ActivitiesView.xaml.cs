using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Activities.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Activities.Views
{
    [ViewExport(RegionName="ContentRegion")]
    public partial class ActivitiesView : UserControl
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public ActivitiesViewModel ViewModel
        {
            get
            {
                return this.DataContext as ActivitiesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public ActivitiesView()
        {
            InitializeComponent();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionManager.Regions[RegionNames.SubMenuRegion].ClearActiveViews();
        }
    }
}
