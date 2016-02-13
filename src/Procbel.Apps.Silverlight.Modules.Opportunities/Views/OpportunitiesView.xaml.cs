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
using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Opportunities.ViewModels;

namespace Procbel.Apps.Silverlight.Modules.Opportunities.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class OpportunitiesView : UserControl,IPartImportsSatisfiedNotification  , INavigationAware
    {
        public OpportunitiesView()
        {
            InitializeComponent();
        }
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public OpportunitiesViewModel ViewModel
        {
            get
            {
                return this.DataContext as OpportunitiesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        public void OnImportsSatisfied()
        {
            //RoutedEventHandler loadedHandler = null;
            //loadedHandler = (s, e) =>
            //{
            //    this.Loaded -= loadedHandler;
            //    this.ViewModel.SwitchToVisualStateCommand.Execute(CompaniesViewState.Overview.ToString());
            //};

            //this.Loaded += loadedHandler;
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
            //this.RegionManager.RequestNavigate(RegionNames.SubMenuRegion, "SubMenuView");
        }
    }
}
