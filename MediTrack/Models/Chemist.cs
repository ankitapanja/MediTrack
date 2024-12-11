using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MediTrack.Models
{
    public class Chemist
    {
        public int ChemistID { get; set; }  
        public string ChemistName { get; set; }
        public int Phone { get; set; }
        public string Email {  get; set; }
        public string Summary { get; set; }
    }
}