using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
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

namespace Procbel.Apps.Silverlight.Modules.Contacts.Helpers
{
    public class SelectedContactChangedEvent : CompositePresentationEvent<Contact>
    {
    }
}
