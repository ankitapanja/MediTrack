using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediTrack.Models
{
    public class UserVeiwModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public int Password { get; set; }
    }

    public class CurrentUserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public int Password { get; set; }
        public Nullable<int>  ReferenceToID { get; set; }

    }
}