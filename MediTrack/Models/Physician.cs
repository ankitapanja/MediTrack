using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediTrack.Models
{
    public class Physician
    {
        public int PhysicianID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }


        public string Experience { get; set; }

        public string Specialization {  get; set; }

        public string Summary { get; set; }
    }
}