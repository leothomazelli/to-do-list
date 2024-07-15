using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "DueDate", "Status", "Summary", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 14, 21, 20, 44, 235, DateTimeKind.Local).AddTicks(6402), new DateTime(2025, 7, 14, 21, 20, 44, 235, DateTimeKind.Local).AddTicks(6403), 0, "Ir ao futebol.", "Futebol", 2 },
                    { 2, new DateTime(2024, 7, 14, 21, 20, 44, 235, DateTimeKind.Local).AddTicks(6407), new DateTime(2025, 7, 14, 21, 20, 44, 235, DateTimeKind.Local).AddTicks(6407), 1, "Ir ao mercado.", "Mercado", 3 },
                    { 3, new DateTime(2024, 7, 14, 21, 20, 44, 235, DateTimeKind.Local).AddTicks(6409), new DateTime(2025, 7, 14, 21, 20, 44, 235, DateTimeKind.Local).AddTicks(6409), 2, "Finalizar o teste.", "Teste de Programação", 1 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin", "admin" },
                    { 2, "leonardothomazellif@gmail.com", "123456", "Leonardo" },
                    { 3, "geraneves@gmail.com", "654321", "Geraldo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
