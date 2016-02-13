using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Procbel.Apps.Model.CRM;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using Procbel.Apps.Silverlight.Repository.Extensions;
using Procbel.Apps.Silverlight.Converters;

namespace Procbel.Apps.Silverlight.Helpers
{
    public static class Categories
    {
        public static readonly CustomCategory CallCategory = new CustomCategory("CALL", (Brush)Application.Current.Resources["CallBrush"]);
        public static readonly CustomCategory MailCategory = new CustomCategory("MAIL", (Brush)Application.Current.Resources["MailBrush"]);
        public static readonly CustomCategory MeetCategory = new CustomCategory("MEET", (Brush)Application.Current.Resources["MeetBrush"]);
    }

    public static class TimeMarkers
    {
        public static readonly TimeMarker NotStartedTimeMarker = new TimeMarker("NOT STARTED", (Brush)Application.Current.Resources["RedBrush"]);
        public static readonly TimeMarker InProgressTimeMarker = new TimeMarker("IN PROGRESS", (Brush)Application.Current.Resources["YellowBrush"]);
        public static readonly TimeMarker DoneTimeMarker = new TimeMarker("DONE", (Brush)Application.Current.Resources["GreenBrush"]);
    }

    public class CustomAppointment : Appointment
    {
        private Activity activity;

        public CustomAppointment()
        {
            this.Activity = new Activity() { Status = 0, Type = 0, Priority = 1 };
            this.UniqueId = "0";
        }

        public CustomAppointment(Activity activity)
        {
            this.Activity = activity;
            this.UniqueId = activity.ActivityID.ToString();
        }

        public Activity Activity
        {
            get
            {
                return this.Storage<CustomAppointment>().activity;
            }
            set
            {
                using (var storage = this.Storage<CustomAppointment>())
                {
                    if (storage.activity != value)
                    {
                        storage.activity = value;
                        this.OnPropertyChanged(() => this.Activity);
                    }
                }
            }
        }

        public override string Body
        {
            get
            {
                return this.Activity.Notes;
            }
            set
            {
                this.Activity.Notes = value;
            }
        }

        public override ICategory Category
        {
            get
            {
                switch (this.Activity.Type)
                {
                    case (int)ActivityType.Mail:
                        return Categories.MailCategory;
                    case (int)ActivityType.Call:
                        return Categories.CallCategory;
                    case (int)ActivityType.Meet:
                        return Categories.MeetCategory;
                    default:
                        return Categories.MailCategory;
                }
            }
            set
            {
                if (value != null)
                {
                    switch (value.CategoryName)
                    {
                        case "MAIL":
                            this.Activity.Type = (int)ActivityType.Mail;
                            break;
                        case "CALL":
                            this.Activity.Type = (int)ActivityType.Call;
                            break;
                        case "MEET":
                            this.Activity.Type = (int)ActivityType.Meet;
                            break;
                        default:
                            this.Activity.Type = (int)ActivityType.Mail;
                            break;
                    }
                }
                this.OnPropertyChanged("Category");
            }
        }

        public override DateTime End
        {
            get
            {
                return this.Activity.DueDate.GetValueOrDefault().ToLocalTime();
            }
            set
            {
                this.Activity.DueDate = value.ToUniversalTime();
                this.OnPropertyChanged("End");
            }
        }

        public override DateTime Start
        {
            get
            {
                return this.Activity.DateCreated.GetValueOrDefault().ToLocalTime();
            }
            set
            {
                this.Activity.DateCreated = value.ToUniversalTime();
            }
        }

        public override string Subject
        {
            get
            {
                return this.Activity.Description;
            }
            set
            {
                this.Activity.Description = value;
            }
        }

        public override Importance Importance
        {
            get
            {
                int priority = this.Activity.Priority.GetValueOrDefault(0);
                var importance = (Importance)PriorityTypeToImportanceConverter.Instance.Convert((PriorityType)priority, typeof(Importance), null, CultureInfo.CurrentCulture);
                return importance;
            }
            set
            {
                var priority = (int)PriorityTypeToImportanceConverter.Instance.ConvertBack(value, typeof(PriorityType), null, CultureInfo.CurrentCulture);
                this.Activity.Priority = priority;
            }
        }

        public override ITimeMarker TimeMarker
        {
            get
            {
                switch (this.Activity.Status)
                {
                    case (int)ActivityStatusType.NotStarted:
                        return TimeMarkers.NotStartedTimeMarker;
                    case (int)ActivityStatusType.InProgress:
                        return TimeMarkers.InProgressTimeMarker;
                    case (int)ActivityStatusType.Done:
                        return TimeMarkers.DoneTimeMarker;
                    default:
                        return TimeMarkers.NotStartedTimeMarker;
                }
            }
            set
            {
                if (value != null)
                {
                    switch (value.TimeMarkerName)
                    {
                        case "NOT STARTED":
                            this.Activity.Status = (int)ActivityStatusType.NotStarted;
                            break;
                        case "IN PROGRESS":
                            this.Activity.Status = (int)ActivityStatusType.InProgress;
                            break;
                        case "DONE":
                            this.Activity.Status = (int)ActivityStatusType.Done;
                            break;
                        default:
                            this.Activity.Status = (int)ActivityStatusType.NotStarted;
                            break;
                    }
                }
            }
        }

        public Opportunity Opportunity
        {
            get
            {
                return this.Activity.Opportunity;
            }
            set
            {
                this.Activity.Opportunity = value;
                this.Activity.OpportunityID = (value != null) ? value.OpportunityID : 0;
            }
        }

        public override void CopyFrom(IAppointment other)
        {
            base.CopyFrom(other);
            CustomAppointment appointment = other as CustomAppointment;
            if (appointment != null)
            {
                this.Opportunity = appointment.Opportunity;
                this.Activity.UpdateAllProperties(appointment.Activity);
            }
        }

        public override IAppointment Copy()
        {
            IAppointment appointment = new CustomAppointment();
            appointment.CopyFrom(this);
            return appointment;
        }
    }

    public class CustomCategory : Category
    {
        public CustomCategory()
            : base()
        {
        }

        public CustomCategory(string categoryName, Brush brush)
            : base(categoryName, brush)
        {
        }

        public override int GetHashCode()
        {
            return this.CategoryName.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return this.CategoryName.Equals((other as CustomCategory).CategoryName);
        }
    }
}