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
    
    public partial class Setting
    {
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public string DefaultValue { get; set; }
        public string SettingType { get; set; }
        public string SettingDescription { get; set; }
        public Nullable<int> SiteId { get; set; }
    
        public virtual Site Site { get; set; }
    }
}