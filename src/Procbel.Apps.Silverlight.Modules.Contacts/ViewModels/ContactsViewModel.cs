using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using System;
using System.ComponentModel;
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
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Modules.Contacts.Infrastructure;
using Procbel.Apps.Silverlight.Modules.Contacts.Helpers;
using Procbel.Apps.Silverlight.MainRepository;

namespace Procbel.Apps.Silverlight.Modules.Contacts.ViewModels
{
    [Export]
    public class ContactsViewModel : NotificationObject, IPartImportsSatisfiedNotification
    {
        private Contact contactToSelect;

        public ContactsViewModel()
        {
            this.SwitchToVisualStateCommand = new DelegateCommand<string>(OnSwitchToVisualState);
        }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public ContactRepository ContactRepository { get; set; }

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
                RaiseSelectedContactChangedEvent();
            }
        }

        private void RaiseSelectedContactChangedEvent()
        {
            this.EventAggregator.GetEvent<SelectedContactChangedEvent>().Publish(this.SelectedContact);
        }

        public void OnImportsSatisfied()
        {
            ContactClickedEvent eve = this.EventAggregator.GetEvent<ContactClickedEvent>();
            eve.Subscribe(OnContactClickedEvent);
        }

        public void OnContactClickedEvent(object obj)
        {
            var contact = (Contact)obj;
            this.contactToSelect = contact;
            if (this.Contacts != null && this.Contacts.Contains(contact))
            {
                this.SelectedContact = contact;
            }
        }

        private ICollectionView contacts = null;
        public ICollectionView Contacts
        {
            get
            {
                //if (this.contacts == null)
                //{
                //this.ContactRepository.GetContacts(items =>
                //{
                //    this.contacts = new QueryableCollectionView(new ObservableCollection<Contact>(items));
                //    this.RaisePropertyChanged("Contacts");
                //});
                //}

                return this.contacts;
            }
            set
            {
                this.contacts = value;
                //select contact if the user has tried to navigate to one in the UI
                if (value != null && this.contactToSelect != null)
                {
                    this.SelectedContact = contactToSelect;
                }
                this.RaisePropertyChanged("Contacts");
            }
        }

        public void SwitchRegion(string regionName, string path)
        {
            this.RegionManager.RequestNavigate(regionName, path);
        }

        private ContactsViewState state;
        public ContactsViewState State
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
            }
        }

        public ICommand SwitchToVisualStateCommand { get; set; }

        private void OnSwitchToVisualState(string stateName)
        {
            this.State = ParseContactsViewState(stateName);
            var region = this.RegionManager.Regions[ContactsViewRegionNames.ContactMiscDetails];

            switch (this.State)
            {
                case ContactsViewState.Opportunities:
                    region.RequestNavigate("ContactOpportunitiesUserControl");
                    break;
                case ContactsViewState.Activities:
                    region.RequestNavigate("ContactActivitiesUserControl");
                    break;
                default:
                    region.ClearActiveViews();
                    break;
            }
        }

        private ContactsViewState ParseContactsViewState(string stateName)
        {
            var parsedState = Enum.Parse(typeof(ContactsViewState), stateName, true);
            var resultState = (ContactsViewState)parsedState;
            return resultState;
        }
    }
}
