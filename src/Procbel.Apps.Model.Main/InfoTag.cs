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
    
    public partial class InfoTag
    {
        public InfoTag()
        {
            this.isCompleted = false;
            this.isSync = false;
        }
    
        public int Id { get; set; }
        public string TagId { get; set; }
        public int LocationId { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime DateEnd { get; set; }
        public System.Data.Spatial.DbGeography SpaceRead { get; set; }
        public bool isCompleted { get; set; }
        public bool isSync { get; set; }
    
        public virtual Location Location { get; set; }
    }
}
