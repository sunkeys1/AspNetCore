using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspCore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFewUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "GroupId", "Login", "Password", "UserState" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 14, 16, 28, 53, 427, DateTimeKind.Local).AddTicks(6393), 2, "boris2020", "123boris123", "Active" },
                    { 2, new DateTime(2023, 5, 6, 16, 28, 53, 427, DateTimeKind.Local).AddTicks(6411), 1, "superadmin", "adminadmin1", "Active" },
                    { 3, new DateTime(2023, 5, 13, 16, 28, 53, 427, DateTimeKind.Local).AddTicks(6413), 2, "serejenka", "imserge222", "Blocked" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
