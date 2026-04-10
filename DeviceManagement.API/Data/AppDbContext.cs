using DeviceManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Device  User relationship
            modelBuilder.Entity<Device>()
                .HasOne(d => d.AssignedUser)
                .WithMany(u => u.AssignedDevices)
                .HasForeignKey(d => d.AssignedUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Restrict Type field to only "phone" or "tablet"
            modelBuilder.Entity<Device>()
                .Property(d => d.Type)
                .HasMaxLength(10);
        }
    }
}