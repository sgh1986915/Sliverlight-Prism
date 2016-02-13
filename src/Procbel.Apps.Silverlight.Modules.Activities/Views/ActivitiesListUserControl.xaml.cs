using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Activities.Views
{
    [ViewExport(RegionName="ActivitiesListRegion")]
    public partial class ActivitiesListUserControl : UserControl
    {
        public ActivitiesListUserControl()
        {
            InitializeComponent();
            this.activitiesGrid.SelectionChanged += OnGridViewSelectionChanged;   
        }

        void OnGridViewSelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            var grid = sender as RadGridView;
            if (grid.SelectedItem != null)
            {
                grid.ScrollIntoView(grid.SelectedItem);
            }
        }
    }
}
