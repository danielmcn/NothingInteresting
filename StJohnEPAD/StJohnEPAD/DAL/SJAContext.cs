using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StJohnEPAD.Models;


namespace StJohnEPAD.DAL
{
    public class SJAContext : DbContext
    {
        public SJAContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Duty> Duties { get; set; }
    }
}
