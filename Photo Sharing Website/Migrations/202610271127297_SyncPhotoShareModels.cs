namespace Photo_Sharing_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncPhotoShareModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "UserName", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "UserName");
        }
    }
}
