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
                    AssigneeId = table.Column<int>(type: "int", nullable: true),
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
                    { 1, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7333), 0, null, null, "Provides books and resources for students.", null, "Library", null, null },
                    { 2, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7335), 0, null, null, "Equipped for physics and chemistry experiments.", null, "Science Lab", null, null },
                    { 3, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7335), 0, null, null, "Contains computers for student use.", null, "Computer Lab", null, null },
                    { 4, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7358), 0, null, null, "Indoor sports and fitness activities.", null, "Gymnasium", null, null },
                    { 5, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7359), 0, null, null, "Used for school events and presentations.", null, "Auditorium", null, null },
                    { 6, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7359), 0, null, null, "Outdoor sports facility for football training.", null, "Football Field", null, null },
                    { 7, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7360), 0, null, null, "Used for basketball games and training.", null, "Basketball Court", null, null },
                    { 8, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7360), 0, null, null, "Food and beverages for students and staff.", null, "Cafeteria", null, null },
                    { 9, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7361), 0, null, null, "Parking space for staff and students.", null, "Parking Lot", null, null },
                    { 10, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7362), 0, null, null, "Monitors campus security operations.", null, "Security Room", null, null }
                });

            migrationBuilder.InsertData(
                table: "FacilityItems",
                columns: new[] { "FacilityItemId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityId", "ItemImage", "ItemName", "Quantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7380), 0, null, null, "Kit for physics experiments.", 2, "physics_kit.png", "Physics Kit", 5, null, null },
                    { 2, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7383), 0, null, null, "Includes beakers and test tubes.", 2, "chemistry_set.png", "Chemistry Set", 10, null, null },
                    { 3, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7384), 0, null, null, "Computers for student use.", 3, "computer.png", "Computer", 15, null, null },
                    { 4, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7385), 0, null, null, "Official size basketballs.", 7, "basketball.png", "Basketball", 10, null, null },
                    { 5, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7386), 0, null, null, "For presentations and seminars.", 5, "projector.png", "Projector", 3, null, null },
                    { 6, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7387), 0, null, null, "For gym workouts.", 4, "treadmill.png", "Treadmill", 2, null, null },
                    { 7, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7388), 0, null, null, "Academic and reference books.", 1, "books.png", "Library Books", 500, null, null },
                    { 8, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7389), 0, null, null, "Monitors school security.", 10, "security_camera.png", "Security Camera", 8, null, null },
                    { 9, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7389), 0, null, null, "Used in science experiments.", 2, "microscope.png", "Microscope", 6, null, null },
                    { 10, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7390), 0, null, null, "Used for training and matches.", 6, "football.png", "Football", 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "FacilityHead" },
                    { 3, "Assignee" },
                    { 4, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "DeletedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(6674), null, "admin@school.com", "Admin User", true, "3eb3fe66b31e3b4d10fa70b5cad49c7112294af6ae4e476a1c405155d45aa121", "555-1001", 1, null, "admin" },
                    { 2, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(6902), null, "library@school.com", "Library Manager", true, "7cb4dbb8075170db54428e835e52d460e62ab87b69e0d2be839720dd9021e283", "555-1002", 2, null, "library" },
                    { 3, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(6969), null, "lab@school.com", "Lab Manager", true, "8e52e0a33866d5aa80d1f14dffcbc464f412514a3511efe1d064ec16b5ad019e", "555-1003", 2, null, "lab" },
                    { 4, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(6987), null, "gym@school.com", "Gym Supervisor", true, "a0133dab4d7cba9eab132cb7685226637a7160133801f4f6128ce9e2d02c1818", "555-1004", 2, null, "gym" },
                    { 5, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7004), null, "sports@school.com", "Sports Coordinator", true, "fdf720d8c79befe8b10d34198a0ba4ab648112919ce605a6ed02b6a4ffb9103d", "555-1005", 2, null, "sports" },
                    { 6, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7021), null, "it@school.com", "IT Support", true, "31f8e2558c4e101cc8dd389cda792ca5d40c82123ce8227bec1cd80277f40140", "555-1006", 2, null, "it" },
                    { 7, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7062), null, "assistant1@school.com", "Student Assistant", true, "3ce2305001eb77db89331a21af3dc007e9bbbecfb5cd07a62a8cb55b9981e1ba", "555-1007", 3, null, "assistant1" },
                    { 8, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7079), null, "tech@school.com", "Lab Technician", true, "090368d31d3a9252525bd7054b042d1d4d9b15c3e8f2d3824c1354b5be1ea269", "555-1008", 3, null, "tech" },
                    { 9, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7095), null, "security@school.com", "Security Staff", true, "814d75eb9a4302909ccbbffc196e22a1f732263c6194a4991603fae272480159", "555-1009", 3, null, "security" },
                    { 10, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7112), null, "maintenance@school.com", "Maintenance Staff", true, "62b2e47e3ee33aff95358885437a7e19c49cd62f8dfd0cc2761662e46f3292cf", "555-1010", 3, null, "maintenance" },
                    { 11, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7127), null, "User1@school.com", "User 1", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1011", 4, null, "User 1" },
                    { 12, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7181), null, "User2@school.com", "User 2", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1012", 4, null, "User 2" },
                    { 13, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7196), null, "User3@school.com", "User 3", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1013", 4, null, "User 3" },
                    { 14, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7211), null, "User4@school.com", "User 4", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1014", 4, null, "User 4" },
                    { 15, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7225), null, "User5@school.com", "User 5", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1015", 4, null, "User 5" },
                    { 16, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7260), null, "User6@school.com", "User 6", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1016", 4, null, "User 6" },
                    { 17, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7274), null, "User7@school.com", "User 7", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1017", 4, null, "User 7" },
                    { 18, new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7288), null, "User8@school.com", "User 8", true, "bc5848f227cc161eb5f68dfe98cb13110a9c843ce69e953a88107d865583d397", "555-1018", 4, null, "User 8" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "AssigneeId", "ClosedDate", "ClosureReason", "Description", "FacilityId", "FacilityItemId", "QuantityRequested", "Remarks", "RequestDate", "RequestorId", "SeverityLevel", "Status" },
                values: new object[,]
                {
                    { 1, 7, null, "", "Request for library books.", 1, 7, 2, "", new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7408), 7, "Medium", "Approved" },
                    { 2, 7, null, "", "Physics experiment kit required.", 2, 1, 1, "", new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7414), 8, "High", "Pending" },
                    { 3, 7, null, "", "Chemistry lab items.", 2, 2, 1, "", new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7417), 8, "Medium", "Approved" },
                    { 4, 7, null, "", "Need footballs for practice.", 6, 10, 2, "", new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7422), 10, "Low", "Pending" },
                    { 5, 7, null, "", "Security cameras required.", 10, 8, 3, "", new DateTime(2025, 3, 4, 11, 25, 2, 715, DateTimeKind.Utc).AddTicks(7423), 9, "High", "Rejected" }
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
                column: "RequestId");

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
