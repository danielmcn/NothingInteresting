namespace StJohnEPAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Duties", "DutyName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Duties", "DutyName", c => c.String());
        }
    }
}
