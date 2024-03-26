using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPSTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class Userdataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ExpireDate", "PasswordHash", "PhoneNumber", "RefreshToken", "Salt", "UserName" },
                values: new object[] { 1, new DateTime(2024, 3, 24, 21, 39, 13, 816, DateTimeKind.Local).AddTicks(7777), "AoL+NXk75HeX0viAK5M26zpK6hDCyx/iPB35io1ZQxg=", "+998912345678", "1441845a-a3ed-4096-ac7c-454e21cf846a", "8eb3bfb8-a6d7-451d-96c3-7a847c8f72b1", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
