using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
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
using Telerik.Windows.Controls;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;

namespace Procbel.Apps.Silverlight.Modules.Ventas.Views
{
    [ViewExport(RegionName = "SubMenuRegion", IsActiveByDefault = false)]
    public partial class VentasMenuView : UserControl
    {
        public IApplicationViewModel ApplicationViewModel { get; set; }

        public IRegionManager RegionManager { get; set; }

        public IEventAggregator EventAggregator { get; set; }

        [ImportingConstructor]
        public VentasMenuView(IApplicationViewModel applicationViewModel, IRegionManager regionManager, IEventAggregator eventAgregator)
        {
            ApplicationViewModel = applicationViewModel;
            RegionManager = regionManager;
            EventAggregator = eventAgregator;
            InitializeComponent();
            SubscribeToMouseEvents();
        }

        private void SubscribeToMouseEvents()
        {
            foreach (UIElement element in LayoutRoot.Children)
            {
                if (element is StackPanel)
                {
                    StackPanel panel = element as StackPanel;
                    foreach (UIElement el in panel.Children)
                    {
                        RadRadioButton menu = el as RadRadioButton;
                        menu.MouseEnter += element_MouseEnter;
                        menu.Click += menu_Click;

                    }
                }
                else if (element is Canvas)
                {
                    foreach (UIElement panel in (element as Canvas).Children)
                    {
                        foreach (UIElement el in (panel as StackPanel).Children)
                        {
                            RadRadioButton menu = el as RadRadioButton;
                            menu.Click += menu_Click;
                        }
                    }
                }
            }
        }

        void menu_Click(object sender, RoutedEventArgs e)
        {
            RadRadioButton item = sender as RadRadioButton;
            this.RegionManager.Regions[RegionNames.ContentRegion].ClearActiveViews();
            this.RegionManager.RequestNavigate(RegionNames.ContentRegion, item.Name);
        }

        void element_MouseEnter(object sender, MouseEventArgs e)
        {
            RadRadioButton obj = sender as RadRadioButton;
            if (obj.Name != null)
            {
                var subMenuID = "SUB" + (string)obj.Name;
                var subMenu = LayoutRoot.FindName(subMenuID) as UIElement;
                foreach (var item in LayoutRoot.Children)
                {
                    if (item is Canvas)
                    {
                        item.Visibility = Visibility.Collapsed;
                    }
                }
                if (subMenu != null)
                {
                    subMenu.Visibility = Visibility.Visible;
                }

            }
        }

    }
}
