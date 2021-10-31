using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KDBS.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<RecruiterModel> Recruiters { get; set; }
        public DbSet<JobModel> Jobs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Recruiter
            modelBuilder.Entity<RecruiterModel>().HasKey(r => r.RecruiterId);
            modelBuilder.Entity<RecruiterModel>().Property(r => r.RecruiterId).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecruiterModel>()
                .HasOne(c => c.User)
                .WithOne(u => u.Recruiter)
                .HasForeignKey<RecruiterModel>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Job
            modelBuilder.Entity<JobModel>().HasKey(r => r.JobId);
            modelBuilder.Entity<JobModel>().Property(r => r.JobId).ValueGeneratedOnAdd();
            modelBuilder.Entity<JobModel>()
                .HasOne(c => c.Recruiter)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.RecruiterId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
