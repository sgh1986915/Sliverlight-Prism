//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Procbel.Apps.Model.AdventureWorksDW2008R2
{
    using System;
    using System.Collections.Generic;
    
    public partial class FactAdditionalInternationalProductDescription
    {
        public int ProductKey { get; set; }
        public string CultureName { get; set; }
        public string ProductDescription { get; set; }
    
        public virtual DimProduct DimProduct { get; set; }
    }
}