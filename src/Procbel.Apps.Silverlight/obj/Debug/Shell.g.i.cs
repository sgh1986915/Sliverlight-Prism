﻿#pragma checksum "D:\Anton\Sliverlight Prism\src\Procbel.Apps.Silverlight\Shell.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "426B4E2E43676C321B01563F72D71367"
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


namespace Procbel.Apps.Silverlight {
    
    
    public partial class Shell : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard InitialAnimation;
        
        internal System.Windows.VisualStateGroup PanelStates;
        
        internal System.Windows.VisualState HidePanel;
        
        internal System.Windows.VisualState ShowPanel;
        
        internal System.Windows.VisualStateGroup PanelMenuStates;
        
        internal System.Windows.VisualState HideMenuPanel;
        
        internal System.Windows.VisualState ShowMenuPanel;
        
        internal System.Windows.VisualStateGroup PanelNavigationStates;
        
        internal System.Windows.VisualState Appearance;
        
        internal System.Windows.VisualState EditAppearance;
        
        internal System.Windows.VisualState Info;
        
        internal System.Windows.VisualState Share;
        
        internal System.Windows.VisualState Download;
        
        internal System.Windows.Controls.Grid grid4;
        
        internal System.Windows.Controls.Grid grid3;
        
        internal System.Windows.Shapes.Path path;
        
        internal System.Windows.Controls.Border border1;
        
        internal System.Windows.Media.ScaleTransform LoadingMask1;
        
        internal System.Windows.Controls.Border border2;
        
        internal System.Windows.Media.ScaleTransform LoadingMask2;
        
        internal System.Windows.Controls.Border border4;
        
        internal System.Windows.Media.ScaleTransform LoadingMask3;
        
        internal System.Windows.Controls.Border border5;
        
        internal System.Windows.Media.ScaleTransform LoadingMask4;
        
        internal System.Windows.Controls.Grid grid2;
        
        internal System.Windows.Controls.StackPanel stackPanel1;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Border border;
        
        internal System.Windows.Controls.Grid Header;
        
        internal System.Windows.Controls.ContentControl SubMenuRegionPlaceholder;
        
        internal System.Windows.Controls.ContentControl ModuleMenuRegionPlaceholder;
        
        internal System.Windows.Controls.ContentControl HeaderRegionPlaceholder;
        
        internal System.Windows.Controls.TextBlock Title;
        
        internal System.Windows.Controls.StackPanel stackPanel2;
        
        internal System.Windows.Controls.TextBlock SelectedRange;
        
        internal RadToggleButton radToggleButtonAreas;
        
        internal System.Windows.Controls.Grid gridMenuPanel;
        
        internal System.Windows.Controls.ContentControl MainMenuRegionPlaceholder;
        
        internal System.Windows.Shapes.Rectangle BorderHeader;
        
        internal RadToggleButton radToggleButtonSettings;
        
        internal System.Windows.Controls.Grid gridPanel;
        
        internal System.Windows.Controls.StackPanel stackPanel;
        
        internal RadRadioButton AppearancePane;
        
        internal RadRadioButton InfoPane;
        
        internal RadRadioButton SharePane;
        
        internal RadRadioButton DownloadPane;
        
        internal System.Windows.Controls.Grid panelsGrid;
        
        internal System.Windows.Controls.StackPanel appearance;
        
        internal System.Windows.Controls.Grid appearance_edit;
        
        internal System.Windows.Controls.StackPanel info;
        
        internal System.Windows.Controls.Grid logo_Copy1;
        
        internal System.Windows.Controls.StackPanel share;
        
        internal System.Windows.Controls.StackPanel download;
        
        internal System.Windows.Controls.ContentControl ModuleMenus;
        
        internal System.Windows.Controls.ContentControl ContentRegionPlaceholder;
        
        internal RadBusyIndicator busyIndicator;
        
