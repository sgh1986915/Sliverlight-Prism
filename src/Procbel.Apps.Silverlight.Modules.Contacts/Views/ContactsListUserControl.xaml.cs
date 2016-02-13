using Procbel.Apps.Model.CRM;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Contacts.Views
{
    [ViewExport(RegionName = "ContactListRegion")]
    public partial class ContactsListUserControl : UserControl
    {
        //CRMDomainContext _context;
        public ContactsListUserControl()
        {
            InitializeComponent();
            //_context = new CRMDomainContext();

            //this.Loaded += (s, e) =>
            //    {
            //        LoadOperation<Contact> lo = _context.Load(_context.GetContactQuery());
            //        lo.Completed += (o, c) =>
            //            {
            //                gridView.ItemsSource = lo.Entities;
            //            };
            //    };

            this.gridView.SelectionChanged += OnGridViewSelectionChanged;
        }

        void OnGridViewSelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            var grid = sender as RadGridView;
            if (grid.SelectedItem != null)
            {
                grid.ScrollIntoView(grid.SelectedItem);
            }
        }
    }
}
