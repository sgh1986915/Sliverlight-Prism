using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Companies.Infrastructure;
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
    [ViewExport(RegionName = "ContentRegion")]
    public partial class CompaniesView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

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

        public CompaniesView()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            RoutedEventHandler loadedHandler = null;
            loadedHandler = (s, e) =>
            {
                this.Loaded -= loadedHandler;
                this.ViewModel.SwitchToVisualStateCommand.Execute(CompaniesViewState.Overview.ToString());
            };

            this.Loaded += loadedHandler;
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
            this.RegionManager.RequestNavigate(RegionNames.SubMenuRegion, "SubMenuView");
        }
    }
}
