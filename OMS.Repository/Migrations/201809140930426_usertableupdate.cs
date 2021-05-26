namespace OMS.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class usertableupdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Address_ID" });
            RenameColumn(table: "dbo.Users", name: "Address_ID", newName: "AddressId");
            RenameColumn(table: "dbo.Users", name: "Role_ID", newName: "RoleId");
            RenameIndex(table: "dbo.Users", name: "IX_Role_ID", newName: "IX_RoleId");
            AlterColumn("dbo.Users", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "AddressId" });
            AlterColumn("dbo.Users", "AddressId", c => c.Int());
            RenameIndex(table: "dbo.Users", name: "IX_RoleId", newName: "IX_Role_ID");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_ID");
            RenameColumn(table: "dbo.Users", name: "AddressId", newName: "Address_ID");
            CreateIndex("dbo.Users", "Address_ID");
        }
    }
}
