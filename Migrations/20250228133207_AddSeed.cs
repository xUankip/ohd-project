using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Facilities_FacilityId",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_FacilityItems_ItemId",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedItems_Users_UserId",
                table: "BorrowedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Requests_RequestId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Facilities_FacilityId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFacilities_Facilities_FacilityId",
                table: "UserFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFacilities_Users_UserId",
                table: "UserFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFacilities",
                table: "UserFacilities");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedItems_ItemId",
                table: "BorrowedItems");

            migrationBuilder.DropColumn(
                name: "RequestId1",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "UserFacilities",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFacilities",
                table: "UserFacilities",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "FacilityId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityHeadId", "FacilityName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7508), 0, null, null, "Provides books and resources for students.", null, "Library", null, null },
                    { 2, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7511), 0, null, null, "Equipped for physics and chemistry experiments.", null, "Science Lab", null, null },
                    { 3, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7512), 0, null, null, "Contains computers for student use.", null, "Computer Lab", null, null },
                    { 4, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7513), 0, null, null, "Indoor sports and fitness activities.", null, "Gymnasium", null, null },
                    { 5, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7514), 0, null, null, "Used for school events and presentations.", null, "Auditorium", null, null },
                    { 6, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7515), 0, null, null, "Outdoor sports facility for football training.", null, "Football Field", null, null },
                    { 7, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7516), 0, null, null, "Used for basketball games and training.", null, "Basketball Court", null, null },
                    { 8, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7517), 0, null, null, "Food and beverages for students and staff.", null, "Cafeteria", null, null },
                    { 9, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7518), 0, null, null, "Parking space for staff and students.", null, "Parking Lot", null, null },
                    { 10, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7519), 0, null, null, "Monitors campus security operations.", null, "Security Room", null, null }
                });

            migrationBuilder.InsertData(
                table: "FacilityItems",
                columns: new[] { "ItemId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "FacilityId", "ItemImage", "ItemName", "Quantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7541), 0, null, null, "Kit for physics experiments.", 2, "physics_kit.png", "Physics Kit", 5, null, null },
                    { 2, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7545), 0, null, null, "Includes beakers and test tubes.", 2, "chemistry_set.png", "Chemistry Set", 10, null, null },
                    { 3, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7547), 0, null, null, "Computers for student use.", 3, "computer.png", "Computer", 15, null, null },
                    { 4, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7548), 0, null, null, "Official size basketballs.", 7, "basketball.png", "Basketball", 10, null, null },
                    { 5, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7550), 0, null, null, "For presentations and seminars.", 5, "projector.png", "Projector", 3, null, null },
                    { 6, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7570), 0, null, null, "For gym workouts.", 4, "treadmill.png", "Treadmill", 2, null, null },
                    { 7, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7572), 0, null, null, "Academic and reference books.", 1, "books.png", "Library Books", 500, null, null },
                    { 8, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7574), 0, null, null, "Monitors school security.", 10, "security_camera.png", "Security Camera", 8, null, null },
                    { 9, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7575), 0, null, null, "Used in science experiments.", 2, "microscope.png", "Microscope", 6, null, null },
                    { 10, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7577), 0, null, null, "Used for training and matches.", 6, "football.png", "Football", 12, null, null }
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
                    { 1, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7460), null, "admin@school.com", "Admin User", true, "hashedpassword", "555-1001", 1, null, "admin" },
                    { 2, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7464), null, "library@school.com", "Library Manager", true, "hashedpassword", "555-1002", 2, null, "library" },
                    { 3, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7466), null, "lab@school.com", "Lab Manager", true, "hashedpassword", "555-1003", 2, null, "lab" },
                    { 4, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7468), null, "gym@school.com", "Gym Supervisor", true, "hashedpassword", "555-1004", 2, null, "gym" },
                    { 5, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7470), null, "sports@school.com", "Sports Coordinator", true, "hashedpassword", "555-1005", 2, null, "sports" },
                    { 6, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7471), null, "it@school.com", "IT Support", true, "hashedpassword", "555-1006", 2, null, "it" },
                    { 7, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7473), null, "assistant1@school.com", "Student Assistant", true, "hashedpassword", "555-1007", 3, null, "assistant1" },
                    { 8, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7474), null, "tech@school.com", "Lab Technician", true, "hashedpassword", "555-1008", 3, null, "tech" },
                    { 9, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7476), null, "security@school.com", "Security Staff", true, "hashedpassword", "555-1009", 3, null, "security" },
                    { 10, new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7477), null, "maintenance@school.com", "Maintenance Staff", true, "hashedpassword", "555-1010", 3, null, "maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "ClosedDate", "ClosureReason", "Description", "FacilityId", "ItemId", "QuantityRequested", "Remarks", "RequestDate", "RequestorId", "SeverityLevel", "Status" },
                values: new object[,]
                {
                    { 1, null, "", "Request for library books.", 1, 7, 2, "", new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7602), 7, "Medium", "Approved" },
                    { 2, null, "", "Physics experiment kit required.", 2, 1, 1, "", new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7607), 8, "High", "Pending" },
                    { 3, null, "", "Chemistry lab items.", 2, 2, 1, "", new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7610), 8, "Medium", "Approved" },
                    { 4, null, "", "Need footballs for practice.", 6, 10, 2, "", new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7613), 10, "Low", "Pending" },
                    { 5, null, "", "Security cameras required.", 10, 8, 3, "", new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7615), 9, "High", "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_FacilityItemItemId",
                table: "BorrowedItems",
                column: "FacilityItemItemId");

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
                name: "FK_Comments_Requests_RequestId",
                table: "Comments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Facilities_FacilityId",
                table: "Requests",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFacilities_Facilities_FacilityId",
                table: "UserFacilities",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFacilities_Users_UserId",
                table: "UserFacilities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
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
                name: "FK_Comments_Requests_RequestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Facilities_FacilityId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFacilities_Facilities_FacilityId",
                table: "UserFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFacilities_Users_UserId",
                table: "UserFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFacilities",
                table: "UserFacilities");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

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
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
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
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "FacilityItemItemId",
                table: "BorrowedItems");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "UserFacilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFacilities",
                table: "UserFacilities",
                columns: new[] { "UserId", "FacilityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId1",
                table: "Comments",
                column: "RequestId1",
                unique: true,
                filter: "[RequestId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_ItemId",
                table: "BorrowedItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Facilities_FacilityId",
                table: "BorrowedItems",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_FacilityItems_ItemId",
                table: "BorrowedItems",
                column: "ItemId",
                principalTable: "FacilityItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedItems_Users_UserId",
                table: "BorrowedItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Requests_RequestId1",
                table: "Comments",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Facilities_FacilityId",
                table: "Requests",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFacilities_Facilities_FacilityId",
                table: "UserFacilities",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFacilities_Users_UserId",
                table: "UserFacilities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
