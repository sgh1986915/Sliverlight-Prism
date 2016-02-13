using System;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Model.CRM
{
    public partial class Activity 
    {
        partial void OnPriorityChanged()
        {
            this.PriorityType = (CRM.PriorityType)(this.Priority ?? 0);
        }

        partial void OnStatusChanged()
        {
            this.StatusType = (ActivityStatusType)(this.Status ?? 0);
        }

        partial void OnTypeChanged()
        {
            this.TypeAsEnum = (ActivityType)(this.Type ?? 0);
        }
    }
}
