using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediTrack.Models
{
    public class Paitent
    {
        public int PaitentId { get; set; }
        public string paitentName { get; set; }

        public int Phone {  get; set; }
        public string Address{ get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Summary{ get; set; }
        public int Status { get; set; }
    }
}