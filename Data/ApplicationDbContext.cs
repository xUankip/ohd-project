using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcStarter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<User_Facility> User_Facilities { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<BorrowedItem> BorrowedItems { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key for User_Facility
            modelBuilder.Entity<User_Facility>()
                .HasKey(uf => new { uf.UserID, uf.FacilityID });

            // Configure relationships for User
            modelBuilder.Entity<User>()
                .HasMany(u => u.ManagedFacilities)
                .WithOne(f => f.FacilityHead)
                .HasForeignKey(f => f.FacilityHeadID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Facility
            modelBuilder.Entity<Facility>()
                .HasMany(f => f.Items)
                .WithOne(i => i.Facility)
                .HasForeignKey(i => i.FacilityID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure soft delete filter
            modelBuilder.Entity<User>().HasQueryFilter(u => u.DeletedAt == null);
            modelBuilder.Entity<Facility>().HasQueryFilter(f => f.DeletedAt == null);
            modelBuilder.Entity<Item>().HasQueryFilter(i => i.DeletedAt == null);
            modelBuilder.Entity<Request>().HasQueryFilter(r => r.DeletedAt == null);
            modelBuilder.Entity<Notification>().HasQueryFilter(n => n.DeletedAt == null);

            // Configure indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Facility>()
                .HasIndex(f => f.FacilityName)
                .IsUnique();

            // Configure cascade delete behavior
            modelBuilder.Entity<BorrowedItem>()
                .HasOne(bi => bi.User)
                .WithMany(u => u.BorrowedItems)
                .HasForeignKey(bi => bi.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Requestor)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.RequestorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
