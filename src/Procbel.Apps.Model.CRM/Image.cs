//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Procbel.Apps.Model.CRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public Image()
        {
            this.Company = new HashSet<Company>();
            this.Contact = new HashSet<Contact>();
            this.Employee = new HashSet<Employee>();
            this.Product = new HashSet<Product>();
        }
    
        public int ImageID { get; set; }
        public string ImagePath { get; set; }
    
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
