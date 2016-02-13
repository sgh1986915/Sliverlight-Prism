using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Silverlight.MainRepository.Incidencias;
using Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure;
using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using tk = Telerik.Windows.Controls;
using System.Windows.Shapes;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using Procbel.Apps.Model.Main;
using System.Windows.Browser;
using System.Windows.Threading;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UploadViewModel : NotificationObject, INavigationAware
    {
        int id;
        public UploadViewModel()
        {
            this.removeUploadInteractionRequest = new InteractionRequest<Notification>();
        }

        #region Import Parts

        [Import]
        public IncidenciasRepository IncidenciasRepository { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        #endregion

        #region Properties Getters and Setters

        /// <summary>
        /// Remove or clear the Upload control's items to empty.
        /// </summary>
        readonly InteractionRequest<Notification> removeUploadInteractionRequest;
        public IInteractionRequest RemoveUploadInteractionRequest
        {
            get { return this.removeUploadInteractionRequest; }
        }

        private string fileDescription;
        public string FileDescription
        {
            get { return this.fileDescription; }
            set
            {
                if (value != this.fileDescription)
                {
                    this.fileDescription = value;
                    this.RaisePropertyChanged(() => this.FileDescription);
                }
            }
        }

        #endregion

        #region ICommnads

        public DelegateCommand<object> AttachmentsCommand
        {
            get { return new DelegateCommand<object>(OnAttachmentsExecuted); }
        }

        public DelegateCommand UserControlLostfocusCommand
        {
            get { return new DelegateCommand(OnUserControlLostfocusExecuted); }
        }

        public DelegateCommand CancelCommand
        {
            get { return new DelegateCommand(OnCancelExecuted); }
        }

        #endregion

        #region Methods

        void OnAttachmentsExecuted(object obj)
        {
            if (obj != null && this.id != 0)
            {
                var item = obj as tk.RadUploadSelectedFile;
                Uri uri = new Uri(HtmlPage.Document.DocumentUri, "DocumentFiles" + "\\" + item.Name);
                TicketAttachment addItem = new TicketAttachment
                {
                    TicketId = this.id,
                    FileName = item.Name,
                    FileSize = Convert.ToInt32(item.Size),
                    FileType = item.File.Extension,
                    //TODO: 002 - Uploaded by need fixed!
                    UploadedBy = "Admin",
                    UploadedDate = DateTime.Now,
                    FileDescription = this.FileDescription,
                    IsPending = true,
                    FileUrl = uri.ToString()
                };

                IncidenciasRepository.Context.TicketAttachments.Add(addItem);
                // Save changed
                if (!IncidenciasRepository.Context.IsSubmitting)
                    IncidenciasRepository.Context.SubmitChanges();
                else
                    SaveChanged();

                IncidenciasRepository.Context.GetTicketAttachmentsQuery();
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
                }, null);
                timer.Stop();
            };
            timer.Start();
        }

        void OnUserControlLostfocusExecuted()
        {
            OnCancelExecuted();
        }

        void OnCancelExecuted()
        {
            this.RegionManager.Regions[IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion].ClearActiveViews();
            this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion, "IncidenciasOverviewUserControl");
        }

        void ClearItemsUploadControl()
        {
            this.removeUploadInteractionRequest.Raise(new Notification());
        }

        #endregion

        #region INavigation Aware

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.id = int.Parse(navigationContext.Parameters["ID"]);
            ClearItemsUploadControl();
        }

        #endregion
    }
}
