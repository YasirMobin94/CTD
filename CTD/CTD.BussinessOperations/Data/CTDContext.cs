using CTD.BussinessOperations.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Data
{
    public class CTDContext : DbContext
    {
        public CTDContext(DbContextOptions<CTDContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserEmail>(e =>
            {
                e.ToTable("UserEmail");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd();
                e.Property(x => x.Email).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Website).HasMaxLength(200);
                e.Property(x => x.Message).IsRequired();
            });
        }
        public DbSet<UserEmail> UserEmails { set; get; }
    }
}
