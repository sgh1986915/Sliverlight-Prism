using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ServiceModel.DomainServices.Server;
using System.ComponentModel.DataAnnotations;

namespace Procbel.Apps.Model.Main
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
            [System.ComponentModel.DataAnnotations.Association("Company-image-association", "ImageId", "Id")]
            public Image Image { get; set; }

            [Required(ErrorMessage="Name field cannot be empty")]
            public string Name { get; set; }

            [Required(ErrorMessage="Revenue field cannot be empty")]
            public string Revenue { get; set; }
        }
    }
}
