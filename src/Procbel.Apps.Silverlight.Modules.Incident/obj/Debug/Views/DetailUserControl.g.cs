﻿#pragma checksum "D:\Anton\Sliverlight Prism\src\Procbel.Apps.Silverlight.Modules.Incident\Views\DetailUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "56A0DF3733A45C7E20BF49C269DCCCB0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Procbel.Apps.Silverlight.Modules.Incidencias.Views {
    
    
    public partial class DetailUserControl : System.Windows.Controls.UserControl {
        
        internal Telerik.Windows.Documents.FormatProviders.Html.HtmlDataProvider HtmlProvider;
        
        internal Telerik.Windows.Controls.RadRichTextBox richTextBox;
        
        internal System.Windows.Controls.ScrollViewer scrollViewer;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Procbel.Apps.Silverlight.Modules.Incidencias;component/Views/DetailUserControl.x" +
                        "aml", System.UriKind.Relative));
            this.HtmlProvider = ((Telerik.Windows.Documents.FormatProviders.Html.HtmlDataProvider)(this.FindName("HtmlProvider")));
            this.richTextBox = ((Telerik.Windows.Controls.RadRichTextBox)(this.FindName("richTextBox")));
            this.scrollViewer = ((System.Windows.Controls.ScrollViewer)(this.FindName("scrollViewer")));
        }
    }
}

