using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Photo_Sharing_Website.Models
{
    public class Follow
    {
        public int FollowId { get; set; }

        [Required]
        [StringLength(256)]
        public string FollowerUserName { get; set; }

        [Required]
        [StringLength(256)]
        public string FollowingUserName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}