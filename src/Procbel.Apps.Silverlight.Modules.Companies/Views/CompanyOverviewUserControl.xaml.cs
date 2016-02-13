using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Companies.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    [ViewExport(RegionName = "CompanyMiscDetailsRegion", IsActiveByDefault = false)]
    public partial class CompanyOverviewUserControl : UserControl
    {
        public CompanyOverviewUserControl()
        {
            InitializeComponent();
        }

        [Import]
        public IApplicationViewModel ApplicationViewModel;

        [Import]
        public CompanyOverviewViewModel ViewModel
        {
            get
            {
                return this.DataContext as CompanyOverviewViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void OnContactsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var contact = (sender as Button).DataContext;
            this.ViewModel.EventAggregator.GetEvent<ContactClickedEvent>().Publish(contact);
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.ContactsModule);
        }

        private void OnOpportunitiesButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var opportunity = (sender as Button).DataContext;
            this.ViewModel.EventAggregator.GetEvent<OpportunityClickedEvent>().Publish(opportunity);
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.OpportunitiesModule);
        }

        private void OnActivitiesButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var activity = (sender as Button).DataContext;
            this.ViewModel.EventAggregator.GetEvent<ActivityClickedEvent>().Publish(activity);
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.ActivitiesModule);
        }
    }
}
