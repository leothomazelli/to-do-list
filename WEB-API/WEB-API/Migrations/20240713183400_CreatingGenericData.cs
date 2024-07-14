using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class CreatingGenericData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "DueDate", "Status", "Summary", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 13, 15, 34, 0, 375, DateTimeKind.Local).AddTicks(6807), new DateTime(2025, 7, 13, 15, 34, 0, 375, DateTimeKind.Local).AddTicks(6807), 1, "Ir ao futebol.", "Futebol", 1 },
                    { 2, new DateTime(2024, 7, 13, 15, 34, 0, 375, DateTimeKind.Local).AddTicks(6811), new DateTime(2025, 7, 13, 15, 34, 0, 375, DateTimeKind.Local).AddTicks(6812), 0, "Ir ao mercado.", "Mercado", 1 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "leonardothomazellif@gmail.com", "123456", "Leonardo" },
                    { 2, "geraneves@gmail.com", "654321", "Geraldo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
