using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Contacts.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Silverlight.Modules.Contacts.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Contacts.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class ContactsView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public ContactsViewModel ViewModel
        {
            get
            {
                return this.DataContext as ContactsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public ContactsView()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            RoutedEventHandler loadedHandler = null;
            loadedHandler = (s, e) =>
            {
                this.Loaded -= loadedHandler;
                this.ViewModel.State = ContactsViewState.List;
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
            this.RegionManager.Regions[RegionNames.SubMenuRegion].ClearActiveViews();
            this.RegionManager.RequestNavigate(RegionNames.SubMenuRegion, "ContactsSubMenuView");
        }
    }
}
