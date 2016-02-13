using Procbel.Apps.Model.CRM;
using Procbel.Apps.Model.CRM.Dashboard;
using Procbel.Apps.Silverlight.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Procbel.Apps.Silverlight.Infrastructure;

namespace Procbel.Apps.Silverlight.Modules.Ventas.ViewModels
{
    [Export]
    public class VentasViewModel : Procbel.Apps.Silverlight.Infrastructure.ViewModels.NavigationAwareDataViewModel
    {
        #region Repositories
        [Import]
        public DashboardRepository DashboardRepository { get; set; }
        #endregion

        [Import]
        public IRegionManager RegionManager { get; set; }

        #region View-visible properties
        public DomainContext Context { get; set; }

        private bool isStatsLoading;
        public bool IsStatsLoading
        {
            get
            {
                return isStatsLoading;
            }
            set
            {
                isStatsLoading = value;
                this.RaisePropertyChanged("IsStatsLoading");
            }
        }

        private DashboardStats stats;
        public DashboardStats Stats
        {
            get
            {
                if (stats == null && !this.IsStatsLoading)
                {
                    this.IsStatsLoading = true;
                    this.DashboardRepository.GetDashboardStats((result) =>
                    {
                        this.stats = result;
                        this.IsStatsLoading = false;
                        this.RaisePropertyChanged(() => this.Stats);
                    });
                }
                return this.stats;
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Today;
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Contact> recentContacts;

        public IEnumerable<Contact> RecentContacts
        {
            get
            {
                return this.recentContacts;
            }
            set
            {
                if (this.recentContacts == value)
                {
                    return;
                }
                this.recentContacts = value;
                this.RaisePropertyChanged(() => this.RecentContacts);
                this.RaisePropertyChanged(() => this.RecentContactsCount);
            }
        }


        //set from the view's domaindatasource
        private IEnumerable<Activity> activities;

        public IEnumerable<Activity> Activities
        {
            get
            {
                return activities;
            }
            set
            {
                if (this.activities == value)
                {
                    return;
                }
                this.activities = value;
                this.RaisePropertyChanged(() => this.Activities);
                this.RaisePropertyChanged(() => this.ActivitiesCount);
                this.RaisePropertyChanged(() => this.Stats);
            }
        }

        //set from the view's domaindatasource
        private IEnumerable<Opportunity> opportunities;

        public IEnumerable<Opportunity> Opportunities
        {
            get
            {
                return this.opportunities;
            }
            set
            {
                if (this.opportunities == value)
                {
                    return;
                }
                this.opportunities = value;
                this.RaisePropertyChanged(() => this.Opportunities);
                this.RaisePropertyChanged(() => this.OpenOpportunitiesCount);
                this.RaisePropertyChanged(() => this.OverdueOpportunitiesCount);
                this.RaisePropertyChanged(() => this.Stats);
            }
        }


        public int RecentContactsCount
        {
            get
            {
                if (this.RecentContacts == null)
                {
                    return 0;
                }
                return this.RecentContacts.Count();
            }
        }

        public int ActivitiesCount
        {
            get
            {
                if (this.activities == null)
                {
                    return 0;
                }
                return this.Activities.Count();
            }
        }

        public int OpenOpportunitiesCount
        {
            get
            {
                if (this.Opportunities == null)
                {
                    return 0;
                }
                var openOpportunitiesCount = this.Opportunities.Count(o => o.StatusType == OpportunityStatusType.Open);
                return openOpportunitiesCount;
            }
        }

        public int OverdueOpportunitiesCount
        {
            get
            {
                if (this.Opportunities == null)
                {
                    return 0;
                }
                var overdueOpportunitiesCount = this.Opportunities.Count(o => o.EstimationCloseDate <= DateTime.Now);
                return overdueOpportunitiesCount;
            }
        }

        public void LoadStats()
        {
            this.stats = null;
            this.RaisePropertyChanged("Stats");
        }

        #endregion

        #region NavigationAwareDataViewModel overrides

        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            this.Context = this.DashboardRepository.Context;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //this.RegionManager.RequestNavigate(RegionNames.SubMenuRegion, "VentasMenuView");
        }
        
        #endregion
    }
}
