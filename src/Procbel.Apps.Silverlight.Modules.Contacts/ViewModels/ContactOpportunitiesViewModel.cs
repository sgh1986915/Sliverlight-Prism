using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Contacts.Helpers;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Contacts.ViewModels
{
    [Export]
    public class ContactOpportunitiesViewModel : NavigationAwareDataViewModel
    {
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public OpportunityRepository OpportunitiesRepository { get; set; }

        public override void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<SelectedContactChangedEvent>().Subscribe(this.OnSelectedContactChanged);
        }

        public void OnSelectedContactChanged(Contact contact)
        {
            this.SelectedContact = contact;
            this.DataHasPendingUpdates = true;
        }

        private Contact selectedContact;

        public Contact SelectedContact
        {
            get
            {
                return this.selectedContact;
            }
            set
            {
                if (this.selectedContact == value)
                {
                    return;
                }
                this.selectedContact = value;
                this.RaisePropertyChanged("SelectedContact");
            }
        }
        private IEnumerable<Opportunity> opportunitiesForContact;
        public IEnumerable<Opportunity> OpportunitiesForContact
        {
            get
            {
                if (this.DataHasPendingUpdates)
                {
                    this.OpportunitiesRepository.GetOpportunitiesByContactID(this.SelectedContact.ContactID,
                         items =>
                         {
                             this.DataHasPendingUpdates = false;
                             this.opportunitiesForContact = new ObservableCollection<Opportunity>(new List<Opportunity>(items));
                             this.RaisePropertyChanged("OpportunitiesForContact");
                             this.RaisePropertyChanged("TotalAmount");
                             this.RaisePropertyChanged("OpenCount");
                             this.RaisePropertyChanged("OverdueCount");
                         });
                    return Enumerable.Empty<Opportunity>();
                }

                return opportunitiesForContact;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                var sum = (this.OpportunitiesForContact != null) ? this.OpportunitiesForContact.Sum(x => x.TotalPrice) : 0;
                return sum;
            }
        }

        public int OpenCount
        {
            get
            {
                var count = (this.OpportunitiesForContact != null) ? this.OpportunitiesForContact.Count(o => o.StatusType == OpportunityStatusType.Open) : 0;
                return count;
            }
        }

        public int OverdueCount
        {
            get
            {
                return (this.OpportunitiesForContact != null) ? this.OpportunitiesForContact.Count(o => o.StatusType == OpportunityStatusType.Open && o.EstimationCloseDate.HasValue && o.EstimationCloseDate.Value < DateTime.Now) : 0;
            }
        }

        protected override void OnDataUpdateTriggered()
        {
            this.RaisePropertyChanged("OpportunitiesForContact");
        }
    }
}
