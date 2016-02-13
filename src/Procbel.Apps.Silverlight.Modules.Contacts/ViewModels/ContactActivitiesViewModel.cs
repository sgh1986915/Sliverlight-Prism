using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Contacts.Helpers;
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
using Procbel.Apps.Silverlight.Helpers;
using Microsoft.Practices.Prism.Commands;
using Telerik.Windows.Data;

namespace Procbel.Apps.Silverlight.Modules.Contacts.ViewModels
{
    [Export]
    public class ContactActivitiesViewModel : NavigationAwareDataViewModel, IPartImportsSatisfiedNotification
    {
        private Contact selectedContact;
        private ObservableCollection<Activity> selectedContactActivities = new ObservableCollection<Activity>();
        private IEnumerable<Opportunity> selectedContactOpportunities;
        private bool isSelectedContactActivitiesLoaded;
        private bool isSelectedContactOpportunitiesLoaded;
        private bool isSelectedContactActivitiesLoading;
        private bool isSelectedContactOpportunitiesLoading;

        public ContactActivitiesViewModel()
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

        public ObservableCollection<CustomAppointmentMain> SelectedContactAppointments { get; set; }

        public ObservableCollection<Activity> SelectedContactActivities
        {
            get
            {
                if (this.DataHasPendingUpdates && !this.isSelectedContactActivitiesLoading)
                {
                    this.isSelectedContactActivitiesLoading = true;
                    this.ActivityRepository.GetActivitiesByContact(this.selectedContact,
                        items =>
                        {
                            this.IsSelectedContactActivitiesLoaded = true;
                            this.isSelectedContactActivitiesLoading = false;
                            this.SelectedContactAppointments.CollectionChanged -= OnSelectedContactAppointmentsCollectionChanged;

                            foreach (var item in items)
                            {
                                this.selectedContactActivities.Add(item);
                                this.SelectedContactAppointments.Add(new CustomAppointmentMain(item));
                            }

                            this.SelectedContactAppointments.CollectionChanged += OnSelectedContactAppointmentsCollectionChanged;

                            this.RaisePropertyChanged("SelectedContactActivities");
                            this.RaisePropertyChanged("SelectedContactAppointments");
                            this.RaisePropertyChanged("OverdueCount");
                            this.RaisePropertyChanged("ActivitiesCount");
                        });
                }

                return this.selectedContactActivities;
            }
        }

        public IEnumerable<Opportunity> SelectedContactOpportunities
        {
            get
            {
                if (this.DataHasPendingUpdates && !this.isSelectedContactOpportunitiesLoading)
                {
                    this.isSelectedContactOpportunitiesLoading = true;
                    this.OpportunityRepository.GetOpportunitiesByContact(this.selectedContact,
                        items =>
                        {
                            this.IsSelectedContactOpportunitiesLoaded = true;
                            this.isSelectedContactOpportunitiesLoading = false;
                            this.DataHasPendingUpdates = false;
                            this.selectedContactOpportunities = items;
                            this.RaisePropertyChanged("SelectedContactOpportunities");
                        });
                }
                return this.selectedContactOpportunities;
            }
        }

        public int OverdueCount
        {
            get
            {
                return (this.SelectedContactActivities != null) ? this.SelectedContactActivities.Count(a => a.StatusType == ActivityStatusType.InProgress && a.IsOverdue) : 0;
            }
        }

        public int ActivitiesCount
        {
            get
            {
                return (this.SelectedContactActivities != null) ? this.SelectedContactActivities.Count() : 0;
            }
        }

        private bool IsSelectedContactActivitiesLoaded
        {
            get
            {
                return this.isSelectedContactActivitiesLoaded;
            }
            set
            {
                this.isSelectedContactActivitiesLoaded = value;
                if (this.IsSelectedContactOpportunitiesLoaded && value)
                {
                    this.DataHasPendingUpdates = false;
                }
            }
        }

        private bool IsSelectedContactOpportunitiesLoaded
        {
            get
            {
                return this.isSelectedContactOpportunitiesLoaded;
            }
            set
            {
                this.isSelectedContactOpportunitiesLoaded = value;
                if (this.IsSelectedContactActivitiesLoaded && value)
                {
                    this.DataHasPendingUpdates = false;
                }
            }
        }

        public override void OnImportsSatisfied()
        {
            this.SelectedContactAppointments = new ObservableCollection<CustomAppointmentMain>();
            this.SelectedContactAppointments.CollectionChanged += this.OnSelectedContactAppointmentsCollectionChanged;
            this.SelectedContactActivities.CollectionChanged += this.OnSelectedContactActivitiesCollectionChanged;
            this.EventAggregator.GetEvent<SelectedContactChangedEvent>().Subscribe(this.OnSelectedContactChanged);
        }

        public void OnSelectedContactChanged(Contact contact)
        {
            this.selectedContact = contact;
            this.SelectedContactAppointments.Clear();
            this.SelectedContactActivities.Clear();
            this.DataHasPendingUpdates = true;
        }

        protected override void OnDataUpdateTriggered()
        {
            this.RaisePropertyChanged("SelectedContactActivities");
            this.RaisePropertyChanged("SelectedContactOpportunities");
        }

        private void OnSelectedContactAppointmentsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                this.SelectedContactActivities.Add((e.NewItems[0] as CustomAppointmentMain).Activity);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Activity activityToRemove = this.SelectedContactActivities.FirstOrDefault(a => a.ActivityID == (e.OldItems[0] as CustomAppointmentMain).Activity.ActivityID);
                var removeSucceeded = this.SelectedContactActivities.Remove(activityToRemove);
                System.Diagnostics.Debug.WriteLine("Remove on SelectedCompanyActivities: {0}", removeSucceeded);
            }
        }

        private void OnSelectedContactActivitiesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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
            foreach (var activity in this.SelectedContactActivities)
            {
                if (!this.ActivityRepository.Context.Activities.Contains(activity))
                {
                    this.ActivityRepository.Context.Activities.Add(activity);
                }
            }
            this.ActivityRepository.SaveOrUpdateEntities();
        }
    }
}