        internal System.Windows.Shapes.Rectangle BorderBottom;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Procbel.Apps.Silverlight;component/Shell.xaml", System.UriKind.Relative));
            this.InitialAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("InitialAnimation")));
            this.PanelStates = ((System.Windows.VisualStateGroup)(this.FindName("PanelStates")));
            this.HidePanel = ((System.Windows.VisualState)(this.FindName("HidePanel")));
            this.ShowPanel = ((System.Windows.VisualState)(this.FindName("ShowPanel")));
            this.PanelMenuStates = ((System.Windows.VisualStateGroup)(this.FindName("PanelMenuStates")));
            this.HideMenuPanel = ((System.Windows.VisualState)(this.FindName("HideMenuPanel")));
            this.ShowMenuPanel = ((System.Windows.VisualState)(this.FindName("ShowMenuPanel")));
            this.PanelNavigationStates = ((System.Windows.VisualStateGroup)(this.FindName("PanelNavigationStates")));
            this.Appearance = ((System.Windows.VisualState)(this.FindName("Appearance")));
            this.EditAppearance = ((System.Windows.VisualState)(this.FindName("EditAppearance")));
            this.Info = ((System.Windows.VisualState)(this.FindName("Info")));
            this.Share = ((System.Windows.VisualState)(this.FindName("Share")));
            this.Download = ((System.Windows.VisualState)(this.FindName("Download")));
            this.grid4 = ((System.Windows.Controls.Grid)(this.FindName("grid4")));
            this.grid3 = ((System.Windows.Controls.Grid)(this.FindName("grid3")));
            this.path = ((System.Windows.Shapes.Path)(this.FindName("path")));
            this.border1 = ((System.Windows.Controls.Border)(this.FindName("border1")));
            this.LoadingMask1 = ((System.Windows.Media.ScaleTransform)(this.FindName("LoadingMask1")));
            this.border2 = ((System.Windows.Controls.Border)(this.FindName("border2")));
            this.LoadingMask2 = ((System.Windows.Media.ScaleTransform)(this.FindName("LoadingMask2")));
            this.border4 = ((System.Windows.Controls.Border)(this.FindName("border4")));
            this.LoadingMask3 = ((System.Windows.Media.ScaleTransform)(this.FindName("LoadingMask3")));
            this.border5 = ((System.Windows.Controls.Border)(this.FindName("border5")));
            this.LoadingMask4 = ((System.Windows.Media.ScaleTransform)(this.FindName("LoadingMask4")));
            this.grid2 = ((System.Windows.Controls.Grid)(this.FindName("grid2")));
            this.stackPanel1 = ((System.Windows.Controls.StackPanel)(this.FindName("stackPanel1")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.border = ((System.Windows.Controls.Border)(this.FindName("border")));
            this.Header = ((System.Windows.Controls.Grid)(this.FindName("Header")));
            this.SubMenuRegionPlaceholder = ((System.Windows.Controls.ContentControl)(this.FindName("SubMenuRegionPlaceholder")));
            this.ModuleMenuRegionPlaceholder = ((System.Windows.Controls.ContentControl)(this.FindName("ModuleMenuRegionPlaceholder")));
            this.HeaderRegionPlaceholder = ((System.Windows.Controls.ContentControl)(this.FindName("HeaderRegionPlaceholder")));
            this.Title = ((System.Windows.Controls.TextBlock)(this.FindName("Title")));
            this.stackPanel2 = ((System.Windows.Controls.StackPanel)(this.FindName("stackPanel2")));
            this.SelectedRange = ((System.Windows.Controls.TextBlock)(this.FindName("SelectedRange")));
            this.radToggleButtonAreas = ((RadToggleButton)(this.FindName("radToggleButtonAreas")));
            this.gridMenuPanel = ((System.Windows.Controls.Grid)(this.FindName("gridMenuPanel")));
            this.MainMenuRegionPlaceholder = ((System.Windows.Controls.ContentControl)(this.FindName("MainMenuRegionPlaceholder")));
            this.BorderHeader = ((System.Windows.Shapes.Rectangle)(this.FindName("BorderHeader")));
            this.radToggleButtonSettings = ((RadToggleButton)(this.FindName("radToggleButtonSettings")));
            this.gridPanel = ((System.Windows.Controls.Grid)(this.FindName("gridPanel")));
            this.stackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("stackPanel")));
            this.AppearancePane = ((RadRadioButton)(this.FindName("AppearancePane")));
            this.InfoPane = ((RadRadioButton)(this.FindName("InfoPane")));
            this.SharePane = ((RadRadioButton)(this.FindName("SharePane")));
            this.DownloadPane = ((RadRadioButton)(this.FindName("DownloadPane")));
            this.panelsGrid = ((System.Windows.Controls.Grid)(this.FindName("panelsGrid")));
            this.appearance = ((System.Windows.Controls.StackPanel)(this.FindName("appearance")));
            this.appearance_edit = ((System.Windows.Controls.Grid)(this.FindName("appearance_edit")));
            this.info = ((System.Windows.Controls.StackPanel)(this.FindName("info")));
            this.logo_Copy1 = ((System.Windows.Controls.Grid)(this.FindName("logo_Copy1")));
            this.share = ((System.Windows.Controls.StackPanel)(this.FindName("share")));
            this.download = ((System.Windows.Controls.StackPanel)(this.FindName("download")));
            this.ModuleMenus = ((System.Windows.Controls.ContentControl)(this.FindName("ModuleMenus")));
            this.ContentRegionPlaceholder = ((System.Windows.Controls.ContentControl)(this.FindName("ContentRegionPlaceholder")));
            this.busyIndicator = ((RadBusyIndicator)(this.FindName("busyIndicator")));
            this.BorderBottom = ((System.Windows.Shapes.Rectangle)(this.FindName("BorderBottom")));
        }
    }
}

