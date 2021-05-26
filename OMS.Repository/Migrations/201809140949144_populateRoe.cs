namespace OMS.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateRoe : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO roles(Name,Description,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate) " +
                "VALUES('Systems Admin','Systems Administrator','admin',getutcdate(),'admin',getutcdate())");
        }
        
        public override void Down()
        {
        }
    }
}
