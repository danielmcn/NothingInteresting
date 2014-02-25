namespace StJohnEPAD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StJohnEPAD.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<StJohnEPAD.DAL.SJAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StJohnEPAD.DAL.SJAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var members = new List<Member>
            {
                new Member
                {
                    //MemberID
                    Name = "Tes Taccount",
                    EmailAddress = "taccount@sja.dummy",
                    Address = "123 Fake Street, Belfast",
                    TelephoneNumber = "078123456",
                    //EmergencyContact
                    Skills = "Joe's skills",
                    Rank = "Joe's rank",
                    OperationalRoles = "Joe's operational roles",
                    NonOperationalRoles = "Joe's non-operational roles",
                },

            };
            context.Members.Add(members.First()); //TODO: Change to addorupdate
            context.SaveChanges();

            var duties = new List<Duty>
            {
                new Duty
                {
                    DutyName = "Duty 1",
                    DutyDate = DateTime.Now,
                    DutyStartTime = DateTime.Now,
                    DutyEndTime = DateTime.Now,
                    
                    DutyLocation = "Duty 1 location",
                    DutyDescription = "Duty 1 description",
                    DutyAdditionalNotes = "Duty 1 additonal notes",

                    DutyCreator = context.Members.First(),

                    //Create a list of members, add a member, and assign them to this duty
                    DutyMembers = new List<Member>{ context.Members.First() },

                    DutyOrganiser = "Dutyone Organiser",
                    DutyOrganiserPhoneNumber = "Dutyoneorg Phone",
                    DutyOrganiserEmailAddress = "Dutyoneorg Email",
                },
            };
            context.Duties.Add(duties.First()); //TODO: Change to addorupdate
            context.SaveChanges();
        }
    }
}
