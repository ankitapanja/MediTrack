//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediTrack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PODrugLine
    {
        public int PODrugLineID { get; set; }
        public int POID { get; set; }
        public int DrugID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public decimal Rate { get; set; }
    
        public virtual DrugTable DrugTable { get; set; }
        public virtual POHeader POHeader { get; set; }
    }
}