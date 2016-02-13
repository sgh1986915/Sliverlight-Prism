using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Infrastructure.Helpers
{
    /// <summary>
    /// A base class for RadScheduleView's dialog host that will be used in different modules. 
    /// Needed to be able to enable AncestorType Binding in styles without referring the dll owning the concrete implementation
    /// </summary>
    public class ScheduleViewDialogBase : ContentControl
    {

    }
}
