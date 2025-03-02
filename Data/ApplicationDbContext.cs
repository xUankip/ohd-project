using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using System;

namespace AspnetCoreMvcStarter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<UserFacility> UserFacilities { get; set; }
        public DbSet<FacilityItem> FacilityItems { get; set; }
        public DbSet<BorrowedItem> BorrowedItems { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Define Foreign Key Relationships
            modelBuilder.Entity<Request>()
                .HasOne(r => r.FacilityItem)
                .WithMany()
                .HasForeignKey(r => r.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Seed User Roles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleId = 1, RoleName = "Admin" },
                new UserRole { RoleId = 2, RoleName = "FacilityHead" },
                new UserRole { RoleId = 3, RoleName = "Assignee" }
            );

            // ✅ Seed Users
            modelBuilder.Entity<User>().HasData(
              new User { UserId = 1, FullName = "Admin User", Email = "admin@school.com", Username = "admin", PasswordHash = "hashedpassword", Phone = "555-1001", RoleId = 1 },
              new User { UserId = 2, FullName = "Library Manager", Email = "library@school.com", Username = "library", PasswordHash = "hashedpassword", Phone = "555-1002", RoleId = 2 },
              new User { UserId = 3, FullName = "Lab Manager", Email = "lab@school.com", Username = "lab", PasswordHash = "hashedpassword", Phone = "555-1003", RoleId = 2 },
              new User { UserId = 4, FullName = "Gym Supervisor", Email = "gym@school.com", Username = "gym", PasswordHash = "hashedpassword", Phone = "555-1004", RoleId = 2 },
              new User { UserId = 5, FullName = "Sports Coordinator", Email = "sports@school.com", Username = "sports", PasswordHash = "hashedpassword", Phone = "555-1005", RoleId = 2 },
              new User { UserId = 6, FullName = "IT Support", Email = "it@school.com", Username = "it", PasswordHash = "hashedpassword", Phone = "555-1006", RoleId = 2 },
              new User { UserId = 7, FullName = "Student Assistant", Email = "assistant1@school.com", Username = "assistant1", PasswordHash = "hashedpassword", Phone = "555-1007", RoleId = 3 },
              new User { UserId = 8, FullName = "Lab Technician", Email = "tech@school.com", Username = "tech", PasswordHash = "hashedpassword", Phone = "555-1008", RoleId = 3 },
              new User { UserId = 9, FullName = "Security Staff", Email = "security@school.com", Username = "security", PasswordHash = "hashedpassword", Phone = "555-1009", RoleId = 3 },
              new User { UserId = 10, FullName = "Maintenance Staff", Email = "maintenance@school.com", Username = "maintenance", PasswordHash = "hashedpassword", Phone = "555-1010", RoleId = 3 }
            );

            // ✅ Seed Facilities
            modelBuilder.Entity<Facility>().HasData(
                new Facility { FacilityId = 1, FacilityName = "Library", Description = "Provides books and resources for students." },
                new Facility { FacilityId = 2, FacilityName = "Science Lab", Description = "Equipped for physics and chemistry experiments." },
                new Facility { FacilityId = 3, FacilityName = "Computer Lab", Description = "Contains computers for student use." },
                new Facility { FacilityId = 4, FacilityName = "Gymnasium", Description = "Indoor sports and fitness activities." },
                new Facility { FacilityId = 5, FacilityName = "Auditorium", Description = "Used for school events and presentations." },
                new Facility { FacilityId = 6, FacilityName = "Football Field", Description = "Outdoor sports facility for football training." },
                new Facility { FacilityId = 7, FacilityName = "Basketball Court", Description = "Used for basketball games and training." },
                new Facility { FacilityId = 8, FacilityName = "Cafeteria", Description = "Food and beverages for students and staff." },
                new Facility { FacilityId = 9, FacilityName = "Parking Lot", Description = "Parking space for staff and students." },
                new Facility { FacilityId = 10, FacilityName = "Security Room", Description = "Monitors campus security operations." }
            );

            // ✅ Seed Facility Items
            modelBuilder.Entity<FacilityItem>().HasData(
                new FacilityItem { ItemId = 1, ItemName = "Physics Kit", FacilityId = 2, Quantity = 5, ItemImage = "physics_kit.png", Description = "Kit for physics experiments." },
                new FacilityItem { ItemId = 2, ItemName = "Chemistry Set", FacilityId = 2, Quantity = 10, ItemImage = "chemistry_set.png", Description = "Includes beakers and test tubes." },
                new FacilityItem { ItemId = 3, ItemName = "Computer", FacilityId = 3, Quantity = 15, ItemImage = "computer.png", Description = "Computers for student use." },
                new FacilityItem { ItemId = 4, ItemName = "Basketball", FacilityId = 7, Quantity = 10, ItemImage = "basketball.png", Description = "Official size basketballs." },
                new FacilityItem { ItemId = 5, ItemName = "Projector", FacilityId = 5, Quantity = 3, ItemImage = "projector.png", Description = "For presentations and seminars." },
                new FacilityItem { ItemId = 6, ItemName = "Treadmill", FacilityId = 4, Quantity = 2, ItemImage = "treadmill.png", Description = "For gym workouts." },
                new FacilityItem { ItemId = 7, ItemName = "Library Books", FacilityId = 1, Quantity = 500, ItemImage = "books.png", Description = "Academic and reference books." },
                new FacilityItem { ItemId = 8, ItemName = "Security Camera", FacilityId = 10, Quantity = 8, ItemImage = "security_camera.png", Description = "Monitors school security." },
                new FacilityItem { ItemId = 9, ItemName = "Microscope", FacilityId = 2, Quantity = 6, ItemImage = "microscope.png", Description = "Used in science experiments." },
                new FacilityItem { ItemId = 10, ItemName = "Football", FacilityId = 6, Quantity = 12, ItemImage = "football.png", Description = "Used for training and matches." }
            );

            // ✅ Seed Requests (Fixed `ItemId` issue)
            modelBuilder.Entity<Request>().HasData(
                new Request { RequestId = 1, RequestorId = 7, FacilityId = 1, ItemId = 7, QuantityRequested = 2, Status = "Approved", Description = "Request for library books.", ClosureReason = "", Remarks = "", SeverityLevel = "Medium" },
                new Request { RequestId = 2, RequestorId = 8, FacilityId = 2, ItemId = 1, QuantityRequested = 1, Status = "Pending", Description = "Physics experiment kit required.", ClosureReason = "", Remarks = "", SeverityLevel = "High" },
                new Request { RequestId = 3, RequestorId = 8, FacilityId = 2, ItemId = 2, QuantityRequested = 1, Status = "Approved", Description = "Chemistry lab items.", ClosureReason = "", Remarks = "", SeverityLevel = "Medium" },
                new Request { RequestId = 4, RequestorId = 10, FacilityId = 6, ItemId = 10, QuantityRequested = 2, Status = "Pending", Description = "Need footballs for practice.", ClosureReason = "", Remarks = "", SeverityLevel = "Low" },
                new Request { RequestId = 5, RequestorId = 9, FacilityId = 10, ItemId = 8, QuantityRequested = 3, Status = "Rejected", Description = "Security cameras required.", ClosureReason = "", Remarks = "", SeverityLevel = "High" }
            );
        }
    }
}
