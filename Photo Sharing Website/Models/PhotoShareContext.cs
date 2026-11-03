using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Photo_Sharing_Website.Models
{
    public class PhotoShareContext : DbContext
    {
        public PhotoShareContext()
            : base("name=PhotoShareContext")
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Follow> Follows { get; set; }
    }
}