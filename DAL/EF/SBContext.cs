using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.EF
{
    public class SBContext : DbContext
    {
        static SBContext()
        {
            Database.SetInitializer<SBContext>(new SmartBookingDbInitializer());
        }
        public SBContext(string connectionString)
            : base(connectionString)
        { }
        public SBContext() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<WorkingBreak> WorkingBreaks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Time_zone> Time_zones { get; set; }
        public DbSet<CalendarSetting> CalendarSettings { get; set; }
        public DbSet<CustomerNotification> CustomerNotifications { get; set; }
        public DbSet<TeamNotification> TeamNotifications { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Service & Slot entity
            //modelBuilder.Entity<Service>()
            //            .HasOptional(ser => ser.Slot) // Mark Slot property optional in Service entity
            //            .WithRequired(sl => sl.Service); // mark Service property as required in Slot entity. Cannot save Slot without Service
            modelBuilder.Entity<Slot>()
                    .HasRequired(m => m.Employee)
                    .WithMany(t => t.SlotsOwners)
                    .HasForeignKey(m => m.EmployeeId)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Slot>()
                    .HasRequired(m => m.Responsible)
                    .WithMany(t => t.Responsibles)
                    .HasForeignKey(m => m.ResponsibleId)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Slot>()
                    .HasRequired<Service>(m => m.Service)
                    .WithMany(t => t.Slots)
                    .HasForeignKey(m => m.ServiceId);
        }
    }
}