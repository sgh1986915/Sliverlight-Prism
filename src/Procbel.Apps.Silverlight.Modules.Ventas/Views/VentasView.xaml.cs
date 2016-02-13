using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Ventas.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Ventas.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class VentasView : UserControl, INavigationAware
    {
        public VentasView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public VentasViewModel ViewModel
        {
            private get
            {
                return this.DataContext as VentasViewModel;
            }
            set
            {
                this.DataContext = value;
                //SetMenuControl();
            }
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
            this.activitiesDataSource.Load();
            this.contactsDataSource.Load();
            this.opportunitiesDataSource.Load();
            this.ViewModel.LoadStats();
            SetMenuControl();
        }

        private void OnOpportunitiesButtonClicked(object sender, RoutedEventArgs e)
        {
            var opportunity = (sender as Button).DataContext;
            this.EventAggregator.GetEvent<OpportunityClickedEvent>().Publish(opportunity);
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.OpportunitiesModule);
        }

        private void OnActivitiesButtonClicked(object sender, RoutedEventArgs e)
        {
            var activity = (sender as Button).DataContext;
            this.EventAggregator.GetEvent<ActivityClickedEvent>().Publish(activity);
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.ActivitiesModule);
        }

        private void SetMenuControl()
        {
            ApplicationViewModel.ModuleMenuControl = new VentasMenuView(ApplicationViewModel, RegionManager, EventAggregator);
        }
    }
}
