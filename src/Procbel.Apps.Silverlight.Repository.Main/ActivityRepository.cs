using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Procbel.Apps.Model.Main;

namespace Procbel.Apps.Silverlight.Repository.Main
{
    [Export]
    public class ActivityRepository : RepositoryBase
    {
        public void GetActivities(Action<IEnumerable<Activity>> callback)
        {
            this.LoadQuery<Activity>(this.Context.GetActivityQuery(), callback);
        }

        public void GetActivitiesByCompany(Company company, Action<IEnumerable<Activity>> callback)
        {
            if (company == null)
            {
                callback(Enumerable.Empty<Activity>());
                return;
            }

            var companyID = company.CompanyID;
            this.LoadQuery<Activity>(this.Context.GetActivitiesByCompanyIDQuery(companyID), callback);
        }

        public void GetActivitiesByContact(Contact contact, Action<IEnumerable<Activity>> callback)
        {
            if (contact == null)
            {
                callback(Enumerable.Empty<Activity>());
                return;
            }

            var contactID = contact.ContactID;
            this.LoadQuery<Activity>(this.Context.GetActivitiesByContactIDQuery(contactID), callback);
        }

        public void GetOpenActivitiesByCompany(Company company, Action<IEnumerable<Activity>> callback)
        {
            if (company == null)
            {
                callback(Enumerable.Empty<Activity>());
                return;
            }

            var companyID = company.CompanyID;
            this.LoadQuery<Activity>(this.Context.GetCompanyOverviewActivitiesQuery(companyID), callback);
        }

        //public void GetSalesTrendDataByCompany(Company company, Action<IEnumerable<SalesTrend>> callback)
        //{
        //    if (company == null)
        //    {
        //        callback(Enumerable.Empty<SalesTrend>());
        //        return;
        //    }

        //    var companyID = company.CompanyID;
        //    this.LoadQuery<SalesTrend>(this.Context.GetTrendsByCompanyIDQuery(companyID), callback);
        //}
    }
}
