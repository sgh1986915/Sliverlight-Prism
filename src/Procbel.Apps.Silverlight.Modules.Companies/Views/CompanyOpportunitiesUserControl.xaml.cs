using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Companies.Infrastructure;
using Procbel.Apps.Silverlight.Modules.Companies.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    [ViewExport(RegionName = CompanyViewRegionNames.CompanyMiscDetails, IsActiveByDefault = false)]
    public partial class CompanyOpportunitiesUserControl : UserControl
    {
        public CompanyOpportunitiesUserControl()
        {
            InitializeComponent();

            dataForm.BeginningEdit += this.OnDataFormAddingOrEditing;
            dataForm.AddedNewItem += new EventHandler<Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs>(dataForm_AddedNewItem);
        }

        void dataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {
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

                var modelContainsEntity = (this.DataContext as CompanyOpportunitiesViewModel).OpportunitiesRepository.Context.Opportunities.Contains(opportunity);
                if (!modelContainsEntity)
                {
                    (this.DataContext as CompanyOpportunitiesViewModel).OpportunitiesRepository.Context.Opportunities.Add(opportunity);
                }

                (this.DataContext as CompanyOpportunitiesViewModel).OpportunitiesRepository.SaveOrUpdateEntities(
                    () =>
                    {
                        (this.dataForm.CurrentItem as Opportunity).RaiseProductChangedEvent();
                    });
            }

            if (e.EditAction == Telerik.Windows.Controls.Data.DataForm.EditAction.Cancel)
            {
                (sender as RadDataForm).CancelEdit();
                (sender as RadDataForm).ValidationSummary.Errors.Clear();
                (this.DataContext as CompanyOpportunitiesViewModel).OpportunitiesRepository.Context.RejectChanges();
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
        public CompanyOpportunitiesViewModel ViewModel
        {
            get
            {
                return this.DataContext as CompanyOpportunitiesViewModel;
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
