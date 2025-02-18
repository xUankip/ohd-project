using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcStarter.Data.Seeders
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Users first since other entities depend on it
            var users = new List<User>();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Password123!", workFactor:5); // In real app, use proper password hashing

            for (int i = 1; i <= 10; i++)
            {
                users.Add(new User
                {
                    UserID = i,
                    Username = $"user{i}",
                    PasswordHash = hashedPassword,
                    Email = $"user{i}@example.com",
                    RoleID = (UserRole)(i % 4), // Cycles through all roles
                    FullName = $"User {i} Full Name",
                    Phone = $"555-000-{i.ToString("D4")}",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            // Seed Facilities
            var facilities = new List<Facility>();
            for (int i = 1; i <= 10; i++)
            {
                facilities.Add(new Facility
                {
                    FacilityID = i,
                    FacilityName = $"Facility {i}",
                    Description = $"Description for Facility {i}",
                    FacilityHeadID = (i % 3) + 1, // Assigns facility heads from first 3 users
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1
                });
            }
            modelBuilder.Entity<Facility>().HasData(facilities);

            // Seed User_Facility relationships
            var userFacilities = new List<User_Facility>();
            for (int i = 1; i <= 10; i++)
            {
                userFacilities.Add(new User_Facility
                {
                    UserID = i,
                    FacilityID = ((i - 1) % 10) + 1
                });
            }
            modelBuilder.Entity<User_Facility>().HasData(userFacilities);

            // Seed Items
            var items = new List<Item>();
            for (int i = 1; i <= 10; i++)
            {
                items.Add(new Item
                {
                    ItemID = i,
                    ItemName = $"Item {i}",
                    FacilityID = ((i - 1) % 10) + 1,
                    Quantity = 100 + i,
                    Description = $"Description for Item {i}",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1
                });
            }
            modelBuilder.Entity<Item>().HasData(items);

            // Seed BorrowedItems
            var borrowedItems = new List<BorrowedItem>();
            for (int i = 1; i <= 10; i++)
            {
                borrowedItems.Add(new BorrowedItem
                {
                    BorrowID = i,
                    UserID = ((i - 1) % 10) + 1,
                    ItemID = ((i - 1) % 10) + 1,
                    FacilityID = ((i - 1) % 10) + 1,
                    QuantityBorrowed = i,
                    BorrowDate = DateTime.UtcNow.AddDays(-i),
                    ReturnDate = i % 2 == 0 ? DateTime.UtcNow : null,
                    Status = i % 2 == 0 ? BorrowStatus.Returned.ToString() : BorrowStatus.Borrowed.ToString()
                });
            }
            modelBuilder.Entity<BorrowedItem>().HasData(borrowedItems);

            // Seed Requests
            var requests = new List<Request>();
            for (int i = 1; i <= 10; i++)
            {
                requests.Add(new Request
                {
                    RequestID = i,
                    RequestorID = ((i - 1) % 10) + 1,
                    FacilityID = ((i - 1) % 10) + 1,
                    ItemID = i % 2 == 0 ? ((i - 1) % 10) + 1 : null,
                    QuantityRequested = i % 2 == 0 ? i : null,
                    RequestDate = DateTime.UtcNow.AddDays(-i),
                    SeverityLevel = ((SeverityLevel)(i % 4)).ToString(),
                    Description = $"Request {i} description",
                    Status = ((RequestStatus)(i % 6)).ToString(),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1
                });
            }
            modelBuilder.Entity<Request>().HasData(requests);

            // Seed Notifications
            var notifications = new List<Notification>();
            for (int i = 1; i <= 10; i++)
            {
                notifications.Add(new Notification
                {
                    NotificationID = i,
                    UserID = ((i - 1) % 10) + 1,
                    Message = $"Notification {i} message",
                    CreatedAt = DateTime.UtcNow.AddDays(-i),
                    IsRead = i % 2 == 0,
                    CreatedBy = 1
                });
            }
            modelBuilder.Entity<Notification>().HasData(notifications);
        }
    }
}
