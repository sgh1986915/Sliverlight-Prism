using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.MainRepository;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Telerik.Windows.Data;
using System.Linq;

namespace Procbel.Apps.Silverlight.Modules.Activities.ViewModels
{
    [Export]
    public class ActivitiesViewModel : NotificationObject, IPartImportsSatisfiedNotification, INavigationAware
    {
        private Activity activityToSelect;
        private readonly GroupDescriptor groupDescriptor;
        private readonly SortDescriptor sortDescriptor;
        private Activity selectedActivity;

        public ActivitiesViewModel()
        {
            this.groupDescriptor = new GroupDescriptor()
            {
                Member = "StatusType",
                SortDirection = System.ComponentModel.ListSortDirection.Ascending
            };
            groupDescriptor.AggregateFunctions.Add(new CountFunction() { Caption = "Count:" });

            this.sortDescriptor = new SortDescriptor()
            {
                Member = "DueDate",
                SortDirection = System.ComponentModel.ListSortDirection.Descending
            };
        }

        [Import]
        public ActivityRepository ActivityRepository { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        public Activity SelectedActivity
        {
            get
            {
                return this.selectedActivity;
            }
            set
            {
                if (this.selectedActivity == value)
                {
                    return;
                }
                this.selectedActivity = value;
                this.RaisePropertyChanged("SelectedActivity");
            }
        }

        private QueryableCollectionView activities = null;

        public void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<ActivityClickedEvent>().Subscribe(OnActivityClicked);
        }

        public void OnActivityClicked(object args)
        {
            var activity = (Activity)args;
            this.activityToSelect = activity;
            if (this.Activities != null && this.Activities.Contains(activity))
            {
                this.SelectedActivity = activity;
            }
        }

        public QueryableCollectionView Activities
        {
            get
            {
                if (this.activities == null)
                {
                    this.ApplicationViewModel.IsLoadingData = true;
                    this.ActivityRepository.GetActivities(items =>
                    {
                        this.ApplicationViewModel.IsLoadingData = false;
                        this.activities = new QueryableCollectionView(new List<Activity>(items));
                        //select activity if the user has tried to navigate to one in the UI
                        if (this.activityToSelect != null && items.Contains(activityToSelect))
                        {
                            this.SelectedActivity = items.First(a => a.ActivityID == activityToSelect.ActivityID);
                            this.activities.MoveCurrentTo(this.SelectedActivity);
                        }

                        this.activities.GroupDescriptors.Add(this.groupDescriptor);
                        this.activities.SortDescriptors.Add(this.sortDescriptor);

                        this.RaisePropertyChanged("Activities");
                    });
                }

                return this.activities;
            }
            private set
            {
                if (this.activities == value)
                {
                    return;
                }
                this.activities = value;
                this.RaisePropertyChanged("Activities");
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.activityToSelect = this.SelectedActivity;
            this.Activities = null;
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
