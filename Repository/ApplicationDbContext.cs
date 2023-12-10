using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=Vezeeta;Integrated Security=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().Property(u => u.image).HasDefaultValue("Unknown_person.jpg");
            modelBuilder.Entity<Doctor>().Property(u => u.image).HasDefaultValue("Unknown_person.jpg");
            modelBuilder.Entity<Patient>().Property(u => u.image).HasDefaultValue("Unknown_person.jpg");
            modelBuilder.Entity<Appointment>().HasOne(p => p.patient).WithMany(a => a.bookings).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Discount>().HasOne(p => p.doctorCoupon).WithMany(a => a.discounts).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            //modelBuilder.Entity<User>().ToTable("Users");
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<WorkingDateAndTime> WorkingHours { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
