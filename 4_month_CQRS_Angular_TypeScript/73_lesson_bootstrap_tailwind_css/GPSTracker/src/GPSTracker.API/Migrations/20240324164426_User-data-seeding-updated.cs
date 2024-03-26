using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPSTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class Userdataseedingupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 3, 25, 21, 44, 25, 845, DateTimeKind.Local).AddTicks(7879));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 3, 24, 21, 39, 13, 816, DateTimeKind.Local).AddTicks(7777));
        }
    }
}
