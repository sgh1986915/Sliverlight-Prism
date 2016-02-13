using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.MainRepository.Incidencias;
using Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure;
using Procbel.Apps.Silverlight.Modules.Incidencias.Models;
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
using System.Windows.Shapes;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;
using System.Linq;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AttachedCommentViewModel : NotificationObject, INavigationAware
    {
        #region Fields

        int id;

        #endregion

        public AttachedCommentViewModel()
        {
            this.SaveCommand = new DelegateCommand(OnSaveExecuted, CanSaveExecuted);
        }

        #region Properties Getters and Setters

        private TicketCommentObject activeTicketComment;
        public TicketCommentObject ActiveTicketComment
        {
            get { return this.activeTicketComment; }
            set
            {
                if(value != this.activeTicketComment)
                {
                    this.activeTicketComment = value;
                    this.RaisePropertyChanged(() => this.ActiveTicketComment);
                }
            }
        }

        #endregion

        #region Import Parts

        [Import]
        public IncidenciasRepository IncidenciasRepository { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        #endregion

        #region ICommands

        public DelegateCommand UserControlLostfocusCommand
        {
            get { return new DelegateCommand(OnUserControlLostfocusExecuted); }
        }

        public DelegateCommand CancelCommand
        {
            get { return new DelegateCommand(OnCancelExecuted); }
        }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand TextChangedCommand
        {
            get { return new DelegateCommand(OnTextChangedExecuted); }
        }

        #endregion

        #region Methods

        void OnUserControlLostfocusExecuted()
        {
            this.RegionManager.Regions[IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion].ClearActiveViews();
            this.RegionManager.RequestNavigate(IncidenciasViewRegionNames.IncidenciasMiscDetailsRegion, "IncidenciasOverviewUserControl");
            this.ActiveTicketComment = null;
        }

        void OnCancelExecuted()
        {
            OnUserControlLostfocusExecuted();
        }

        bool CanSaveExecuted()
        {
            if (this.ActiveTicketComment == null) return false;

            return (!string.IsNullOrEmpty(this.ActiveTicketComment.CommentEvent) 
                && !string.IsNullOrEmpty(this.ActiveTicketComment.Comment));
        }

        void OnSaveExecuted()
        {
            if (this.id != 0)
            {
                this.ActiveTicketComment.TicketId = this.id;
                this.IncidenciasRepository.Context.TicketComments.Add(this.ActiveTicketComment.ConvertToEntity());
                this.IncidenciasRepository.Context.SubmitChanges((op) =>
                    {
                        if (op.HasError)
                        {
                            MessageBox.Show(string.Format("Submit Failed: {0}", op.Error.Message));
                            op.MarkErrorAsHandled();
                        }
                        OnUserControlLostfocusExecuted();
                    }, null);
            }
        }

        void OnTextChangedExecuted()
        {
            this.SaveCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region INavigation aware

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.ActiveTicketComment = null;
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            this.id = int.Parse(navigationContext.Parameters["ID"]);
            this.ActiveTicketComment = new TicketCommentObject();
        }

        #endregion
    }
}
