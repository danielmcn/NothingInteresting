namespace StJohnEPAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        Address = c.String(),
                        TelephoneNumber = c.String(),
                        Skills = c.String(),
                        Rank = c.String(),
                        OperationalRoles = c.String(),
                        NonOperationalRoles = c.String(),
                        EmergencyContact_MemberID = c.Int(),
                        Duty_DutyID = c.Int(),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Members", t => t.EmergencyContact_MemberID)
                .ForeignKey("dbo.Duties", t => t.Duty_DutyID)
                .Index(t => t.EmergencyContact_MemberID)
                .Index(t => t.Duty_DutyID);
            
            CreateTable(
                "dbo.Duties",
                c => new
                    {
                        DutyID = c.Int(nullable: false, identity: true),
                        DutyName = c.String(),
                        DutyDate = c.DateTime(nullable: false),
                        DutyStartTime = c.DateTime(nullable: false),
                        DutyEndTime = c.DateTime(nullable: false),
                        DutyLocation = c.String(),
                        DutyDescription = c.String(),
                        DutyAdditionalNotes = c.String(),
                        DutyOrganiser = c.String(),
                        DutyOrganiserPhoneNumber = c.String(),
                        DutyOrganiserEmailAddress = c.String(),
                        DutyCreator_MemberID = c.Int(),
                    })
                .PrimaryKey(t => t.DutyID)
                .ForeignKey("dbo.Members", t => t.DutyCreator_MemberID)
                .Index(t => t.DutyCreator_MemberID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Duties", new[] { "DutyCreator_MemberID" });
            DropIndex("dbo.Members", new[] { "Duty_DutyID" });
            DropIndex("dbo.Members", new[] { "EmergencyContact_MemberID" });
            DropForeignKey("dbo.Duties", "DutyCreator_MemberID", "dbo.Members");
            DropForeignKey("dbo.Members", "Duty_DutyID", "dbo.Duties");
            DropForeignKey("dbo.Members", "EmergencyContact_MemberID", "dbo.Members");
            DropTable("dbo.Duties");
            DropTable("dbo.Members");
        }
    }
}
