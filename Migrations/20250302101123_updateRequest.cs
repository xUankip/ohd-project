using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class updateRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 10, 11, 22, 499, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_RequestId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "FacilityItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5,
                column: "RequestDate",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 9, 23, 41, 950, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");
        }
    }
}
