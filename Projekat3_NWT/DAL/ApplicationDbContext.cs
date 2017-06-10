using Microsoft.AspNet.Identity.EntityFramework;
using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public DbSet<PropertyImage> PropertyImages { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}