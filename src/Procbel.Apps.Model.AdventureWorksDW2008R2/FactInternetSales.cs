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
    
    public partial class FactInternetSales
    {
        public FactInternetSales()
        {
            this.DimSalesReason = new HashSet<DimSalesReason>();
        }
    
        public int ProductKey { get; set; }
        public int OrderDateKey { get; set; }
        public int DueDateKey { get; set; }
        public int ShipDateKey { get; set; }
        public int CustomerKey { get; set; }
        public int PromotionKey { get; set; }
        public int CurrencyKey { get; set; }
        public int SalesTerritoryKey { get; set; }
        public string SalesOrderNumber { get; set; }
        public byte SalesOrderLineNumber { get; set; }
        public byte RevisionNumber { get; set; }
        public short OrderQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExtendedAmount { get; set; }
        public double UnitPriceDiscountPct { get; set; }
        public double DiscountAmount { get; set; }
        public decimal ProductStandardCost { get; set; }
        public decimal TotalProductCost { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public string CustomerPONumber { get; set; }
    
        public virtual DimCurrency DimCurrency { get; set; }
        public virtual DimCustomer DimCustomer { get; set; }
        public virtual DimDate DimDate { get; set; }
        public virtual DimDate DimDate1 { get; set; }
        public virtual DimDate DimDate2 { get; set; }
        public virtual DimProduct DimProduct { get; set; }
        public virtual DimPromotion DimPromotion { get; set; }
        public virtual DimSalesTerritory DimSalesTerritory { get; set; }
        public virtual ICollection<DimSalesReason> DimSalesReason { get; set; }
    }
}
