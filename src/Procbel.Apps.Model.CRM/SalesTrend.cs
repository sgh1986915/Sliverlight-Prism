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
    
    public partial class SalesTrend
    {
        public int SalesTrendID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> CompanyID { get; set; }
    
        public virtual Company Company { get; set; }
    }
}