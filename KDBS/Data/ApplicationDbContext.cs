using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KDBS.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<JobModel> Jobs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Company
            modelBuilder.Entity<CompanyModel>().HasKey(r => r.CompanyId);
            modelBuilder.Entity<CompanyModel>().Property(r => r.CompanyId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CompanyModel>()
                .HasOne(c => c.User)
                .WithOne(u => u.Company)
                .HasForeignKey<CompanyModel>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Job
            modelBuilder.Entity<JobModel>().HasKey(r => r.JobId);
            modelBuilder.Entity<JobModel>().Property(r => r.JobId).ValueGeneratedOnAdd();
            modelBuilder.Entity<JobModel>()
                .HasOne(c => c.Company)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
