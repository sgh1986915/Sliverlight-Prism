using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
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
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Silverlight.Modules.Inicio.ViewModels;
using Procbel.Apps.Silverlight.Modules.Inicio.Helpers;

namespace Procbel.Apps.Silverlight.Modules.Inicio.Views
{
      [ViewExport(RegionName = "ContentRegion")]
    public partial class InicioView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        public InicioView()
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
        public InicioViewModel ViewModel
        {
            private get
            {
                return this.DataContext as InicioViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        //implementacion de INavigationAware
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        //implementacion de INavigationAware
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        //implementacion de INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionManager.Regions[RegionNames.SubMenuRegion].ClearActiveViews();

            DiagramFactory.LoadDiagram(this.diagram, "ModulesDiagram");
            this.diagram.AutoFit();
            SetMenuControl();
        
        }

        private void SetMenuControl()
        {
            ApplicationViewModel.ModuleMenuControl = null; // new VentasMenuView(ApplicationViewModel, RegionManager, EventAggregator);
        }
        public void OnImportsSatisfied()
        {
 
        }
    }
}
