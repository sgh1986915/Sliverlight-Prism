using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Companies.Helpers;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class CompanyOverviewViewModel : NavigationAwareDataViewModel
    {
        private Company selectedCompany;
        private bool isSelectedCompanyActivitiesLoading;
        private bool isSelectedCompanyOpportunitiesLoading;
        private bool isSelectedCompanyActivitiesLoaded;
        private bool isSelectedCompanyOpportunitiesLoaded;
        private IEnumerable<Activity> selectedCompanyActivities;
        private IEnumerable<Opportunity> selectedCompanyOpportunities;

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public CompaniesViewModel CompaniesViewModel { get; set; }

        [Import]
        public CompanyRepository CompanyRepository { get; set; }

        [Import]
        public ContactRepository ContactRepository { get; set; }

        [Import]
        public OpportunityRepository OpportunityRepository { get; set; }

        [Import]
        public ActivityRepository ActivityRepository { get; set; }

        public IEnumerable<Activity> SelectedCompanyActivities
        {
            get
            {
                if (!this.isSelectedCompanyActivitiesLoading && this.DataHasPendingUpdates && !this.isSelectedCompanyActivitiesLoaded)
                {
                    this.isSelectedCompanyActivitiesLoaded = false;
                    this.isSelectedCompanyActivitiesLoading = true;
                    this.ActivityRepository.GetOpenActivitiesByCompany(this.selectedCompany,
                        items =>
                        {
                            this.isSelectedCompanyActivitiesLoading = false;
                            this.isSelectedCompanyActivitiesLoaded = true;
                            if (this.isSelectedCompanyOpportunitiesLoaded)
                            {
                                this.DataHasPendingUpdates = false;
                                this.isSelectedCompanyActivitiesLoaded = false;
                            }
                            this.selectedCompanyActivities = items;
                            this.RaisePropertyChanged("SelectedCompanyActivities");
                            this.RaisePropertyChanged("OverdueActivitiesCount");
                        });
                }
                return this.selectedCompanyActivities;
            }
        }

        public IEnumerable<Opportunity> SelectedCompanyOpportunities
        {
            get
            {
                if (!this.isSelectedCompanyOpportunitiesLoading && this.DataHasPendingUpdates && !this.isSelectedCompanyOpportunitiesLoaded)
                {
                    this.isSelectedCompanyOpportunitiesLoaded = false;
                    this.isSelectedCompanyOpportunitiesLoading = true;
                    this.OpportunityRepository.GetOpenOpportunitiesByCompany(this.selectedCompany,
                        items =>
                        {
                            this.isSelectedCompanyOpportunitiesLoading = false;
                            this.isSelectedCompanyOpportunitiesLoaded = true;
                            if (this.isSelectedCompanyActivitiesLoaded)
                            {
                                this.DataHasPendingUpdates = false;
                                this.isSelectedCompanyOpportunitiesLoaded = false;
                            }
                            this.selectedCompanyOpportunities = items;
                            this.RaisePropertyChanged("SelectedCompanyOpportunities");
                            this.RaisePropertyChanged("OverdueOpportunitiesCount");
                        });
                }
                return this.selectedCompanyOpportunities;
            }
        }

        public int OverdueOpportunitiesCount
        {
            get
            {
                return (this.SelectedCompanyOpportunities != null) ? this.SelectedCompanyOpportunities.Count(o => o.Status == 0 && o.EstimationCloseDate.HasValue && o.EstimationCloseDate.Value < DateTime.Now) : 0;
            }
        }

        public int OverdueActivitiesCount
        {
            get
            {
                return (this.SelectedCompanyActivities != null) ? this.SelectedCompanyActivities.Count(a => a.DueDate.HasValue && a.DueDate.Value < DateTime.Now) : 0;
            }
        }

        public override void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<SelectedCompanyChangedEvent>().Subscribe(this.OnSelectedCompanyChanged);
        }

        public void OnSelectedCompanyChanged(Company company)
        {
            this.selectedCompany = company;
            if (this.selectedCompany != null && this.selectedCompany.CompanyID == 0)
            {
                this.DataHasPendingUpdates = true;
            }
        }

        protected override void OnDataUpdateTriggered()
        {
            this.RaisePropertyChanged("SelectedCompanySalesTrends");
            this.RaisePropertyChanged("SelectedCompanyActivities");
            this.RaisePropertyChanged("SelectedCompanyOpportunities");
            //this.RaisePropertyChanged("SelectedCompanyContacts");
        }
    }
}
