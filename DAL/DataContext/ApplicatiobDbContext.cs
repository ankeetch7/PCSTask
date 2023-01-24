using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class ApplicatiobDbContext : DbContext
    {
        public ApplicatiobDbContext(DbContextOptions<ApplicatiobDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<QualificationList> QualificationLists { get; set; }
        public DbSet<EMP_Qualification> EMP_Qualification { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>(employee =>
            {
                employee.HasKey(e => e.Employee_Id);

                employee.Property(e => e.Employee_Name)
                        .HasMaxLength(255)
                        .IsRequired();

                employee.Property(e => e.Salary)
                        .HasColumnType("decimal(18,2)");

                employee.Property(e => e.Gender)
                        .IsRequired();

                employee.Property(e => e.DOB)
                        .IsRequired();

                employee.Property(e => e.Entry_By)
                        .IsRequired();

                employee.Property(e => e.Entry_Date)
                        .IsRequired();

            });

            builder.Entity<QualificationList>(qualification =>
            {
                qualification.HasKey(q => q.Q_Id);

                qualification.Property(q => q.Q_Name)
                            .HasMaxLength(255)
                            .IsRequired();
            });

            builder.Entity<EMP_Qualification>(empQualification =>
            {
                empQualification.HasKey(eq => new { eq.Employee_Id, eq.Q_Id });

                empQualification.Property(eq => eq.Marks)
                                .HasColumnType("decimal(18,2)")
                                .IsRequired();

                empQualification.HasOne(eq => eq.Employee)
                                .WithMany(e => e.EMP_Qualifications)
                                .HasForeignKey(eq => eq.Employee_Id)
                                .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

                empQualification.HasOne(eq => eq.QualificationList)
                                 .WithMany(q => q.EMP_Qualifications)
                                 .HasForeignKey(eq => eq.Q_Id)
                                 .IsRequired()
                                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
