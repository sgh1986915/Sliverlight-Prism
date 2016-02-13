using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Contacts.ViewModels;
using System;
using System.Collections.Generic;
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

namespace Procbel.Apps.Silverlight.Modules.Contacts.Views
{
    [ViewExport(RegionName = "ContactDetailsRegion")]
    public partial class ContactsDetailsUserControl : UserControl
    {
        public ContactsDetailsUserControl()
        {
            InitializeComponent();
        }

        private void RadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            var viewModel = this.DataContext as ContactsViewModel;
            switch (e.EditAction)
            {
                case Telerik.Windows.Controls.Data.DataForm.EditAction.Cancel:
                    viewModel.ContactRepository.Context.RejectChanges();
                    break;
                case Telerik.Windows.Controls.Data.DataForm.EditAction.Commit:
                    var contact = (sender as RadDataForm).CurrentItem as Contact;
                    var modelContainsEntity = viewModel.ContactRepository.Context.Contacts.Contains(contact);
                    if (!modelContainsEntity)
                    {
                        viewModel.ContactRepository.Context.Companies.Add(contact);
                    }
                    viewModel.ContactRepository.SaveOrUpdateEntities();
                    break;
                default:
                    throw new InvalidOperationException("Edit action should be Cancel or Commit only.");

            }
        }

        private void OnDataFormCurrentItemChanged(object sender, EventArgs e)
        {
            (sender as RadDataForm).CancelEdit();
        }
    }
}
