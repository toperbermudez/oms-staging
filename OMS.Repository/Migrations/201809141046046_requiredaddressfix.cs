namespace OMS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredaddressfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "AddressLineOne", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLineTwo", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "PostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Addresses", "AddressLineTwo", c => c.String(maxLength: 25));
            AlterColumn("dbo.Addresses", "AddressLineOne", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
