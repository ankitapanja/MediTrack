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
    
    public partial class DrugTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugTable()
        {
            this.PODrugLines = new HashSet<PODrugLine>();
        }
    
        public int DrugID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public string Dosage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PODrugLine> PODrugLines { get; set; }
    }
}