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
    
    public partial class Code
    {
        public Code()
        {
            this.Code1 = new HashSet<Code>();
        }
    
        public int CodeID { get; set; }
        public string CodeType { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public string AssocText { get; set; }
        public Nullable<int> AssocValue { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> ParentID { get; set; }
    
        public virtual ICollection<Code> Code1 { get; set; }
        public virtual Code Code2 { get; set; }
    }
}