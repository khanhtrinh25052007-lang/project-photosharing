namespace Photo_Sharing_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowAndProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowId = c.Int(nullable: false, identity: true),
                        FollowerUserName = c.String(nullable: false, maxLength: 256),
                        FollowingUserName = c.String(nullable: false, maxLength: 256),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FollowId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 256),
                        DisplayName = c.String(maxLength: 100),
                        Bio = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Follows");
        }
    }
}
