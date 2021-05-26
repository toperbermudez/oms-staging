namespace OMS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerequiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
    }
}
