using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Contacts.Infrastructure;
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
    [ViewExport(RegionName = ContactsViewRegionNames.ContactMiscDetails, IsActiveByDefault = false)]
    public partial class ContactActivitiesUserControl : UserControl
    {
        public ContactActivitiesUserControl()
        {
            InitializeComponent();

            this.scheduleView.AppointmentCreated += scheduleView_AppointmentCreated;
            this.scheduleView.AppointmentEdited += scheduleView_AppointmentEdited;
        }

        [Import]
        public ContactActivitiesViewModel ViewModel
        {
            get
            {
                return this.DataContext as ContactActivitiesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void scheduleView_AppointmentCreated(object sender, Telerik.Windows.Controls.AppointmentCreatedEventArgs e)
        {
            this.ViewModel.UpdateDataCommand.Execute(null);
        }

        private void scheduleView_AppointmentEdited(object sender, Telerik.Windows.Controls.AppointmentEditedEventArgs e)
        {
            this.ViewModel.UpdateDataCommand.Execute(null);
        }
    }
}
