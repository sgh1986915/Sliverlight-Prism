using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace Procbel.Apps.Model.CRM
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product
    {
        internal sealed class ProductMetadata
        {
            public ProductMetadata()
            {
            }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Product-image-association", "ImageID", "ImageID")]
            public Image Image { get; set; }
        }
    }
}
