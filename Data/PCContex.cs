

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCustomer.Data
{
    public class PCContex :IdentityDbContext<ApplicationUser>
    {
        public PCContex(DbContextOptions<PCContex> options) : base(options)
        {

        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasColumnType("decimal(18,2)");
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {


        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.firstname).HasMaxLength(100);
            builder.Property(u => u.lastName).HasMaxLength(100);
        }
    }
}

