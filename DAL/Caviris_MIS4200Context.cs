using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Caviris_MIS4200.Models;

namespace Caviris_MIS4200.DAL
{
    public class Caviris_MIS4200Context : DbContext 
    {
        public Caviris_MIS4200Context() : base ("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Caviris_MIS4200Context, Caviris_MIS4200.Migrations.MISContext.Configuration>("DefaultConnection"));

        }
        public DbSet<Renter> renter { get; set; }
        public DbSet<PropertyRenter> propertyRenter { get; set; }
        public DbSet<Property> property { get; set; }
        public DbSet<Owner> owner { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    
}