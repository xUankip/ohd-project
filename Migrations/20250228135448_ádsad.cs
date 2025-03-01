using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class ádsad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 54, 47, 128, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Requests_RequestId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CommentText",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7575));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5,
                column: "RequestDate",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 28, 13, 32, 7, 53, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");

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
        }
    }
}
