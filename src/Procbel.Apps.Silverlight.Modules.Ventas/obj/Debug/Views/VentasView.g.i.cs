﻿#pragma checksum "D:\Anton\Sliverlight Prism\src\Procbel.Apps.Silverlight.Modules.Ventas\Views\VentasView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0F557A7F34CBA5920DBB3E7A69919731"
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


namespace Procbel.Apps.Silverlight.Modules.Ventas.Views {
    
    
    public partial class VentasView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal RadDomainDataSource activitiesDataSource;
        
        internal RadDomainDataSource contactsDataSource;
        
        internal RadDomainDataSource opportunitiesDataSource;
        
        internal System.Windows.Controls.Grid contactsGrid;
        
        internal RadCoverFlow coverFlow;
        
        internal System.Windows.Controls.Grid statsGrid;
        
        internal RadUniformGrid statsItemsControl;
        
        internal System.Windows.Controls.Grid activitiesGrid;
        
        internal System.Windows.Controls.ItemsControl activitiesItemsControl;
        
        internal System.Windows.Controls.Grid opportunitiesGrid;
        
        internal System.Windows.Controls.ItemsControl opportunitiesItemsControl;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Procbel.Apps.Silverlight.Modules.Ventas;component/Views/VentasView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.activitiesDataSource = ((RadDomainDataSource)(this.FindName("activitiesDataSource")));
            this.contactsDataSource = ((RadDomainDataSource)(this.FindName("contactsDataSource")));
            this.opportunitiesDataSource = ((RadDomainDataSource)(this.FindName("opportunitiesDataSource")));
            this.contactsGrid = ((System.Windows.Controls.Grid)(this.FindName("contactsGrid")));
            this.coverFlow = ((RadCoverFlow)(this.FindName("coverFlow")));
            this.statsGrid = ((System.Windows.Controls.Grid)(this.FindName("statsGrid")));
            this.statsItemsControl = ((RadUniformGrid)(this.FindName("statsItemsControl")));
            this.activitiesGrid = ((System.Windows.Controls.Grid)(this.FindName("activitiesGrid")));
            this.activitiesItemsControl = ((System.Windows.Controls.ItemsControl)(this.FindName("activitiesItemsControl")));
            this.opportunitiesGrid = ((System.Windows.Controls.Grid)(this.FindName("opportunitiesGrid")));
            this.opportunitiesItemsControl = ((System.Windows.Controls.ItemsControl)(this.FindName("opportunitiesItemsControl")));
        }
    }
}
