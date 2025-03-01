using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "SeverityLevel",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClosureReason",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "FacilityId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "FacilityItems",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestDate",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestDate",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 4,
                column: "RequestDate",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 5,
                column: "RequestDate",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 6, 54, 57, 313, DateTimeKind.Utc).AddTicks(2946));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeverityLevel",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClosureReason",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
