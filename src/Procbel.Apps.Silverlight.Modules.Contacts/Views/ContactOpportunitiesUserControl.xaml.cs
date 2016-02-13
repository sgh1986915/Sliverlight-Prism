using Procbel.Apps.Model.Main;
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
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Contacts.Views
{
    [ViewExport(RegionName = ContactsViewRegionNames.ContactMiscDetails, IsActiveByDefault = false)]
    public partial class ContactOpportunitiesUserControl : UserControl
    {
        public ContactOpportunitiesUserControl()
        {
            InitializeComponent();

            dataForm.BeginningEdit += this.OnDataFormAddingOrEditing;
            dataForm.AddedNewItem += new EventHandler<Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs>(dataForm_AddedNewItem);
        }

        void dataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {
            var opportunity = e.NewItem as Opportunity;
            opportunity.ContactID = this.ViewModel.SelectedContact.ContactID;
            opportunity.Contact = this.ViewModel.SelectedContact;

            (sender as RadDataForm).Visibility = System.Windows.Visibility.Visible;
        }

        void OnDataFormAddingOrEditing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (sender as RadDataForm).Visibility = System.Windows.Visibility.Visible;
        }

        private void RadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            if (e.EditAction == Telerik.Windows.Controls.Data.DataForm.EditAction.Commit)
            {
                Opportunity opportunity = (this.dataForm.CurrentItem as Opportunity);

                var modelContainsEntity = (this.DataContext as ContactOpportunitiesViewModel).OpportunitiesRepository.Context.Opportunities.Contains(opportunity);
                if (!modelContainsEntity)
                {
                    (this.DataContext as ContactOpportunitiesViewModel).OpportunitiesRepository.Context.Opportunities.Add(opportunity);
                }

                (this.DataContext as ContactOpportunitiesViewModel).OpportunitiesRepository.SaveOrUpdateEntities(
                    () =>
                    {
                        (this.dataForm.CurrentItem as Opportunity).RaiseProductChangedEvent();
                    });
            }

            if (e.EditAction == Telerik.Windows.Controls.Data.DataForm.EditAction.Cancel)
            {
                (sender as RadDataForm).CancelEdit();
                (sender as RadDataForm).ValidationSummary.Errors.Clear();
                (this.DataContext as ContactOpportunitiesViewModel).OpportunitiesRepository.Context.RejectChanges();
            }

            (sender as RadDataForm).Visibility = System.Windows.Visibility.Collapsed;
        }

        private void OnDataFormCurrentItemChanged(object sender, EventArgs e)
        {
            (sender as RadDataForm).CancelEdit();
            (sender as RadDataForm).ValidationSummary.Errors.Clear();
            (sender as RadDataForm).Visibility = System.Windows.Visibility.Collapsed;
        }

        [Import]
        public ContactOpportunitiesViewModel ViewModel
        {
            get
            {
                return this.DataContext as ContactOpportunitiesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public void CancelEdit()
        {
            this.OnDataFormCurrentItemChanged(this.dataForm, EventArgs.Empty);
        }
    }
}
