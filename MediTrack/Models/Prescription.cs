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
    
    public partial class Prescription
    {
        public int PrescriptionID { get; set; }
        public int AdviceID { get; set; }
        public int DrugID { get; set; }
        public string PrescriptionNotes { get; set; }
    
        public virtual Prescription Prescription1 { get; set; }
        public virtual Prescription Prescription2 { get; set; }
    }
}
