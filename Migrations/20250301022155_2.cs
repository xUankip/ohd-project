using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Facilities_FacilityID",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Items_ItemID",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Users_UserID",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Users_FacilityHeadID",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Facilities_FacilityID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Items_ItemID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestorID",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "User_Facilities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_FacilityName",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedItems_ItemID",
                table: "BorrowedItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RequestorID",
                table: "Requests",
                newName: "RequestorId");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Requests",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "Requests",
                newName: "FacilityId");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "Requests",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestorID",
                table: "Requests",
                newName: "IX_Requests_RequestorId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ItemID",
                table: "Requests",
                newName: "IX_Requests_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_FacilityID",
                table: "Requests",
                newName: "IX_Requests_FacilityId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "NotificationID",
                table: "Notifications",
                newName: "NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameColumn(
                name: "FacilityHeadID",
                table: "Facilities",
                newName: "FacilityHeadId");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "Facilities",
                newName: "FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_FacilityHeadID",
                table: "Facilities",
                newName: "IX_Facilities_FacilityHeadId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "BorrowedItems",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "BorrowedItems",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "BorrowedItems",
                newName: "FacilityId");

            migrationBuilder.RenameColumn(
                name: "BorrowID",
                table: "BorrowedItems",
                newName: "BorrowId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedItems_UserID",
                table: "BorrowedItems",
                newName: "IX_BorrowedItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedItems_FacilityID",
                table: "BorrowedItems",
                newName: "IX_BorrowedItems_FacilityId");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "RequestorId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityRequested",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityHeadId",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BorrowedItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BorrowedItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "BorrowedItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FacilityItemItemId",
                table: "BorrowedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "FacilityItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_FacilityItems", x => x.ItemId);
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

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "FacilityId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityHeadId", "FacilityName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5302), 0, null, null, "Provides books and resources for students.", null, "Library", null, null },
                    { 2, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5310), 0, null, null, "Equipped for physics and chemistry experiments.", null, "Science Lab", null, null },
                    { 3, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5311), 0, null, null, "Contains computers for student use.", null, "Computer Lab", null, null },
                    { 4, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5311), 0, null, null, "Indoor sports and fitness activities.", null, "Gymnasium", null, null },
                    { 5, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5312), 0, null, null, "Used for school events and presentations.", null, "Auditorium", null, null },
                    { 6, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5312), 0, null, null, "Outdoor sports facility for football training.", null, "Football Field", null, null },
                    { 7, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5313), 0, null, null, "Used for basketball games and training.", null, "Basketball Court", null, null },
                    { 8, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5313), 0, null, null, "Food and beverages for students and staff.", null, "Cafeteria", null, null },
                    { 9, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5314), 0, null, null, "Parking space for staff and students.", null, "Parking Lot", null, null },
                    { 10, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5315), 0, null, null, "Monitors campus security operations.", null, "Security Room", null, null }
                });

            migrationBuilder.InsertData(
                table: "FacilityItems",
                columns: new[] { "ItemId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityId", "ItemImage", "ItemName", "Quantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5332), 0, null, null, "Kit for physics experiments.", 2, "physics_kit.png", "Physics Kit", 5, null, null },
                    { 2, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5335), 0, null, null, "Includes beakers and test tubes.", 2, "chemistry_set.png", "Chemistry Set", 10, null, null },
                    { 3, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5364), 0, null, null, "Computers for student use.", 3, "computer.png", "Computer", 15, null, null },
                    { 4, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5365), 0, null, null, "Official size basketballs.", 7, "basketball.png", "Basketball", 10, null, null },
                    { 5, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5366), 0, null, null, "For presentations and seminars.", 5, "projector.png", "Projector", 3, null, null },
                    { 6, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5367), 0, null, null, "For gym workouts.", 4, "treadmill.png", "Treadmill", 2, null, null },
                    { 7, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5367), 0, null, null, "Academic and reference books.", 1, "books.png", "Library Books", 500, null, null },
                    { 8, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5370), 0, null, null, "Monitors school security.", 10, "security_camera.png", "Security Camera", 8, null, null },
                    { 9, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5371), 0, null, null, "Used in science experiments.", 2, "microscope.png", "Microscope", 6, null, null },
                    { 10, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5372), 0, null, null, "Used for training and matches.", 6, "football.png", "Football", 12, null, null }
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
                    { 1, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5267), null, "admin@school.com", "Admin User", true, "hashedpassword", "555-1001", 1, null, "admin" },
                    { 2, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5270), null, "library@school.com", "Library Manager", true, "hashedpassword", "555-1002", 2, null, "library" },
                    { 3, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5273), null, "lab@school.com", "Lab Manager", true, "hashedpassword", "555-1003", 2, null, "lab" },
                    { 4, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5274), null, "gym@school.com", "Gym Supervisor", true, "hashedpassword", "555-1004", 2, null, "gym" },
                    { 5, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5275), null, "sports@school.com", "Sports Coordinator", true, "hashedpassword", "555-1005", 2, null, "sports" },
                    { 6, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5276), null, "it@school.com", "IT Support", true, "hashedpassword", "555-1006", 2, null, "it" },
                    { 7, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5277), null, "assistant1@school.com", "Student Assistant", true, "hashedpassword", "555-1007", 3, null, "assistant1" },
                    { 8, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5278), null, "tech@school.com", "Lab Technician", true, "hashedpassword", "555-1008", 3, null, "tech" },
                    { 9, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5279), null, "security@school.com", "Security Staff", true, "hashedpassword", "555-1009", 3, null, "security" },
                    { 10, new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5279), null, "maintenance@school.com", "Maintenance Staff", true, "hashedpassword", "555-1010", 3, null, "maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "ClosedDate", "ClosureReason", "Description", "FacilityId", "ItemId", "QuantityRequested", "Remarks", "RequestDate", "RequestorId", "SeverityLevel", "Status" },
                values: new object[,]
                {
                    { 1, null, "", "Request for library books.", 1, 7, 2, "", new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5390), 7, "Medium", "Approved" },
                    { 2, null, "", "Physics experiment kit required.", 2, 1, 1, "", new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5393), 8, "High", "Pending" },
                    { 3, null, "", "Chemistry lab items.", 2, 2, 1, "", new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5395), 8, "Medium", "Approved" },
                    { 4, null, "", "Need footballs for practice.", 6, 10, 2, "", new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5396), 10, "Low", "Pending" },
                    { 5, null, "", "Security cameras required.", 10, 8, 3, "", new DateTime(2025, 3, 1, 2, 21, 54, 764, DateTimeKind.Utc).AddTicks(5398), 9, "High", "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_FacilityItemItemId",
                table: "BorrowedItems",
                column: "FacilityItemItemId");

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
                name: "IX_UserFacilities_FacilityId",
                table: "UserFacilities",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Facilities_FacilityId",
                table: "BorrowedItems",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_FacilityItems_FacilityItemItemId",
                table: "BorrowedItems",
                column: "FacilityItemItemId",
                principalTable: "FacilityItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Users_UserId",
                table: "BorrowedItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Users_FacilityHeadId",
                table: "Facilities",
                column: "FacilityHeadId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Facilities_FacilityId",
                table: "Requests",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_FacilityItems_ItemId",
                table: "Requests",
                column: "ItemId",
                principalTable: "FacilityItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Facilities_FacilityId",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_FacilityItems_FacilityItemItemId",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Users_UserId",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Users_FacilityHeadId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Facilities_FacilityId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_FacilityItems_ItemId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FacilityItems");

            migrationBuilder.DropTable(
                name: "UserFacilities");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedItems_FacilityItemItemId",
                table: "BorrowedItems");

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "FacilityItemItemId",
                table: "BorrowedItems");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "RequestorId",
                table: "Requests",
                newName: "RequestorID");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Requests",
                newName: "ItemID");

            migrationBuilder.RenameColumn(
                name: "FacilityId",
                table: "Requests",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Requests",
                newName: "RequestID");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestorId",
                table: "Requests",
                newName: "IX_Requests_RequestorID");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ItemId",
                table: "Requests",
                newName: "IX_Requests_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_FacilityId",
                table: "Requests",
                newName: "IX_Requests_FacilityID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notifications",
                newName: "NotificationID");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserID");

            migrationBuilder.RenameColumn(
                name: "FacilityHeadId",
                table: "Facilities",
                newName: "FacilityHeadID");

            migrationBuilder.RenameColumn(
                name: "FacilityId",
                table: "Facilities",
                newName: "FacilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_FacilityHeadId",
                table: "Facilities",
                newName: "IX_Facilities_FacilityHeadID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BorrowedItems",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "BorrowedItems",
                newName: "ItemID");

            migrationBuilder.RenameColumn(
                name: "FacilityId",
                table: "BorrowedItems",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "BorrowId",
                table: "BorrowedItems",
                newName: "BorrowID");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedItems_UserId",
                table: "BorrowedItems",
                newName: "IX_BorrowedItems_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowedItems_FacilityId",
                table: "BorrowedItems",
                newName: "IX_BorrowedItems_FacilityID");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RequestorID",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityRequested",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityID",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityHeadID",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "BorrowedItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "BorrowedItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityID",
                table: "BorrowedItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_Facilities_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "FacilityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Facilities",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FacilityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Facilities", x => new { x.UserID, x.FacilityID });
                    table.ForeignKey(
                        name: "FK_User_Facilities_Facilities_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "FacilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Facilities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FacilityName",
                table: "Facilities",
                column: "FacilityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_ItemID",
                table: "BorrowedItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FacilityID",
                table: "Items",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Facilities_FacilityID",
                table: "User_Facilities",
                column: "FacilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Facilities_FacilityID",
                table: "BorrowedItems",
                column: "FacilityID",
                principalTable: "Facilities",
                principalColumn: "FacilityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Items_ItemID",
                table: "BorrowedItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Users_UserID",
                table: "BorrowedItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Users_FacilityHeadID",
                table: "Facilities",
                column: "FacilityHeadID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Facilities_FacilityID",
                table: "Requests",
                column: "FacilityID",
                principalTable: "Facilities",
                principalColumn: "FacilityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Items_ItemID",
                table: "Requests",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestorID",
                table: "Requests",
                column: "RequestorID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
