using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procbel.Apps.Model.CRM
{
    public class ContactsMetadata
    {
        public IEnumerable<Contact> Contacts { get; set; }

        public int AllContacts
        {
            get
            {
                var result = this.Contacts.Count();
                return result;
            }
        }

        public int ImportantContacts
        {
            get
            {
                var result = this.Contacts.Where(c => c.IsImportantPerson.GetValueOrDefault()).Count();
                return result;
            }
        }

        public int ActiveContacts
        {
            get
            {
                var result = this.Contacts.Count(c =>
                {
                    var match = c.Opportunity != null && c.Opportunity.Count(o => o.Status == (int)OpportunityStatusType.Open) != 0;
                    return match;
                });
                return result;
            }
        }

    }
}
