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
    
    public partial class DimTime
    {
        public short Id { get; set; }
        public Nullable<byte> hour_of_day_24 { get; set; }
        public Nullable<byte> hour_of_day_12 { get; set; }
        public string am_pm { get; set; }
        public Nullable<byte> minute_of_hour { get; set; }
        public Nullable<byte> half_hour { get; set; }
        public Nullable<byte> half_hour_of_day { get; set; }
        public Nullable<byte> quarter_hour { get; set; }
        public Nullable<byte> quarter_hour_of_day { get; set; }
        public string string_representation_24 { get; set; }
        public string string_representation_12 { get; set; }
    }
}