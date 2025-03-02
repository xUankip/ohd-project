using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityItems",
                columns: table => new
                {
                    FacilityItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityItems", x => x.FacilityItemId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityHeadId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilities_Users_FacilityHeadId",
                        column: x => x.FacilityHeadId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedItems",
                columns: table => new
                {
                    BorrowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FacilityItemId = table.Column<int>(type: "int", nullable: true),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    QuantityBorrowed = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedItems", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId");
                    table.ForeignKey(
                        name: "FK_BorrowedItems_FacilityItems_FacilityItemId",
                        column: x => x.FacilityItemId,
                        principalTable: "FacilityItems",
                        principalColumn: "FacilityItemId");
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestorId = table.Column<int>(type: "int", nullable: true),
                    FacilityId = table.Column<int>(type: "int", nullable: true),
                    FacilityItemId = table.Column<int>(type: "int", nullable: true),
                    QuantityRequested = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeverityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosureReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId");
                    table.ForeignKey(
                        name: "FK_Requests_FacilityItems_FacilityItemId",
                        column: x => x.FacilityItemId,
                        principalTable: "FacilityItems",
                        principalColumn: "FacilityItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Users_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserFacilities",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFacilities", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId");
                    table.ForeignKey(
                        name: "FK_UserFacilities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "FacilityId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityHeadId", "FacilityName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1776), 0, null, null, "Provides books and resources for students.", null, "Library", null, null },
                    { 2, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1778), 0, null, null, "Equipped for physics and chemistry experiments.", null, "Science Lab", null, null },
                    { 3, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1779), 0, null, null, "Contains computers for student use.", null, "Computer Lab", null, null },
                    { 4, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1780), 0, null, null, "Indoor sports and fitness activities.", null, "Gymnasium", null, null },
                    { 5, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1780), 0, null, null, "Used for school events and presentations.", null, "Auditorium", null, null },
                    { 6, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1781), 0, null, null, "Outdoor sports facility for football training.", null, "Football Field", null, null },
                    { 7, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1782), 0, null, null, "Used for basketball games and training.", null, "Basketball Court", null, null },
                    { 8, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1782), 0, null, null, "Food and beverages for students and staff.", null, "Cafeteria", null, null },
                    { 9, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1783), 0, null, null, "Parking space for staff and students.", null, "Parking Lot", null, null },
                    { 10, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1784), 0, null, null, "Monitors campus security operations.", null, "Security Room", null, null }
                });

            migrationBuilder.InsertData(
                table: "FacilityItems",
                columns: new[] { "FacilityItemId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityId", "ItemImage", "ItemName", "Quantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1803), 0, null, null, "Kit for physics experiments.", 2, "physics_kit.png", "Physics Kit", 5, null, null },
                    { 2, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1805), 0, null, null, "Includes beakers and test tubes.", 2, "chemistry_set.png", "Chemistry Set", 10, null, null },
                    { 3, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1806), 0, null, null, "Computers for student use.", 3, "computer.png", "Computer", 15, null, null },
                    { 4, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1807), 0, null, null, "Official size basketballs.", 7, "basketball.png", "Basketball", 10, null, null },
                    { 5, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1808), 0, null, null, "For presentations and seminars.", 5, "projector.png", "Projector", 3, null, null },
                    { 6, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1809), 0, null, null, "For gym workouts.", 4, "treadmill.png", "Treadmill", 2, null, null },
                    { 7, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1810), 0, null, null, "Academic and reference books.", 1, "books.png", "Library Books", 500, null, null },
                    { 8, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1811), 0, null, null, "Monitors school security.", 10, "security_camera.png", "Security Camera", 8, null, null },
                    { 9, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1812), 0, null, null, "Used in science experiments.", 2, "microscope.png", "Microscope", 6, null, null },
                    { 10, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1813), 0, null, null, "Used for training and matches.", 6, "football.png", "Football", 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "FacilityHead" },
                    { 3, "Assignee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "DeletedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1730), null, "admin@school.com", "Admin User", true, "hashedpassword", "555-1001", 1, null, "admin" },
                    { 2, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1734), null, "library@school.com", "Library Manager", true, "hashedpassword", "555-1002", 2, null, "library" },
                    { 3, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1736), null, "lab@school.com", "Lab Manager", true, "hashedpassword", "555-1003", 2, null, "lab" },
                    { 4, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1737), null, "gym@school.com", "Gym Supervisor", true, "hashedpassword", "555-1004", 2, null, "gym" },
                    { 5, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1738), null, "sports@school.com", "Sports Coordinator", true, "hashedpassword", "555-1005", 2, null, "sports" },
                    { 6, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1739), null, "it@school.com", "IT Support", true, "hashedpassword", "555-1006", 2, null, "it" },
                    { 7, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1741), null, "assistant1@school.com", "Student Assistant", true, "hashedpassword", "555-1007", 3, null, "assistant1" },
                    { 8, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1742), null, "tech@school.com", "Lab Technician", true, "hashedpassword", "555-1008", 3, null, "tech" },
                    { 9, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1743), null, "security@school.com", "Security Staff", true, "hashedpassword", "555-1009", 3, null, "security" },
                    { 10, new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1744), null, "maintenance@school.com", "Maintenance Staff", true, "hashedpassword", "555-1010", 3, null, "maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "ClosedDate", "ClosureReason", "Description", "FacilityId", "FacilityItemId", "QuantityRequested", "Remarks", "RequestDate", "RequestorId", "SeverityLevel", "Status" },
                values: new object[,]
                {
                    { 1, null, "", "Request for library books.", 1, 7, 2, "", new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1837), 7, "Medium", "Approved" },
                    { 2, null, "", "Physics experiment kit required.", 2, 1, 1, "", new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1843), 8, "High", "Pending" },
                    { 3, null, "", "Chemistry lab items.", 2, 2, 1, "", new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1845), 8, "Medium", "Approved" },
                    { 4, null, "", "Need footballs for practice.", 6, 10, 2, "", new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1847), 10, "Low", "Pending" },
                    { 5, null, "", "Security cameras required.", 10, 8, 3, "", new DateTime(2025, 3, 2, 8, 31, 23, 886, DateTimeKind.Utc).AddTicks(1848), 9, "High", "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_FacilityId",
                table: "BorrowedItems",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_FacilityItemId",
                table: "BorrowedItems",
                column: "FacilityItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_UserId",
                table: "BorrowedItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FacilityHeadId",
                table: "Facilities",
                column: "FacilityHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FacilityId",
                table: "Requests",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FacilityItemId",
                table: "Requests",
                column: "FacilityItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestorId",
                table: "Requests",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFacilities_FacilityId",
                table: "UserFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedItems");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserFacilities");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "FacilityItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
