using Microsoft.EntityFrameworkCore;
using SchoolApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class DatabaseContext : DbContext
    {
        public static OptionsBuild Options = new();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //DbSets
        public DbSet<Applicant> Applicants { get; set; }
        
        public DbSet<Application> Applications { get; set; }
        
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Applicant
            modelBuilder.Entity<Applicant>().ToTable("applicant");
            modelBuilder.Entity<Applicant>().HasKey(ap => ap.Id);
            modelBuilder.Entity<Applicant>().Property(ap => ap.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            modelBuilder.Entity<Applicant>().Property(ap => ap.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<Applicant>().Property(ap => ap.Surname).IsRequired().HasMaxLength(100).HasColumnName("surname");
            modelBuilder.Entity<Applicant>().Property(ap => ap.BirthDate).IsRequired().HasColumnName("birthdate");
            modelBuilder.Entity<Applicant>().Property(ap => ap.ContactEmail).IsRequired(false).HasMaxLength(250).HasColumnName("email");
            modelBuilder.Entity<Applicant>().Property(ap => ap.ContactNumber).IsRequired(false).HasMaxLength(25).HasColumnName("contactNumber");
            modelBuilder.Entity<Applicant>().Property(ap => ap.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creationDate");
            modelBuilder.Entity<Applicant>().Property(ap => ap.ModifiedDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("modifiedDate");
            
            modelBuilder.Entity<Applicant>()
                .HasMany<Application>(ap => ap.Applications)
                .WithOne(app => app.Applicant)
                .HasForeignKey(app => app.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict); //Can't delete an applicant info ever! but update it
            #endregion

            #region ApplicationStatus
            modelBuilder.Entity<ApplicationStatus>().ToTable("applicationStatus");
            //PK and Identity
            modelBuilder.Entity<ApplicationStatus>().HasKey(apps => apps.Id);
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //Columns
            modelBuilder.Entity<ApplicationStatus>().HasIndex(apps => apps.Name).IsUnique();
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creationDate");
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ModifiedDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("modifiedDate");

            //Relationships
            modelBuilder.Entity<ApplicationStatus>()
                .HasMany<Application>(apps => apps.Applications)
                .WithOne(app => app.ApplicationStatus)
                .HasForeignKey(app => app.ApplicationStatusId)
                .OnDelete(DeleteBehavior.Restrict); //Cant delete an applicationStatus, but edit
            #endregion

            #region Grade
            modelBuilder.Entity<Grade>().ToTable("grade");
            //PK and Identity
            modelBuilder.Entity<Grade>().HasKey(g => g.Id);
            modelBuilder.Entity<Grade>().Property(g => g.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //Columns
            modelBuilder.Entity<Grade>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<Grade>().Property(g => g.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<Grade>().HasIndex(g => g.Number).IsUnique();
            modelBuilder.Entity<Grade>().Property(g => g.Number).IsRequired().HasColumnName("gradeNumber");
            modelBuilder.Entity<Grade>().Property(g => g.Capacity).IsRequired().HasColumnName("capacity");
            modelBuilder.Entity<Grade>().Property(g => g.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creationDate");
            modelBuilder.Entity<Grade>().Property(g => g.ModifiedDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("modifiedDate");

            //Relationships
            modelBuilder.Entity<Grade>()
                .HasMany<Application>(g => g.Applications)
                .WithOne(app => app.Grade)
                .HasForeignKey(app => app.GradeId)
                .OnDelete(DeleteBehavior.Restrict); //Can't delete an Grade info ever! but update it
            #endregion

            #region Application
            modelBuilder.Entity<Application>().ToTable("application");
            //PK and Identity
            modelBuilder.Entity<Application>().HasKey(app => app.Id);
            modelBuilder.Entity<Application>().Property(app => app.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //Columns
            modelBuilder.Entity<Application>().Property(app => app.ApplicantId).IsRequired().HasColumnName("applicantId");
            modelBuilder.Entity<Application>().Property(app => app.ApplicationStatusId).IsRequired().HasColumnName("applicationStatusId");
            modelBuilder.Entity<Application>().Property(app => app.GradeId).IsRequired().HasColumnName("gradeId");
            modelBuilder.Entity<Application>().Property(app => app.SchoolYear).IsRequired().HasColumnName("schoolYear");
            modelBuilder.Entity<Application>().Property(app => app.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creationDate");
            modelBuilder.Entity<Application>().Property(app => app.ModifiedDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("modifiedDate");

            //Relationships
            modelBuilder.Entity<Application>()
                .HasOne<Applicant>(app => app.Applicant)
                .WithMany(ap => ap.Applications)
                .HasForeignKey(app => app.ApplicantId)
                .OnDelete(DeleteBehavior.NoAction); // can delete application

            modelBuilder.Entity<Application>()
                .HasOne<Grade>(app => app.Grade)
                .WithMany(g => g.Applications)
                .HasForeignKey(app => app.GradeId)
                .OnDelete(DeleteBehavior.NoAction); // can delete application

            modelBuilder.Entity<Application>()
                .HasOne<ApplicationStatus>(app => app.ApplicationStatus)
                .WithMany(apps => apps.Applications)
                .HasForeignKey(app => app.ApplicationStatusId)
                .OnDelete(DeleteBehavior.NoAction); // can delete application
            #endregion
        }
    }
}
