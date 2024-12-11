using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediTrack.Models
{
   
    public partial class supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supplier()
        {
            this.drugRequests = new HashSet<DrugRequest>();
            this.PurchaseOrderHeaders = new HashSet<POHeader>();
        }

        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugRequest> drugRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POHeader> PurchaseOrderHeaders { get; set; }
    }
}