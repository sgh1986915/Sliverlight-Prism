using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Companies.Infrastructure;
using Procbel.Apps.Silverlight.Modules.Companies.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    [ViewExport(RegionName = CompanyViewRegionNames.CompanyMiscDetails, IsActiveByDefault = false)]
    public partial class CompanyContactsUserControl : UserControl
    {
        public CompanyContactsUserControl()
        {
            InitializeComponent();
        }

        [ImportingConstructor]
        public CompanyContactsUserControl(CompanyContactsViewModel viewModel)
            : this()
        {
            this.ViewModel = viewModel;
        }

        public CompanyContactsViewModel ViewModel
        {
            get
            {
                return this.DataContext as CompanyContactsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        //private void RadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    if (treeView.SelectedContainer != null)
        //    {
        //        treeView.SelectedContainer.IsInEditMode = true;
        //    }
        //}
    }
}
