namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Email");
        }
    }
}
