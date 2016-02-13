using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Calidad.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Calidad.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class CalidadView : UserControl
    {
        public CalidadView()
        {
            InitializeComponent();
        }

        [Import]
        public CalidadViewModel ViewModel
        {
            get
            {
                return this.DataContext as CalidadViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
