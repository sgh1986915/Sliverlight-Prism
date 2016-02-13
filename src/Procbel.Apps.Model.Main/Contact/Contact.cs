using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using System.Threading.Tasks;

namespace Procbel.Apps.Model.Main
{
    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Contact.ContactMetadata))]
    public partial class Contact
    {
        internal sealed class ContactMetadata
        {
            public ContactMetadata()
            {
            }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Contacts-company-association", "CompanyID", "CompanyID")]
            public Company Company { get; set; }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Contacts-image-association", "ImageID", "Id")]
            public Image Image { get; set; }

            [Required]
            public int CompanyID { get; set; }

            [Required]
            public string Name { get; set; }
        }
    }
}
