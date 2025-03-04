using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AspnetCoreMvcStarter.Data
{
    public class ApplicationDbContext : DbContext
    {
      private string HashPassword(string password)
      {
        using (SHA256 sha256 = SHA256.Create())
        {
          byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
          StringBuilder builder = new StringBuilder();
          foreach (var b in bytes)
          {
            builder.Append(b.ToString("x2"));
          }
          return builder.ToString();
        }
      }

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
                .HasForeignKey(r => r.FacilityItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Seed User Roles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleId = 1, RoleName = "Admin" },
                new UserRole { RoleId = 2, RoleName = "FacilityHead" },
                new UserRole { RoleId = 3, RoleName = "Assignee" },
                new UserRole { RoleId = 4, RoleName = "User" }
            );

            modelBuilder.Entity<User>().HasData(
              new User { UserId = 1, FullName = "Admin User", Email = "admin@school.com", Username = "admin", PasswordHash = HashPassword("Admin123!"), Phone = "555-1001", RoleId = 1 },
              new User { UserId = 2, FullName = "Library Manager", Email = "library@school.com", Username = "library", PasswordHash = HashPassword("Library123!"), Phone = "555-1002", RoleId = 2 },
              new User { UserId = 3, FullName = "Lab Manager", Email = "lab@school.com", Username = "lab", PasswordHash = HashPassword("Lab123!"), Phone = "555-1003", RoleId = 2 },
              new User { UserId = 4, FullName = "Gym Supervisor", Email = "gym@school.com", Username = "gym", PasswordHash = HashPassword("Gym123!"), Phone = "555-1004", RoleId = 2 },
              new User { UserId = 5, FullName = "Sports Coordinator", Email = "sports@school.com", Username = "sports", PasswordHash = HashPassword("Sports123!"), Phone = "555-1005", RoleId = 2 },
              new User { UserId = 6, FullName = "IT Support", Email = "it@school.com", Username = "it", PasswordHash = HashPassword("IT123!"), Phone = "555-1006", RoleId = 2 },
              new User { UserId = 7, FullName = "Student Assistant", Email = "assistant1@school.com", Username = "assistant1", PasswordHash = HashPassword("Assistant123!"), Phone = "555-1007", RoleId = 3 },
              new User { UserId = 8, FullName = "Lab Technician", Email = "tech@school.com", Username = "tech", PasswordHash = HashPassword("Tech123!"), Phone = "555-1008", RoleId = 3 },
              new User { UserId = 9, FullName = "Security Staff", Email = "security@school.com", Username = "security", PasswordHash = HashPassword("Security123!"), Phone = "555-1009", RoleId = 3 },
              new User { UserId = 10, FullName = "Maintenance Staff", Email = "maintenance@school.com", Username = "maintenance", PasswordHash = HashPassword("Maintenance123!"), Phone = "555-1010", RoleId = 3 },
              new User { UserId = 11, FullName = "User 1", Email = "User1@school.com", Username = "User 1", PasswordHash = HashPassword("User123!"), Phone = "555-1011", RoleId = 4 },
              new User { UserId = 12, FullName = "User 2", Email = "User2@school.com", Username = "User 2", PasswordHash = HashPassword("User123!"), Phone = "555-1012", RoleId = 4 },
              new User { UserId = 13, FullName = "User 3", Email = "User3@school.com", Username = "User 3", PasswordHash = HashPassword("User123!"), Phone = "555-1013", RoleId = 4 },
              new User { UserId = 14, FullName = "User 4", Email = "User4@school.com", Username = "User 4", PasswordHash = HashPassword("User123!"), Phone = "555-1014", RoleId = 4 },
              new User { UserId = 15, FullName = "User 5", Email = "User5@school.com", Username = "User 5", PasswordHash = HashPassword("User123!"), Phone = "555-1015", RoleId = 4 },
              new User { UserId = 16, FullName = "User 6", Email = "User6@school.com", Username = "User 6", PasswordHash = HashPassword("User123!"), Phone = "555-1016", RoleId = 4 },
              new User { UserId = 17, FullName = "User 7", Email = "User7@school.com", Username = "User 7", PasswordHash = HashPassword("User123!"), Phone = "555-1017", RoleId = 4 },
              new User { UserId = 18, FullName = "User 8", Email = "User8@school.com", Username = "User 8", PasswordHash = HashPassword("User123!"), Phone = "555-1018", RoleId = 4 }
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
                new FacilityItem { FacilityItemId = 1, ItemName = "Physics Kit", FacilityId = 2, Quantity = 5, ItemImage = "physics_kit.png", Description = "Kit for physics experiments." },
                new FacilityItem { FacilityItemId = 2, ItemName = "Chemistry Set", FacilityId = 2, Quantity = 10, ItemImage = "chemistry_set.png", Description = "Includes beakers and test tubes." },
                new FacilityItem { FacilityItemId = 3, ItemName = "Computer", FacilityId = 3, Quantity = 15, ItemImage = "computer.png", Description = "Computers for student use." },
                new FacilityItem { FacilityItemId = 4, ItemName = "Basketball", FacilityId = 7, Quantity = 10, ItemImage = "basketball.png", Description = "Official size basketballs." },
                new FacilityItem { FacilityItemId = 5, ItemName = "Projector", FacilityId = 5, Quantity = 3, ItemImage = "projector.png", Description = "For presentations and seminars." },
                new FacilityItem { FacilityItemId = 6, ItemName = "Treadmill", FacilityId = 4, Quantity = 2, ItemImage = "treadmill.png", Description = "For gym workouts." },
                new FacilityItem { FacilityItemId = 7, ItemName = "Library Books", FacilityId = 1, Quantity = 500, ItemImage = "books.png", Description = "Academic and reference books." },
                new FacilityItem { FacilityItemId = 8, ItemName = "Security Camera", FacilityId = 10, Quantity = 8, ItemImage = "security_camera.png", Description = "Monitors school security." },
                new FacilityItem { FacilityItemId = 9, ItemName = "Microscope", FacilityId = 2, Quantity = 6, ItemImage = "microscope.png", Description = "Used in science experiments." },
                new FacilityItem { FacilityItemId = 10, ItemName = "Football", FacilityId = 6, Quantity = 12, ItemImage = "football.png", Description = "Used for training and matches." }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request { RequestId = 1, RequestorId = 7, AssigneeId = 7, FacilityId = 1, FacilityItemId = 7, QuantityRequested = 2, Status = "Approved", Description = "Request for library books.", ClosureReason = "", Remarks = "", SeverityLevel = "Medium" },
                new Request { RequestId = 2, RequestorId = 8, AssigneeId = 7,  FacilityId = 2, FacilityItemId = 1, QuantityRequested = 1, Status = "Pending", Description = "Physics experiment kit required.", ClosureReason = "", Remarks = "", SeverityLevel = "High" },
                new Request { RequestId = 3, RequestorId = 8, AssigneeId = 7,  FacilityId = 2, FacilityItemId = 2, QuantityRequested = 1, Status = "Approved", Description = "Chemistry lab items.", ClosureReason = "", Remarks = "", SeverityLevel = "Medium" },
                new Request { RequestId = 4, RequestorId = 10, AssigneeId = 7,  FacilityId = 6, FacilityItemId = 10, QuantityRequested = 2, Status = "Pending", Description = "Need footballs for practice.", ClosureReason = "", Remarks = "", SeverityLevel = "Low" },
                new Request { RequestId = 5, RequestorId = 9, AssigneeId = 7,  FacilityId = 10, FacilityItemId = 8, QuantityRequested = 3, Status = "Rejected", Description = "Security cameras required.", ClosureReason = "", Remarks = "", SeverityLevel = "High" }
            );

        }
    }
}
