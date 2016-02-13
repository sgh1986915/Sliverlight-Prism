using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
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
    [ViewExport(RegionName = "SubMenuRegion", IsActiveByDefault = false)]
    public partial class ContactsSubMenuView : UserControl
    {
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

        public ContactsSubMenuView()
        {
            InitializeComponent();
        }
    }
}
