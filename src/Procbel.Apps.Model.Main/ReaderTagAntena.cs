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
    
    public partial class ReaderTagAntena
    {
        public int Id { get; set; }
        public string AntenaArray { get; set; }
        public int ReaderTagId { get; set; }
    
        public virtual ReaderTag ReaderTag { get; set; }
    }
}