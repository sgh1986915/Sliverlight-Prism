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
    
    public partial class DimPromotion
    {
        public DimPromotion()
        {
            this.FactInternetSales = new HashSet<FactInternetSales>();
            this.FactResellerSales = new HashSet<FactResellerSales>();
        }
    
        public int PromotionKey { get; set; }
        public Nullable<int> PromotionAlternateKey { get; set; }
        public string EnglishPromotionName { get; set; }
        public string SpanishPromotionName { get; set; }
        public string FrenchPromotionName { get; set; }
        public Nullable<double> DiscountPct { get; set; }
        public string EnglishPromotionType { get; set; }
        public string SpanishPromotionType { get; set; }
        public string FrenchPromotionType { get; set; }
        public string EnglishPromotionCategory { get; set; }
        public string SpanishPromotionCategory { get; set; }
        public string FrenchPromotionCategory { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> MinQty { get; set; }
        public Nullable<int> MaxQty { get; set; }
    
        public virtual ICollection<FactInternetSales> FactInternetSales { get; set; }
        public virtual ICollection<FactResellerSales> FactResellerSales { get; set; }
    }
}
