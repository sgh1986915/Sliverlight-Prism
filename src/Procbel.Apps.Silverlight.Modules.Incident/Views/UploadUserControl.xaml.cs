using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Views
{
    [ViewExport(RegionName = "IncidenciasMiscDetailsRegion", IsActiveByDefault = false)]
    public partial class UploadUserControl : UserControl
    {
        private string paramValue;
        private string myParamValue;

        public UploadUserControl()
        {
            InitializeComponent();

            this.myParamValue = "MyParamValue";
        }

        [Import]
        public UploadViewModel ViewModel
        {
            get { return this.DataContext as UploadViewModel; }
            set
            {
                this.DataContext = value;
            }
        }

        private void RadUpload1_FileUploadStarting(object sender, Telerik.Windows.Controls.FileUploadStartingEventArgs e)
        {
            // Pass a new parameter to the server handler
            //if(viewModel != null)
            //    e.FileParameters.Add("ObjectId", viewModel.ActiveTicketObject.TicketId);
        }

        private void RadUpload1_FileUploaded(object sender, Telerik.Windows.Controls.FileUploadedEventArgs e)
        {
            var viewModel = this.DataContext as UploadViewModel;
            if (viewModel != null)
                viewModel.AttachmentsCommand.Execute(e.SelectedFile);
            // Get the value of the returned Parameter from the server
            //var serverReturnedValue = e.HandlerData.CustomData["MyServerParam1"].ToString();
        }

        private void RadUpload1_UploadStarted(object sender, Telerik.Windows.Controls.UploadStartedEventArgs e)
        {
            this.paramValue = myParamValue;
        }
    }
}
