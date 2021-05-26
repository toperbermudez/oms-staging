namespace OMS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lengthupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
