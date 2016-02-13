using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Silverlight.Infrastructure;
using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Calidad.ViewModels
{
    [Export]
    public class CalidadViewModel : NotificationObject, IPartImportsSatisfiedNotification, INavigationAware
    {
        public CalidadViewModel()
        {
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        #region ICommands

        public ICommand SwitchToVisualStateCommand
        {
            get { return new DelegateCommand<string>(OnSwitchToVisualState); }
        }

        #endregion

        #region Methods

        private void OnSwitchToVisualState(string stateName)
        {
            //this.State = ParseOpportunitiesViewState(stateName);
            //var region = this.RegionManager.Regions[OpportunityViewRegionNames.OpportunityMiscDetails];

            //switch (this.State)
            //{
            //    case OpportunitiesViewState.Activities:
            //        region.RequestNavigate("OpportunityActivitiesUserControl");
            //        break;
            //    default:
            //        region.ClearActiveViews();
            //        break;
            //}
        }

        #endregion

        #region INavigationAware

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionManager.RequestNavigate(RegionNames.SubMenuRegion, "CalidadSubMenuView");
        }

        public void OnImportsSatisfied()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
