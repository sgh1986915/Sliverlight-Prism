using System;
using System.Collections.Generic;
using System.Linq;
using Procbel.Apps.Model.Main;
using System.ComponentModel.Composition;

namespace Procbel.Apps.Silverlight.MainRepository
{
    [Export]
    public class ContactRepository:RepositoryBase
    {
        private bool isLoading = false;

        public void GetContactsMetadata(Company company, Action<ContactsMetadata> callback)
        {
            if (isLoading)
            {
                return;
            }
            isLoading = true;
            this.Context.GetContactsMetadata(company.CompanyID, (operation) =>
            {
                isLoading = false;
                callback(operation.Value);
            }, null);
        }

        public void GetContacts(Action<IEnumerable<Contact>> callback)
        {
            this.LoadQuery<Contact>(this.Context.GetContactQuery(), callback);
        }

        public void GetContactsByCompany(Company company, Action<IEnumerable<Contact>> callback)
        {
            if (company == null)
            {
                callback(Enumerable.Empty<Contact>());
                return;
            }

            var companyID = company.CompanyID;
            this.LoadQuery<Contact>(this.Context.GetContactsByCompanyIDQuery(companyID), callback);
        }
    }
}
