using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure;
using Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels;
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
    [ViewExport(RegionName = "ContentRegion")]
    public partial class IncidenciasView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        public IncidenciasView()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
                {
                    var vm = this.DataContext as IncidenciasViewModel;
                    if (vm != null)
                        vm.IsBusy = true;
                };
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IncidenciasViewModel ViewModel
        {
            get
            {
                return this.DataContext as IncidenciasViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        #region Prism Framework

        public void OnImportsSatisfied()
        {
            RoutedEventHandler loadedHandler = null;
            loadedHandler = (s, e) =>
            {
                this.Loaded -= loadedHandler;
                this.ViewModel.State = IncidenciasViewState.List;
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

        }

        #endregion
    }
}
