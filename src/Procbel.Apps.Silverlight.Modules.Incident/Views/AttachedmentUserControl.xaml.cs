using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Incidencias.ViewModels;
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

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Views
{
    [ViewExport(RegionName = "IncidenciasMiscDetailsRegion", IsActiveByDefault = false)]
    public partial class AttachedmentUserControl : UserControl
    {
        public AttachedmentUserControl()
        {
            InitializeComponent();
        }

        [Import]
        public AttachedCommentViewModel ViewModel
        {
            get
            {
                return this.DataContext as AttachedCommentViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
