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
    public class OpportunityRepository : RepositoryBase
    {
        public void GetActivitiesByOpportunity(Opportunity selectedOpportunity, Action<IEnumerable<Activity>> callback)
        {
            this.LoadQuery<Activity>(this.Context.GetActivitiesByOpportunityIDQuery(selectedOpportunity.OpportunityID), callback);
        }

        public void GetOpportunities(Action<IEnumerable<Opportunity>> callback)
        {
            this.LoadQuery<Opportunity>(this.Context.GetOpportunityQuery(), callback);
        }

        public void GetOpportunitiesByCompany(Company company, Action<IEnumerable<Opportunity>> callback)
        {
            this.GetOpportunitiesByCompanyID(company.CompanyID, callback);
        }

        public void GetOpportunitiesByCompanyID(int companyID, Action<IEnumerable<Opportunity>> callback)
        {
            this.LoadQuery<Opportunity>(this.Context.GetOpportunitiesByCompanyIDQuery(companyID), callback);
        }

        public void GetOpportunitiesByContact(Contact contact, Action<IEnumerable<Opportunity>> callback)
        {
            this.GetOpportunitiesByContactID(contact.ContactID, callback);
        }

        public void GetOpportunitiesByContactID(int contactID, Action<IEnumerable<Opportunity>> callback)
        {
            this.LoadQuery<Opportunity>(this.Context.GetOpportunitiesByContactIDQuery(contactID), callback);
        }

        public void GetOpenOpportunitiesByCompany(Company company, Action<IEnumerable<Opportunity>> callback)
        {
            if (company == null)
            {
                callback(Enumerable.Empty<Opportunity>());
                return;
            }

            var companyID = company.CompanyID;
            this.LoadQuery<Opportunity>(this.Context.GetCompanyOverviewOpportunitiesQuery(companyID), callback);
        }

    }
}
