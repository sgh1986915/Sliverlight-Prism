using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Incidencias.Models;
using Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RichTextBoxUI;
using Telerik.Windows.Controls.RichTextBoxUI.Dialogs;
using Telerik.Windows.Documents.FormatProviders.Html;
using Telerik.Windows.Documents.Proofing;
using Telerik.Windows.Documents.UI.Extensibility;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Views
{
    [ViewExport(RegionName = "IncidenciasDetailsRegion", IsActiveByDefault = false)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CreateTicketUserControl : UserControl
    {
        private string paramValue;
        private string myParamValue;

        public CreateTicketUserControl()
        {
            RadCompositionInitializer.Catalog = new TypeCatalog(
                typeof(HtmlFormatProvider),

                // mini toolbars
                typeof(SelectionMiniToolBar),
                typeof(ImageMiniToolBar),

                // context menu
                typeof(ContextMenu),

                // the default English spellchecking dictionary
                typeof(RadEn_USDictionary),

                // dialogs
                typeof(AddNewBibliographicSourceDialog),
                typeof(ChangeEditingPermissionsDialog),
                typeof(EditCustomDictionaryDialog),
                typeof(FindReplaceDialog),
                typeof(FloatingBlockPropertiesDialog),
                typeof(FontPropertiesDialog),
                typeof(ImageEditorDialog),
                typeof(InsertCaptionDialog),
                typeof(InsertCrossReferenceWindow),
                typeof(InsertDateTimeDialog),
                typeof(InsertTableDialog),
                typeof(InsertTableOfContentsDialog),
                typeof(ManageBibliographicSourcesDialog),
                typeof(ManageBookmarksDialog),
                typeof(ManageStylesDialog),
                typeof(NotesDialog),
                typeof(ProtectDocumentDialog),
                typeof(RadInsertHyperlinkDialog),
                typeof(RadInsertSymbolDialog),
                typeof(RadParagraphPropertiesDialog),
                typeof(SetNumberingValueDialog),
                typeof(SpellCheckingDialog),
                typeof(StyleFormattingPropertiesDialog),
                typeof(TableBordersDialog),
                typeof(TablePropertiesDialog),
                typeof(TabStopsPropertiesDialog),
                typeof(UnprotectDocumentDialog),
                typeof(WatermarkSettingsDialog)
                );

            RadCompositionInitializer.SatisfyImports(new RadRichTextBox());
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(CreateTicketUserControl_Loaded);

            this.myParamValue = "MyParamValue";
        }

        /// <summary>
        /// 
        /// </summary>
        //public override void OnApplyTemplate()
        //{
        //    base.OnApplyTemplate();
        //    this.SetFileCountState();
        //    this.SetBrowseFilter();
        //    this.SetNumericUpDnFormat();
        //}

        private void CreateTicketUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.richTextBox.ChangeTextForeColor(Colors.White);
        }

        private void SetNumericUpDnFormat()
        {
            System.Globalization.NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalDigits = 0;
            //if (this.MaxFileCount != null && this.BrowseFilter != null)
            //{
            //    this.MaxFileCount.NumberFormatInfo = info;
            //}
            //if (this.MaxUploadSize != null && this.BrowseFilter != null)
            //{
            //    this.MaxUploadSize.NumberFormatInfo = info;
            //}
            //if (this.MaxFileSize != null && this.BrowseFilter != null)
            //{
            //    this.MaxFileSize.NumberFormatInfo = info;
            //}
        }

        private void SetBrowseFilter()
        {
            //if (this.RadUpload1 != null && this.BrowseFilter != null)
            //{
            //    this.RadUpload1.Filter = this.BrowseFilter.Text;
            //    this.RadUpload1.FilterIndex = 0;
            //}
        }

        private void SetFileCountState()
        {
            //if (this.RadUpload1 != null)
            //{
            //    bool multiple = this.RadUpload1.IsMultiselect == true;
            //    //if (this.MaxFileCountLabel != null)
            //    //{
            //    //    this.MaxFileCountLabel.Opacity = multiple ? 1.0 : 0.5;
            //    //}
            //    //if (this.MaxFileCount != null)
            //    //{
            //    //    this.MaxFileCount.IsEnabled = multiple;
            //    //}
            //}
        }

        private void ButtonUploadMode_Checked(object sender, RoutedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    RadioButton cb = sender as RadioButton;
            //    if (cb != null)
            //    {
            //        this.RadUpload1.IsAutomaticUpload = cb.Content.ToString().Equals("Automatic");
            //    }
            //}
        }

        private void ButtonAllowMultiple_Checked(object sender, RoutedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    CheckBox cb = sender as CheckBox;
            //    if (cb != null)
            //    {
            //        this.RadUpload1.IsMultiselect = cb.IsChecked == true;
            //    }
            //}
            //this.SetFileCountState();
        }

        private void MaxFileCount_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    //this.RadUpload1.MaxFileCount = (int)this.MaxFileCount.Value;
            //}
        }

        private void MaxUploadSize_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    //this.RadUpload1.MaxUploadSize = (int)this.MaxUploadSize.Value;
            //}
        }

        private void MaxFileSize_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    //this.RadUpload1.MaxFileSize = (int)this.MaxFileSize.Value;
            //}
        }

        private void BrowseFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SetBrowseFilter();
        }

        private void RadUpload1_FileUploadStarting(object sender, Telerik.Windows.Controls.FileUploadStartingEventArgs e)
        {
            // Pass a new parameter to the server handler
            //if(viewModel != null)
            //    e.FileParameters.Add("ObjectId", viewModel.ActiveTicketObject.TicketId);
        }

        private void RadUpload1_FileUploaded(object sender, Telerik.Windows.Controls.FileUploadedEventArgs e)
        {
            //var viewModel = this.DataContext as IncidenciasViewModel;
            //if (viewModel != null)
            //    viewModel.AttachmentsCommand.Execute(e.SelectedFile);
            // Get the value of the returned Parameter from the server
            //var serverReturnedValue = e.HandlerData.CustomData["MyServerParam1"].ToString();
        }

        private void ButtonAllowMoreFiles_Checked(object sender, RoutedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    CheckBox cb = sender as CheckBox;
            //    if (cb != null)
            //    {
            //        this.RadUpload1.IsAppendFilesEnabled = cb.IsChecked == true;
            //    }
            //}
            //this.SetFileCountState();
        }

        private void ButtonAllowDrop_Checked(object sender, RoutedEventArgs e)
        {
            //if (this.RadUpload1 != null)
            //{
            //    CheckBox cb = sender as CheckBox;
            //    if (cb != null)
            //    {
            //        this.RadUpload1.AllowDrop = cb.IsChecked == true;
            //    }
            //}
        }

        private void RadUpload1_UploadStarted(object sender, Telerik.Windows.Controls.UploadStartedEventArgs e)
        {
            this.paramValue = myParamValue;
        }

        private void RadUploadDropPanel1_DragEnter(object sender, DragEventArgs e)
        {
            //Color backgroundColor = new Color();
            //backgroundColor.R = 208;
            //backgroundColor.G = 232;
            //backgroundColor.B = 254;
            //this.RadUploadDropPanel1.Background = new SolidColorBrush(backgroundColor);
        }

        private void RadUploadDropPanel_DragLeave(object sender, DragEventArgs e)
        {
            //this.RadUploadDropPanel1.Background = new SolidColorBrush(Colors.White);
        }
    }
}
