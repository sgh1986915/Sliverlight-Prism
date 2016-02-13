using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Companies.Helpers;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class CompanyContactsViewModel : NotificationObject, IPartImportsSatisfiedNotification, INavigationAware
    {
        private Company selectedCompany;
        private ContactsMetadata metadata;

        public CompanyContactsViewModel()
        {
            this.GoToContactCommand = new DelegateCommand(this.OnGoToContactCommandExecuted);
        }

        public ICommand GoToContactCommand { get; set; }

        public bool ShouldSubmitChanges { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public CompaniesViewModel CompaniesViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        private void OnGoToContactCommandExecuted(object parameter)
        {
            var contact = parameter as Contact;
            this.EventAggregator.GetEvent<ContactClickedEvent>().Publish(contact);
            this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.ContactsModule);
        }

        public Company SelectedCompany
        {
            get
            {
                return this.selectedCompany;
            }
            set
            {
                if (this.selectedCompany != value)
                {
                    this.selectedCompany = value;
                    this.RaisePropertyChanged("SelectedCompany");
                }
            }
        }

        public ContactsMetadata Metadata
        {
            get
            {
                return this.metadata;
            }
            set
            {
                this.metadata = value;
                this.RaisePropertyChanged("Metadata");
            }
        }

        [Import]
        public ContactRepository ContactRepository { get; set; }

        public void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<SelectedCompanyChangedEvent>().Subscribe(OnSelectedCompanyChanged);
        }

        public void OnSelectedCompanyChanged(Company company)
        {
            if (company == null || company.CompanyID == 0)
            {
                return;
            }
            this.SelectedCompany = company;

            this.ContactRepository.GetContactsMetadata(company, cm =>
            {
                this.Metadata = cm;
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.CompaniesViewModel.UpdateContacts();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
