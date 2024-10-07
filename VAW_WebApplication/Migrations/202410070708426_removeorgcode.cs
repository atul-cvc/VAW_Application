namespace VAW_WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeorgcode : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "OrgCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "OrgCode", c => c.String());
        }
    }
}
