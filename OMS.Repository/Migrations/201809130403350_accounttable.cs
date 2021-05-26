namespace OMS.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class accounttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 25),
                        PasswordHash = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Salt = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "UserID", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserID" });
            DropTable("dbo.Accounts");
        }
    }
}
