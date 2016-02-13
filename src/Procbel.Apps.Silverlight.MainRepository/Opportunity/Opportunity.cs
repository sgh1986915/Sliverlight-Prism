using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Model.Main
{
    public partial class Opportunity
    {
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == "Price" || e.PropertyName == "Quantity" || e.PropertyName == "DiscountPercent" || e.PropertyName == "Product")
            {
                this.UpdateTotalPrice();
            }
        }

        public void RaiseProductChangedEvent()
        {
            this.RaisePropertyChanged("Product");
        }

        partial void OnCreated()
        {
            this.DiscountPercent = 0;
            this.Price = 0;
            this.Quantity = 1;
            this.DateCreated = DateTime.Today;
            this.EstimationCloseDate = DateTime.Today.AddDays(1);
            this.Priority = 0;
            this.Status = 0;
            this.Stage = 0;
            this.SuccessProbability = 0;
            this.TotalPrice = 0;
        }
     
            
        
        partial void OnPriorityChanged()
        {
            this.PriorityType = (PriorityType)(this.Priority ?? 0);
        }

        partial void OnStatusChanged()
        {
            this.StatusType = (OpportunityStatusType)(this.Status ?? 0);
        }

        partial void OnStageChanged()
        {
            this.StageType = (OpportunityStageType)(this.Stage ?? 0);
        }

        public void UpdateTotalPrice()
        {
            if (this.Product != null && this.Product.UnitPrice.HasValue && this.Quantity.HasValue && this.DiscountPercent.HasValue)
            //if (this.Price.HasValue && this.Quantity.HasValue && this.DiscountPercent.HasValue)
            {
                var valueNoDiscount = this.Product.UnitPrice.Value * this.Quantity.Value;
                var discount = valueNoDiscount * (this.DiscountPercent.Value / 100m);
                var valueDiscount = valueNoDiscount - discount;
                this.TotalPrice = valueDiscount;
            }
        }
    }
}
