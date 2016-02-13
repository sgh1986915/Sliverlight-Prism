using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Helpers;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Companies.Helpers;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Net;
using System.Linq;
using System.Windows.Input;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class CompanyActivitiesViewModel : NavigationAwareDataViewModel, IPartImportsSatisfiedNotification
    {
        private Company selectedCompany;
        private ObservableCollection<Activity> selectedCompanyActivities = new ObservableCollection<Activity>();
        private IEnumerable<Opportunity> selectedCompanyOpportunities;
        private bool isSelectedCompanyActivitiesLoaded;
        private bool isSelectedCompanyOpportunitiesLoaded;
        private bool isSelectedCompanyActivitiesLoading;
        private bool isSelectedCompanyOpportunitiesLoading;

        public CompanyActivitiesViewModel()
        {
            this.UpdateDataCommand = new DelegateCommand(this.OnUpdateDataCommandExecuted);
            this.RejectDataChangesCommand = new DelegateCommand(this.OnRejectDataChangesCommandExecuted);
        }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public ActivityRepository ActivityRepository { get; set; }

        [Import]
        public OpportunityRepository OpportunityRepository { get; set; }

        public ICommand UpdateDataCommand { get; set; }

        public ICommand RejectDataChangesCommand { get; set; }

        public ObservableCollection<CustomAppointmentMain> SelectedCompanyAppointments { get; set; }

        public ObservableCollection<Activity> SelectedCompanyActivities
        {
            get
            {
                if (this.DataHasPendingUpdates && !this.isSelectedCompanyActivitiesLoading)
                {
                    this.isSelectedCompanyActivitiesLoading = true;
                    this.ActivityRepository.GetActivitiesByCompany(this.selectedCompany,
                        items =>
                        {
                            this.IsSelectedCompanyActivitiesLoaded = true;
                            this.isSelectedCompanyActivitiesLoading = false;
                            this.SelectedCompanyAppointments.CollectionChanged -= OnSelectedCompanyAppointmentsCollectionChanged;

                            foreach (var item in items)
                            {
                                this.selectedCompanyActivities.Add(item);
                                this.SelectedCompanyAppointments.Add(new CustomAppointmentMain(item));
                            }

                            this.SelectedCompanyAppointments.CollectionChanged += OnSelectedCompanyAppointmentsCollectionChanged;

                            this.RaisePropertyChanged("SelectedCompanyActivities");
                            this.RaisePropertyChanged("SelectedCompanyAppointments");
                            this.RaisePropertyChanged("OverdueCount");
                            this.RaisePropertyChanged("ActivitiesCount");
                        });
                }

                return this.selectedCompanyActivities;
            }
        }

        public IEnumerable<Opportunity> SelectedCompanyOpportunities
        {
            get
            {
                if (this.DataHasPendingUpdates && !this.isSelectedCompanyOpportunitiesLoading)
                {
                    this.isSelectedCompanyOpportunitiesLoading = true;
                    this.OpportunityRepository.GetOpportunitiesByCompany(this.selectedCompany,
                        items =>
                        {
                            this.IsSelectedCompanyOpportunitiesLoaded = true;
                            this.isSelectedCompanyOpportunitiesLoading = false;
                            this.DataHasPendingUpdates = false;
                            this.selectedCompanyOpportunities = items;
                            this.RaisePropertyChanged("SelectedCompanyOpportunities");
                        });
                }
                return this.selectedCompanyOpportunities;
            }
        }

        public int OverdueCount
        {
            get
            {
                return (this.SelectedCompanyActivities != null) ? this.selectedCompanyActivities.Count(a => a.StatusType == ActivityStatusType.InProgress && a.DueDate.HasValue && a.IsOverdue) : 0;
            }
        }

        public int ActivitiesCount
        {
            get
            {
                return (this.SelectedCompanyActivities != null) ? this.selectedCompanyActivities.Count() : 0;
            }
        }

        private bool IsSelectedCompanyActivitiesLoaded
        {
            get
            {
                return this.isSelectedCompanyActivitiesLoaded;
            }
            set
            {
                this.isSelectedCompanyActivitiesLoaded = value;
                if (this.IsSelectedCompanyOpportunitiesLoaded && value)
                {
                    this.DataHasPendingUpdates = false;
                }
            }
        }

        private bool IsSelectedCompanyOpportunitiesLoaded
        {
            get
            {
                return this.isSelectedCompanyOpportunitiesLoaded;
            }
            set
            {
                this.isSelectedCompanyOpportunitiesLoaded = value;
                if (this.IsSelectedCompanyActivitiesLoaded && value)
                {
                    this.DataHasPendingUpdates = false;
                }
            }
        }

        public override void OnImportsSatisfied()
        {
            this.SelectedCompanyAppointments = new ObservableCollection<CustomAppointmentMain>();
            this.SelectedCompanyAppointments.CollectionChanged += this.OnSelectedCompanyAppointmentsCollectionChanged;
            this.SelectedCompanyActivities.CollectionChanged += this.OnSelectedCompanyActivitiesCollectionChanged;
            this.EventAggregator.GetEvent<SelectedCompanyChangedEvent>().Subscribe(this.OnSelectedCompanyChanged);
        }

        public void OnSelectedCompanyChanged(Company company)
        {
            this.selectedCompany = company;
            this.SelectedCompanyAppointments.Clear();
            this.SelectedCompanyActivities.Clear();
            this.DataHasPendingUpdates = true;
        }

        protected override void OnDataUpdateTriggered()
        {
            this.RaisePropertyChanged("SelectedCompanyActivities");
            this.RaisePropertyChanged("SelectedCompanyOpportunities");
        }

        private void OnSelectedCompanyAppointmentsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                this.SelectedCompanyActivities.Add((e.NewItems[0] as CustomAppointmentMain).Activity);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Activity activityToRemove = this.SelectedCompanyActivities.FirstOrDefault(a => a.ActivityID == (e.OldItems[0] as CustomAppointmentMain).Activity.ActivityID);
                var removeSucceeded = this.SelectedCompanyActivities.Remove(activityToRemove);
                System.Diagnostics.Debug.WriteLine("Remove on SelectedCompanyActivities: {0}", removeSucceeded);
            }
        }

        private void OnSelectedCompanyActivitiesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged("OverdueCount");
            this.RaisePropertyChanged("ActivitiesCount");
        }

        private void OnRejectDataChangesCommandExecuted()
        {
            this.ActivityRepository.Context.RejectChanges();
        }

        private void OnUpdateDataCommandExecuted()
        {
            foreach (var activity in this.SelectedCompanyActivities)
            {
                if (!this.ActivityRepository.Context.Activities.Contains(activity))
                {
                    this.ActivityRepository.Context.Activities.Add(activity);
                }
            }
            this.ActivityRepository.SaveOrUpdateEntities();
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            this.SelectedCompanyAppointments.CollectionChanged -= OnSelectedCompanyAppointmentsCollectionChanged;
            this.SelectedCompanyAppointments.Clear();
            this.SelectedCompanyAppointments.CollectionChanged += OnSelectedCompanyAppointmentsCollectionChanged;

            this.selectedCompanyActivities.Clear();
            this.selectedCompanyOpportunities = null;
            this.DataHasPendingUpdates = true;
            this.OnDataUpdateTriggered();
        }
    }
}
