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
    
    public partial class DimProductSubcategory
    {
        public DimProductSubcategory()
        {
            this.DimProduct = new HashSet<DimProduct>();
        }
    
        public int ProductSubcategoryKey { get; set; }
        public Nullable<int> ProductSubcategoryAlternateKey { get; set; }
        public string EnglishProductSubcategoryName { get; set; }
        public string SpanishProductSubcategoryName { get; set; }
        public string FrenchProductSubcategoryName { get; set; }
        public Nullable<int> ProductCategoryKey { get; set; }
    
        public virtual ICollection<DimProduct> DimProduct { get; set; }
        public virtual DimProductCategory DimProductCategory { get; set; }
    }
}
