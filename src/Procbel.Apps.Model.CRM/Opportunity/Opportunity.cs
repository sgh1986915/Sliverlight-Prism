using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace Procbel.Apps.Model.CRM
{
    public partial class Opportunity
    {
        public OpportunityStageType StageType
        {
            get
            {
                if (this.Stage.HasValue)
                {
                    return (OpportunityStageType)this.Stage.Value;
                }
                return OpportunityStageType.Cold;
            }
            set
            {
                //intentionally blank
            }
        }

       // [FieldAlias("priority")]
         [Column("priority")]
        public PriorityType PriorityType
        {
            get
            {
                if (this.Priority.HasValue)
                {
                    return (PriorityType)this.Priority.Value;
                }
                return PriorityType.Low;
            }
            set
            {
                //intentionally blank
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return CalculateTotalPrice();
            }

            set
            {
                //intentionally blank
            }
        }

        private decimal CalculateTotalPrice()
        {
            if (this.Product != null && this.Product.UnitPrice.HasValue && this.Quantity.HasValue && this.DiscountPercent.HasValue)
            //if (this.Price.HasValue && this.Quantity.HasValue && this.DiscountPercent.HasValue)
            {
                var valueNoDiscount = this.Product.UnitPrice.Value * this.Quantity.Value;
                var discount = valueNoDiscount * (this.DiscountPercent.Value / 100m);
                var valueDiscount = valueNoDiscount - discount;
                return valueDiscount;
            }
            return 0;
        }

        public OpportunityStatusType StatusType
        {
            get
            {
                if (this.Status.HasValue)
                {
                    return (OpportunityStatusType)this.Status.Value;
                }
                return OpportunityStatusType.Open;
            }
            set
            {
                //intentionally blank
            }
        }

        public bool IsOverdue
        {
            get
            {
                return this.EstimationCloseDate <= DateTime.Now;
            }
            set
            {
                //intentionally blank
            }
        }

        ///// <summary>
        ///// A valid creation date is before DateTime.Now
        ///// </summary>
        //public bool IsCreationDateValid
        //{
        //    get
        //    {
        //        return this.DateCreated <= DateTime.Now;
        //    }
        //    set
        //    {
        //        //intentionally blank
        //    }
        //}
    }

    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Opportunity.OpportunityMetadata))]
    public partial class Opportunity
    {
        internal sealed class OpportunityMetadata
        {
            public OpportunityMetadata()
            {
            }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Opportunity-contact-association", "ContactID", "ContactID")]
            public Company Contact { get; set; }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Opportunity-product-association", "ProductID", "ProductID")]
            public Product Product { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public int ProductID { get; set; }

            [Required]
            public int ContactID { get; set; }
        }
    }
}
