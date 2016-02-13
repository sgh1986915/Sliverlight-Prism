using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.BulletGraph;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure.Behavior
{
    public class ValueBehavior : Behavior<QualitativeRange>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += (s, e) =>
                {
                    if (this.AssociatedObject.Value > 100)
                    {
                        SolidColorBrush redBrush = new SolidColorBrush();
                        redBrush.Color = Colors.Red;
                        this.AssociatedObject.Brush = redBrush;
                    }
                };
        }
    }
}
