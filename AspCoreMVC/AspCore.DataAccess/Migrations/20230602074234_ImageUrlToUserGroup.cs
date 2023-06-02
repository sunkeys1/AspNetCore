using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlToUserGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "UsersGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 31, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 23, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 30, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 28, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 18, 14, 42, 34, 540, DateTimeKind.Local).AddTicks(8000));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "UsersGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 31, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 23, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 30, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 28, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 13, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "UsersGroup",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 18, 14, 29, 23, 71, DateTimeKind.Local).AddTicks(6699));
        }
    }
}
