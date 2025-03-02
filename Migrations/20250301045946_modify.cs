using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class modify : Migration
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
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

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
                nullable: false,
                defaultValue: 0);

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
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "RequestDate" },
                values: new object[] { new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(639), 0, new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "RequestDate" },
                values: new object[] { new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(645), 0, new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "RequestDate" },
                values: new object[] { new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(648), 0, new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "RequestDate" },
                values: new object[] { new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(651), 0, new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "RequestDate" },
                values: new object[] { new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(654), 0, new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 4, 59, 45, 368, DateTimeKind.Utc).AddTicks(518));

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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Requests");

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
    }
}
