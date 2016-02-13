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
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure.Behavior
{
    public class RemoveUploadedItemsBehavior : TriggerAction<RadUpload>
    {
        protected override void Invoke(object parameter)
        {
            this.AssociatedObject.CancelUpload();
        }
    }
}
