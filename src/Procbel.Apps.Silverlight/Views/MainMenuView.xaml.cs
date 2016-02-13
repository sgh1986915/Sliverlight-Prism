using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
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

namespace Procbel.Apps.Silverlight.Views
{
    [ViewExport(RegionName = "MainMenuRegion")]
    public partial class MainMenuView : UserControl
    {
        [Import]
        [CLSCompliant(false)]
        public IApplicationViewModel ApplicationViewModel
        {
            private get
            {
                return this.DataContext as IApplicationViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }

        public MainMenuView()
        {
            InitializeComponent();
        }
    }
}
