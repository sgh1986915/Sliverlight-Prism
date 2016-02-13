using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Modules.Companies.Helpers;
using Procbel.Apps.Silverlight.Modules.Companies.Infrastructure;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.ComponentModel.Composition;
using System.Net;
using Telerik.Windows.Data;
using System.Windows.Input;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class CompaniesViewModel : NotificationObject
    {
        private  Company selectedCompany;
        private QueryableCollectionView selectedCompanyContacts;

        public CompaniesViewModel()
        {
            this.SwitchToVisualStateCommand = new DelegateCommand<string>(OnSwitchToVisualState);
        }

        public bool IsInOverviewState
        {
            get
            {
                return this.State == CompaniesViewState.Overview;
            }
        }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public CompanyRepository CompanyRepository { get; set; }

        [Import]
        public ContactRepository ContactRepository { get; set; }

        public Company SelectedCompany
        {
            get
            {
                return this.selectedCompany;
            }
            set
            {
                if (this.selectedCompany == value)
                {
                    return;
                }
                this.selectedCompany = value;
                this.selectedCompanyContacts = null;
                this.RaisePropertyChanged("SelectedCompany");
                this.RaisePropertyChanged("SelectedCompanyContacts");

                RaiseSelectedCompanyChangedEvent();
            }
        }

        public QueryableCollectionView SelectedCompanyContacts
        {
            get
            {
                if (this.selectedCompanyContacts == null)
                {
                    this.ContactRepository.GetContactsByCompany(this.SelectedCompany, items =>
                    {
                        this.selectedCompanyContacts = new QueryableCollectionView(items);
                        this.RaisePropertyChanged("SelectedCompanyContacts");
                    });
                }
                return this.selectedCompanyContacts;
            }
        }

        private void RaiseSelectedCompanyChangedEvent()
        {
            this.EventAggregator.GetEvent<SelectedCompanyChangedEvent>().Publish(this.SelectedCompany);
        }

        private QueryableCollectionView companies = null;
        public QueryableCollectionView Companies
        {
            get
            {
                if (this.companies == null)
                {
                    this.CompanyRepository.GetCompanies(items =>
                    {
                        var companies = new ObservableItemCollection<Company>();
                        companies.AddRange(items);
                        this.companies = new QueryableCollectionView(companies);
                        this.EventAggregator.GetEvent<CompaniesLoadedEvent>().Publish(this.companies);
                        this.RaisePropertyChanged("Companies");
                    });
                }

                return this.companies;
            }
        }

        public void SwitchRegion(string regionName, string path)
        {
            this.RegionManager.RequestNavigate(regionName, path);
        }

        public void UpdateContacts()
        {
            this.selectedCompanyContacts = null;
            this.RaisePropertyChanged("SelectedCompanyContacts");
        }

        #region VisualState methods and properties

        private CompaniesViewState state;
        public CompaniesViewState State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (this.state == value)
                {
                    return;
                }
                this.state = value;
                this.RaisePropertyChanged("State");
                this.RaisePropertyChanged("IsInOverviewState");
            }
        }

        public ICommand SwitchToVisualStateCommand { get; set; }

        private void OnSwitchToVisualState(string stateName)
        {
            this.State = ParseCompaniesViewState(stateName);
            var region = this.RegionManager.Regions[CompanyViewRegionNames.CompanyMiscDetails];

            switch (this.State)
            {
                case CompaniesViewState.Overview:
                    region.RequestNavigate("CompanyOverviewUserControl");
                    break;
                case CompaniesViewState.Opportunities:
                    region.RequestNavigate("CompanyOpportunitiesUserControl");
                    break;
                case CompaniesViewState.Contacts:
                    region.RequestNavigate("CompanyContactsUserControl");
                    break;
                case CompaniesViewState.Activities:
                    region.RequestNavigate("CompanyActivitiesUserControl");
                    break;
                default:
                    ClearRegionActiveViews(region);
                    break;
            }
        }

        private static void ClearRegionActiveViews(IRegion region)
        {
            foreach (var v in region.ActiveViews)
            {
                region.Deactivate(v);
            }
        }

        private CompaniesViewState ParseCompaniesViewState(string stateName)
        {
            var parsedState = Enum.Parse(typeof(CompaniesViewState), stateName, true);
            var resultState = (CompaniesViewState)parsedState;
            return resultState;
        }
        #endregion

        #region Commands
        public ICommand ViewLoadedCommand { get; set; }
        #endregion
    }
}
