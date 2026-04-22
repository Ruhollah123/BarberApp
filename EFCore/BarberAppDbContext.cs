using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class BarberAppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }
        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentAlternative> PaymentAlternatives { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:localhost,1433;Database=BarberAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin Bosse", UserName = "admin", CreatedAt = new DateTime(2026, 01, 10) },
                new User { Id = 2, Name = "Erik Karlsson", UserName = "erik90", CreatedAt = new DateTime(2026, 02, 20) },
                new User { Id = 3, Name = "Anna Svensson", UserName = "anna_s", CreatedAt = new DateTime(2026, 03, 15) },
                new User { Id = 4, Name = "Karl Larsson", UserName = "kalle", CreatedAt = new DateTime(2026, 04, 15) }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "customer" }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Erik Karlsson", BirthDate = new DateTime(1990, 5, 12), UserId = 2, RoleId = 2 },
                new Customer { Id = 2, Name = "Anna Svensson", BirthDate = new DateTime(1985, 10, 20), UserId = 3, RoleId = 2 },
                new Customer { Id = 3, Name = "Karl Larsson", BirthDate = new DateTime(2000, 2, 15), UserId = 4, RoleId = 2 }
                );

            modelBuilder.Entity<BarberShop>().HasData(
                new BarberShop { Id = 1, Name = "The Cut-Algorithm", OpeningHours = "Mon-Fri 09:00-18:00" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Matte Hair Wax", Price = 149.00m, BarberShopId = 1 },
                new Product { Id = 2, Name = "Beard Oil Deluxe", Price = 199.00m, BarberShopId = 1 },
                new Product { Id = 3, Name = "Aftershave Eucalyptus", Price = 129.00m, BarberShopId = 1 },
                new Product { Id = 4, Name = "Professional Comb", Price = 89.00m, BarberShopId = 1 }
                );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Classic haircut and styling", Description = "Classic haircut including wash.", Duration = "60 min", Price = 550m },
                new Service { Id = 2, Name = "Trimming and shaping of beard with machine and shears", Description = "Shaping with machine and razor", Duration = "60 min", Price = 350m },
                new Service { Id = 3, Name = "Haircut and beard trim including a hot towel treatment", Description = "Haircut, beard, and hot towel.", Duration = "60 min", Price = 850m },
                new Service { Id = 4, Name = "Buzz Cut", Description = "Simple all-over clipper cut with neck shave.", Duration = "60 min", Price = 250m });

            modelBuilder.Entity<PaymentAlternative>().HasData(
                new PaymentAlternative { Id = 1, Name = "Card-Payment" },
                new PaymentAlternative { Id = 2, Name = "Swish" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, DateTime = new DateTime(2026, 05, 01), CustomerId = 1 },
                new Appointment { Id = 2, DateTime = new DateTime(2026, 05, 02), CustomerId = 2 },
                new Appointment { Id = 3, DateTime = new DateTime(2026, 05, 03), CustomerId = 3 }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2025, 12, 27), TotalAmount = 550m, AppointmentId = 1, PaymentAlternativeId = 2 },
                new Order { Id = 2, OrderDate = new DateTime(2026, 02, 14), TotalAmount = 350m, AppointmentId = 2, PaymentAlternativeId = 1 },
                new Order { Id = 3, OrderDate = new DateTime(2026, 03, 25), TotalAmount = 850m, AppointmentId = 3, PaymentAlternativeId = 2 }
                );
        }
    }
}