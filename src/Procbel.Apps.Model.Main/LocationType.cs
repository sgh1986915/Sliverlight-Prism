//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Procbel.Apps.Model.Main
{
    using System;
    using System.Collections.Generic;
    
    public partial class LocationType
    {
        public LocationType()
        {
            this.Locations = new HashSet<Location>();
        }
    
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Location> Locations { get; set; }
        public virtual Site Site { get; set; }
    }
}
