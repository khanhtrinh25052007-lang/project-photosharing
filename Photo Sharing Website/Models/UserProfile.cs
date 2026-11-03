using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Photo_Sharing_Website.Models
{
    public class UserProfile
    {
        [Key]
        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }
    }
}