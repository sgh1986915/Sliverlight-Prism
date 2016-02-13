using Procbel.Apps.Model.CRM.Dashboard;
using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Repository
{
    [Export]
    public class DashboardRepository : RepositoryBase
    {
        private bool isLoading = false;

        public void GetDashboardStats(Action<DashboardStats> callback)
        {
            if (isLoading)
            {
                return;
            }
            isLoading = true;
            this.Context.GetDashboardStats((operation) =>
            {
                isLoading = false;
                callback(operation.Value);
            }, null);
        }
    }
}
