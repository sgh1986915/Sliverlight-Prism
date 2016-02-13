using System.ServiceModel.DomainServices.Server;
using System.ComponentModel.DataAnnotations;

namespace Procbel.Apps.Model.CRM
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Company.CompanyMetadata))]
    public partial class Company
    {
        internal sealed class CompanyMetadata
        {
            public CompanyMetadata()
            {
            }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Company-image-association", "ImageID", "ImageID")]
            public Image Image { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Revenue { get; set; }
        }
    }
}
