using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPSTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class ClientsChangedToDevices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 3, 26, 1, 40, 16, 168, DateTimeKind.Local).AddTicks(4045));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 3, 26, 0, 20, 41, 645, DateTimeKind.Local).AddTicks(6872));
        }
    }
}
