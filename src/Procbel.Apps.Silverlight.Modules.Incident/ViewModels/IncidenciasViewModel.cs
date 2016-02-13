using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure;
using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Procbel.Apps.Silverlight.Web.Services;
using Procbel.Apps.Silverlight.Infrastructure;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Silverlight.Modules.Incidencias.Models;
using Procbel.Apps.Model.Main;
using System.Collections.Generic;
using tk = Telerik.Windows.Controls;
using System.Windows.Browser;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.ComponentModel;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Procbel.Apps.Silverlight.MainRepository.Incidencias;
using Microsoft.Practices.Prism;
using System.Collections.ObjectModel;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels
{
    [Export]
    public class IncidenciasViewModel : NotificationObject, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Fields

        bool isTextboxVisibility;
        bool isAdd;
        const String STRING_CONFIRMDELETECAPTION = "Confirm Delete";
        const String STRING_CONFIRMDELETEMESSAGE = "Are you sure you want to DELETE this item?";
        readonly InteractionRequest<Notification> textBoxFocusInteractionRequest;

        #endregion

        public IncidenciasViewModel()
        {
            SubscriptCommand();
            this.textBoxFocusInteractionRequest = new InteractionRequest<Notification>();
        }

        #region declaration

        #endregion

        #region Import parts

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IncidenciasRepository IncidenciasRepository { get; set; }

        #endregion

        #region Properites Getters and Setters

        public IInteractionRequest TextBoxFocusInteractionRequest
        {
            get { return this.textBoxFocusInteractionRequest; }
        }

        private ObservableCollection<TicketTag> ticketTagList;
        public ObservableCollection<TicketTag> TicketTagList
        {
            get
            {
                return this.ticketTagList;
            }
            set
            {
                if (value != this.ticketTagList)
                {
                    this.ticketTagList = value;
                    this.RaisePropertyChanged(() => this.TicketTagList);
                }
            }
        }

        private Visibility searchButtonVisibility = Visibility.Collapsed;
        public Visibility SearchButtonVisibility
        {
            get { return this.searchButtonVisibility; }
            set
            {
                if (value != this.searchButtonVisibility)
                {
                    this.searchButtonVisibility = value;
                    this.RaisePropertyChanged(() => this.SearchButtonVisibility);
                }
            }
        }

        /// <summary>
        /// For Textbox
        /// </summary>
        private Visibility searchVisibility = Visibility.Collapsed;
        public Visibility SearchVisibility
        {
            get { return this.searchVisibility; }
            set
            {
                if (value != this.searchVisibility)
                {
                    this.searchVisibility = value;
                    this.RaisePropertyChanged(() => this.SearchVisibility);
                }
            }
        }

        private string searchMessage;
        public string SearchMessage
        {
            get { return this.searchMessage; }
            set
            {
                if (value != this.searchMessage)
                {
                    this.searchMessage = value;
                    this.RaisePropertyChanged(() => this.SearchMessage);
                }
            }
        }

        private TicketAttachment attachmentSelectedItem;
        public TicketAttachment AttachmentSelectedItem
        {
            get { return this.attachmentSelectedItem; }
            set
            {
                if (value != this.attachmentSelectedItem)
                {
                    this.attachmentSelectedItem = value;
                    this.RaisePropertyChanged(() => this.AttachmentSelectedItem);
                }
            }
        }

        public bool IsInOverviewState
        {
            get
            {
                return this.State == IncidenciasViewState.Overview;
            }
        }

        private Visibility createdViewVisibility = Visibility.Collapsed;
        public Visibility CreatedViewVisibility
        {
            get { return this.createdViewVisibility; }
            set
            {
                if (value != this.createdViewVisibility)
                {
                    this.createdViewVisibility = value;
                    this.RaisePropertyChanged(() => this.CreatedViewVisibility);
                }
            }
        }

        private Visibility editedViewVisibility = Visibility.Collapsed;
        public Visibility EditedViewVisibility
        {
            get { return this.editedViewVisibility; }
            set
            {
                if (value != this.editedViewVisibility)
                {
                    this.editedViewVisibility = value;
                    this.RaisePropertyChanged(() => this.EditedViewVisibility);
                }
            }
        }

        private Code prioritySelectedItem;
        public Code PrioritySelectedItem
        {
            get { return this.prioritySelectedItem; }
            set
            {
                if (value != this.prioritySelectedItem)
                {
                    this.prioritySelectedItem = value;
                    this.RaisePropertyChanged(() => this.PrioritySelectedItem);
                }
            }
        }

        private IEnumerable<Code> listingPriority;
        public IEnumerable<Code> ListingPriority
        {
            get 
            {
                if (this.listingPriority == null)
                {
                    IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetCodesQuery(), (op) =>
                        {
                            this.ListingPriority = IncidenciasRepository.Context.Codes;
                        },null);
                }
                return this.listingPriority; 
            }
            set
            {
                if (value != this.listingPriority)
                {
                    this.listingPriority = value;
                    this.RaisePropertyChanged(() => this.ListingPriority);
                }
            }
        }

        private Ticket searchResultSelectedItem;
        public Ticket SearchResultSelectedItem
        {
            get { return this.searchResultSelectedItem; }
            set
            {
                if (value != this.searchResultSelectedItem)
                {
                    this.searchResultSelectedItem = value;
                    this.RaisePropertyChanged(() => this.SearchResultSelectedItem);
                    RecordSelected(value);
                }
            }
        }

        private IncidenciasViewState state;
        public IncidenciasViewState State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (value != this.state)
                {
                    this.state = value;
                    this.RaisePropertyChanged(() => this.State);
                    this.RaisePropertyChanged(() => this.IsInOverviewState);
                }
            }
        }

        private PagedCollectionView listingTickets;
        public PagedCollectionView ListingTickets
        {
            get
            {
                return this.listingTickets;
            }
            set
            {
                if (value != this.listingTickets)
                {
                    this.listingTickets = value;
                    this.RaisePropertyChanged(() => this.ListingTickets);
                }
            }
        }

        private Visibility createVisibility = Visibility.Visible;
        public Visibility CreateVisibility
        {
            get { return this.createVisibility; }
            set
            {
                if (value != this.createVisibility)
                {
                    this.createVisibility = value;
                    this.RaisePropertyChanged(() => this.CreateVisibility);
                }
            }
        }

        private Visibility uploadVisibility = Visibility.Collapsed;
        public Visibility UploadVisibility
        {
            get { return this.uploadVisibility; }
            set
            {
                if (value != this.uploadVisibility)
                {
                    this.uploadVisibility = value;
                    this.RaisePropertyChanged(() => this.UploadVisibility);
                }
            }
        }

        private TicketObject activeTicketObject;
        public TicketObject ActiveTicketObject
        {
            get { return this.activeTicketObject; }
            set
            {
                if (value != this.activeTicketObject)
                {
                    this.activeTicketObject = value;
                    this.RaisePropertyChanged(() => this.ActiveTicketObject);
                }
            }
        }

        private TicketType ticketTypeSelectedItem;
        public TicketType TicketTypeSelectedItem
        {
            get { return this.ticketTypeSelectedItem; }
            set
            {
                if (value != this.ticketTypeSelectedItem)
                {
                    this.ticketTypeSelectedItem = value;
                    this.RaisePropertyChanged(() => this.TicketTypeSelectedItem);

                    //Update command button
                    ResetViewState();
                }
            }
        }

        private IEnumerable<TicketType> listingTicketTypes;
        public IEnumerable<TicketType> ListingTicketTypes
        {
            get 
            {
                return this.listingTicketTypes; 
            }
            set
            {
                if (value != this.listingTicketTypes)
                {
                    this.listingTicketTypes = value;
                    this.RaisePropertyChanged(() => this.ListingTicketTypes);
                }
            }
        }

        private TicketCategory ticketCategorySelectedItem;
        public TicketCategory TicketCategorySelectedItem
        {
            get { return this.ticketCategorySelectedItem; }
            set
            {
                if (value != this.ticketCategorySelectedItem)
                {
                    this.ticketCategorySelectedItem = value;
                    this.RaisePropertyChanged(() => this.TicketCategorySelectedItem);
                    //Update command button
                    ResetViewState();
                }
            }
        }

        private IEnumerable<TicketCategory> listingTicketCategory;
        public IEnumerable<TicketCategory> ListingTicketCategory
        {
            get
            {
                return this.listingTicketCategory;
            }
            set
            {
                if (value != this.listingTicketCategory)
                {
                    this.listingTicketCategory = value;
                    this.RaisePropertyChanged(() => this.ListingTicketCategory);
                }
            }
        }

        private bool createButtonIsEnabled;
        public bool CreateButtonIsEnabled
        {
            get { return this.createButtonIsEnabled; }
            set
            {
                if (value != this.createButtonIsEnabled)
                {
                    this.createButtonIsEnabled = value;
                    this.RaisePropertyChanged(() => this.CreateButtonIsEnabled);
                }
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set
            {
                if (value != this.isBusy)
                {
                    this.isBusy = value;
                    this.RaisePropertyChanged(() => this.IsBusy);

                    if (this.isBusy)
                    {
                        var backgroundWorker = new BackgroundWorker();
                        backgroundWorker.DoWork += this.OnBackgroundWorkerDoWork;
                        backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
                        backgroundWorker.RunWorkerAsync();
                    }
                }
            }
        }

        private string busyContent = "Loading...";
        public string BusyContent
        {
            get { return this.busyContent; }
            set
            {
                if (this.busyContent != value)
                {
                    this.busyContent = value;
                    this.RaisePropertyChanged(() => this.BusyContent);
                }
            }
        }

        #endregion

        #region ICommands

        // Save new Entity into database.
        public DelegateCommand CreateCommand { get; set; }

        public DelegateCommand SearchButtonCommand
        {
            get { return new DelegateCommand(OnSearchButtonExecuted); }
        }

        public DelegateCommand SearchCommand
        {
            get { return new DelegateCommand(OnSearchExecuted); }
        }

        public DelegateCommand DeleteAttachmentCommand
        {
            get { return new DelegateCommand(OnDeleteAttachmentExecuted); }
        }

        public DelegateCommand DeleteTicketCommand
        {
            get { return new DelegateCommand(OnDeleteTicketExecuted); }
        }

        public DelegateCommand AddNewAttachmentCommand
        {
            get { return new DelegateCommand(OnAddNewAttachmentExecuted); }
        }

        /// <summary>
        /// Adding a new comment into the Ticket entities
        /// </summary>
        public DelegateCommand AddNewCommentCommand
        {
            get { return new DelegateCommand(OnAddNewCommentExecuted); }
        }

        public DelegateCommand<string> SwitchToVisualStateCommand
        {
            get { return new DelegateCommand<string>(OnSwitchToVisualState); }
        }

        public DelegateCommand UpdateCommand
        {
            get { return new DelegateCommand(OnUpdateExecuted); }
        }

        public DelegateCommand TextChangedCommand
        {
            get { return new DelegateCommand(OnTextChangedExecuted); }
        }

        public DelegateCommand CancelCommand
        {
            get { return new DelegateCommand(OnCancelExecuted); }
        }

        public DelegateCommand AddNewCommand
        {
            get { return new DelegateCommand(OnAddNewExecuted); }
        }

        public DelegateCommand EditCommand
        {
            get { return new DelegateCommand(OnEditExecuted); }
        }

        #endregion

        #region Methods

        private void OnSearchButtonExecuted()
        {
            this.isTextboxVisibility = !this.isTextboxVisibility;
            if (this.isTextboxVisibility)
            {
                this.SearchVisibility = Visibility.Visible;
                this.textBoxFocusInteractionRequest.Raise(null);
            }
            else
            {
                this.SearchVisibility = Visibility.Collapsed;
            }
        }

        private void OnSearchExecuted()
        {
            if (this.SearchMessage != null)
            {
                this.ListingTickets.Filter = null;
                this.ListingTickets.Filter = new Predicate<object>(FilterRecords);
            }
        }

        /// <summary>
        /// Filters the records.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        private bool FilterRecords(object obj)
        {
            var ticket = obj as Ticket;
            return ticket != null && (ticket.Title.ToLower().StartsWith(this.SearchMessage.ToLower()))
                || (ticket.TagList.ToLower().StartsWith(this.SearchMessage.ToLower()));
        }

        private void OnDeleteAttachmentExecuted()
        {
            if (this.AttachmentSelectedItem != null)
            {
                if (MessageBox.Show(STRING_CONFIRMDELETEMESSAGE, STRING_CONFIRMDELETECAPTION, MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

                var itemToDelete = this.AttachmentSelectedItem as TicketAttachment;
                this.IncidenciasRepository.Context.TicketAttachments.Remove(itemToDelete);
                this.IncidenciasRepository.Context.SubmitChanges();
            }
        }

        private void OnDeleteTicketExecuted()
        {
            if (this.SearchResultSelectedItem != null)
            {
                if(MessageBox.Show(STRING_CONFIRMDELETEMESSAGE, STRING_CONFIRMDELETECAPTION, MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

                var itemToDelete = this.SearchResultSelectedItem as Ticket;
                this.IncidenciasRepository.Context.Tickets.Remove(itemToDelete);
                this.IncidenciasRepository.Context.SubmitChanges();
            }
        }

        private void OnAddNewAttachmentExecuted()
        {
            if (this.SearchResultSelectedItem != null)
            {
                UriQuery query = new UriQuery();
                query.Add("ID", (this.SearchResultSelectedItem as Ticket).TicketId.ToString());
                this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion, "UploadUserControl" + query.ToString());
            }
        }

        /// <summary>
        /// Open the AttachedmentUserControl view
        /// </summary>
        private void OnAddNewCommentExecuted()
        {
            if (this.SearchResultSelectedItem != null)
            {
                UriQuery query = new UriQuery();
                query.Add("ID",(this.SearchResultSelectedItem as Ticket).TicketId.ToString());
                this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion, "AttachedmentUserControl" + query.ToString());
            }
        }

        private void OnSwitchToVisualState(string stateName)
        {
            this.State = ParseCompaniesViewState(stateName);
            var region = this.RegionManager.Regions[IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion];

            switch (this.State)
            {
                case IncidenciasViewState.Overview:
                    region.RequestNavigate("IncidenciasOverviewUserControl");
                    this.SearchButtonVisibility = Visibility.Visible;
                    break;
                case IncidenciasViewState.Opportunities:
                    region.RequestNavigate("CompanyOpportunitiesUserControl");
                    break;
                case IncidenciasViewState.Contacts:
                    region.RequestNavigate("CompanyContactsUserControl");
                    break;
                case IncidenciasViewState.Activities:
                    region.RequestNavigate("CompanyActivitiesUserControl");
                    break;
                default:
                    ClearRegionActiveViews(region);
                    this.SearchButtonVisibility = Visibility.Collapsed;
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

        private IncidenciasViewState ParseCompaniesViewState(string stateName)
        {
            var parsedState = Enum.Parse(typeof(IncidenciasViewState), stateName, true);
            var resultState = (IncidenciasViewState)parsedState;
            return resultState;
        }

        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            backgroundWorker.DoWork -= this.OnBackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted -= OnBackgroundWorkerRunWorkerCompleted;
        }

        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetTicketStatusSetQuery(), (op) => { }, null);
            IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetTicketAttachmentsQuery(), (op) => 
            {
                //this.IncidenciasRepository.Context.TicketAttachments.OrderByDescending(o => o.UploadedDate);

            }, null);

            IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetTicketTypeSetQuery(), (op) =>
            {
                this.ListingTicketTypes = IncidenciasRepository.Context.TicketTypes;
            }, null);

            IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetTicketCategorySetQuery(), (op) =>
            {
                this.ListingTicketCategory = IncidenciasRepository.Context.TicketCategories;
            }, null);

            IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetTicketCommentsQuery(), (op) => { }, null);

            // Loading Ticket Tag
            this.IncidenciasRepository.Context.Load(this.IncidenciasRepository.Context.GetTicketTagsQuery(), (op) =>
            {
                this.ticketTagList = new ObservableCollection<TicketTag>(this.IncidenciasRepository.Context.TicketTags);
            }, null);

            IncidenciasRepository.Context.Load(IncidenciasRepository.Context.GetTicketsQuery(), (op) =>
            {
                this.ListingTickets = new PagedCollectionView(IncidenciasRepository.Context.Tickets);
                // Disable the Busy Indicator
                this.IsBusy = false;
            }, null);
        }

        /// <summary>
        /// Update an Entity into database.
        /// </summary>
        void OnUpdateExecuted()
        {
            // Exchanges data between domain model for the update entity
            ExchangedData();

            if (!IncidenciasRepository.Context.IsSubmitting)
            {
                IncidenciasRepository.Context.SubmitChanges((op) =>
                {
                    if (op.HasError)
                    {
                        MessageBox.Show(string.Format("Submit Failed: {0}", op.Error.Message));
                        op.MarkErrorAsHandled();
                    }
                    // Switch to Detail view, similar master and detail. It is regular view
                    RecordSelected(this.SearchResultSelectedItem);
                }, null);
            }
            else
            {
                SaveChanged();
            }
        }

        void SaveChanged()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                IncidenciasRepository.Context.SubmitChanges((op) =>
                {
                    if (op.HasError)
                    {
                        MessageBox.Show(string.Format("Submit Failed: {0}", op.Error.Message));
                        op.MarkErrorAsHandled();
                    }
                    // Switch to Detail view, similar master and detail. It is regular view
                    RecordSelected(this.SearchResultSelectedItem);
                }, null);
            };
            timer.Start();
        }

        // Need updated when there's more fields need saved.
        void ExchangedData()
        {
            this.SearchResultSelectedItem.Title = this.ActiveTicketObject.Title;
            this.SearchResultSelectedItem.TicketTypeTicketTypeId = this.ActiveTicketObject.TicketTypeTicketTypeId;
            this.SearchResultSelectedItem.TicketCategoryTicketCategoryId = this.ActiveTicketObject.TicketCategoryTicketCategoryId;
            this.SearchResultSelectedItem.TagList = this.ActiveTicketObject.TagList;
            this.SearchResultSelectedItem.Details = this.ActiveTicketObject.Details;
        }

        void OnTextChangedExecuted()
        {
            ResetViewState();
        }

        /// <summary>
        /// When selection's event is triged, We don't need to raise multiple events
        /// </summary>
        /// <param name="value">The value is Ticket entity that sent from UI</param>
        void RecordSelected(Ticket value)
        {
            this.ActiveTicketObject = null;
            if (value != null)
            {
                this.ActiveTicketObject = value.ConvertToEntity();

                // Update the ImagePath
                this.ActiveTicketObject.ImagePath = value.TicketAttachments.Select(o => o.FileUrl).FirstOrDefault();

                this.RegionManager.Regions[IncidenciasViewRegionNames.IncidenciasDetailsRegion].ClearActiveViews();
                this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasDetailsRegion, "DetailUserControl");
            }

            UpdateCreatedView(true);
        }

        void OnCancelExecuted()
        {
            RecordSelected(this.SearchResultSelectedItem);
        }

        void OnEditExecuted()
        {
            this.isAdd = false;
            if (this.SearchResultSelectedItem == null)
            {
                // Need implemented MessageBox
                MessageBox.Show("Please selects an item to update");
                return;
            }

            // Exchanges the data between domain model, then revert it back
            this.ActiveTicketObject = this.SearchResultSelectedItem.ConvertToEntity();

            this.RegionManager.Regions[IncidenciasViewRegionNames.IncidenciasDetailsRegion].ClearActiveViews();

            // Editing and updatting uses the same views. It's changed
            this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasDetailsRegion, "CreateTicketUserControl");

            // Show first Layout for create view
            //UpdateCreatedView(true);

            // Update buttons command
            ResetViewState();
        }

        void OnAddNewExecuted()
        {
            this.isAdd = true;
            UpdateCreatedView(true);

            this.ActiveTicketObject = new TicketObject();

            this.RegionManager.Regions[IncidenciasViewRegionNames.IncidenciasDetailsRegion].ClearActiveViews();
            this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasDetailsRegion, "CreateTicketUserControl");
        }

        bool CanCreateExecuted()
        {
            var result = this.TicketTypeSelectedItem != null && this.TicketCategorySelectedItem != null
                && (!string.IsNullOrEmpty(this.ActiveTicketObject.Title) || !string.IsNullOrWhiteSpace(this.ActiveTicketObject.Title));
            if (result)
                this.CreateButtonIsEnabled = true;

            return result;
        }

        void OnCreateOrUpdateExecuted()
        {
            if (this.isAdd)
                OnCreateExecuted();
            else
                OnUpdateExecuted();
        }

        /// <summary>
        /// Add new entities into the database.
        /// </summary>
        void OnCreateExecuted()
        {
            // Set the Button's IsEnabled to prevent double click. 
            this.CreateButtonIsEnabled = false;

            IncidenciasRepository.Context.Tickets.Add(this.ActiveTicketObject.ConvertToEntity());
            IncidenciasRepository.Context.SubmitChanges((op) => {
                if (op.HasError)
                {
                    MessageBox.Show(string.Format("Submit Failed: {0}", op.Error.Message));
                    op.MarkErrorAsHandled();
                }

                // Hide first Layout
                //UpdateCreatedView(false);
                // When create an entity is that the Upload process need the current entity's ID.
                this.ActiveTicketObject.TicketId = (from db in IncidenciasRepository.Context.Tickets.OrderByDescending(o => o.TicketId) select db)
                    .FirstOrDefault().TicketId;

                this.ListingTickets.MoveCurrentToLast();
                this.RecordSelected(this.SearchResultSelectedItem);
            },null);
        }

        void UpdateCreatedView(bool isFirstLayout)
        {
            //if (isFirstLayout)
            //{
            //    this.CreateVisibility = Visibility.Visible;
            //    this.UploadVisibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    this.CreateVisibility = Visibility.Collapsed;
            //    this.UploadVisibility = Visibility.Visible;
            //}

            //// Remove or clear the Upload control items to empty
            //this.removeUploadInteractionRequest.Raise(new Notification());

            //this.SearchResultSelectedItem = this.ActiveTicketObject.ConvertToEntity();
        }

        void SubscriptCommand()
        {
            this.CreateCommand = new DelegateCommand(OnCreateOrUpdateExecuted, CanCreateExecuted);
        }

        #endregion

        #region Reset views's states

        void ResetViewState()
        {
            this.CreateCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Prism Framework

        public void OnImportsSatisfied()
        {
            this.RaisePropertyChanged(() => this.ActiveTicketObject);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        #endregion
    }
}
