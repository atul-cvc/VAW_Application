namespace VAW_WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeddata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CvoOrgCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "CvoOrgCode");
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}
