//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Procbel.Apps.Model.Main
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public Contact()
        {
            this.Opportunity = new HashSet<Opportunity>();
        }
    
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<bool> IsEmployee { get; set; }
        public string Division { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public string Blog { get; set; }
        public Nullable<bool> IsImportantPerson { get; set; }
        public Nullable<int> ImageID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsMale { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Opportunity> Opportunity { get; set; }
    }
}
