using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Companies.Helpers;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Linq;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class CompanyOpportunitiesViewModel : NavigationAwareDataViewModel
    {
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public OpportunityRepository OpportunitiesRepository { get; set; }

        public override void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<SelectedCompanyChangedEvent>().Subscribe(this.OnSelectedCompanyChanged);
        }

        public void OnSelectedCompanyChanged(Company company)
        {
            this.SelectedCompany = company;
            this.DataHasPendingUpdates = true;
        }

        private Company selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return selectedCompany;
            }
            set
            {
                if (selectedCompany == value)
                {
                    return;
                }
                selectedCompany = value;
                this.RaisePropertyChanged("SelectedCompany");
            }
        }


        private ObservableCollection<Opportunity> opportunitiesForCompany;
        public ObservableCollection<Opportunity> OpportunitiesForCompany
        {
            get
            {
                if (this.DataHasPendingUpdates)
                {
                    this.OpportunitiesRepository.GetOpportunitiesByCompanyID(this.SelectedCompany.CompanyID,
                         items =>
                         {
                             this.DataHasPendingUpdates = false;
                             this.opportunitiesForCompany = new ObservableCollection<Opportunity>(new List<Opportunity>(items));
                             this.RaisePropertyChanged("OpportunitiesForCompany");
                             this.RaisePropertyChanged("TotalAmount");
                             this.RaisePropertyChanged("OpenCount");
                             this.RaisePropertyChanged("OverdueCount");
                         });
                    return null;
                }

                return opportunitiesForCompany;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                var sum = (this.OpportunitiesForCompany != null) ? this.OpportunitiesForCompany.Sum(x => x.TotalPrice) : 0;
                return sum;
            }
        }

        public int OpenCount
        {
            get
            {
                var count = (this.OpportunitiesForCompany != null) ? this.OpportunitiesForCompany.Count(o => o.StatusType == OpportunityStatusType.Open) : 0;
                return count;
            }
        }

        public int OverdueCount
        {
            get
            {
                return (this.OpportunitiesForCompany != null) ? this.OpportunitiesForCompany.Count(o => o.StatusType == OpportunityStatusType.Open && o.EstimationCloseDate.HasValue && o.EstimationCloseDate.Value < DateTime.Now) : 0;
            }
        }

        protected override void OnDataUpdateTriggered()
        {
            this.RaisePropertyChanged("OpportunitiesForCompany");
        }
    }
}
