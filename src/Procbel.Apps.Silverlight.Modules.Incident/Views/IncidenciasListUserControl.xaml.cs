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
using Telerik.Windows.Controls.BulletGraph;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Views
{
    [ViewExport(RegionName = "IncidenciasListRegion")]
    public partial class IncidenciasListUserControl : UserControl
    {
        public IncidenciasListUserControl()
        {
            InitializeComponent();

            this.incidenciasGrid.SelectionChanged += OnGridViewSelectionChanged;
        }

        void OnGridViewSelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            var grid = sender as RadGridView;
            if (grid.SelectedItem != null)
            {
                grid.ScrollIntoView(grid.SelectedItem);
            }
        }

        //private void QualitativeRange_Loaded(object sender, RoutedEventArgs e)
        //{
        //    QualitativeRange element = sender as QualitativeRange;
        //    if (element.Value > 100)
        //    {
        //        SolidColorBrush redBrush = new SolidColorBrush();
        //        redBrush.Color = Colors.Red;
        //        element.Brush = redBrush;
        //    }
        //}
    }
}
