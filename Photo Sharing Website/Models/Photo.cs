using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Photo_Sharing_Website.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }

        [Required]
        [StringLength(500)]
        public string ImagePath { get; set; }

        [StringLength(500)]
        public string Caption { get; set; }

        public DateTime CreatedAt { get; set; }
        [StringLength(256)]
        public string UserName { get; set; }
    }
}