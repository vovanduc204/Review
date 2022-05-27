using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MC.Repo.Migrations
{
    public partial class FixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AddedDate", "Email", "IPAddress", "ModifiedDate", "Password", "UserName" },
                values: new object[] { 5L, new DateTime(2022, 5, 27, 10, 18, 48, 114, DateTimeKind.Local).AddTicks(6594), "William", "2", new DateTime(2022, 5, 27, 10, 18, 48, 115, DateTimeKind.Local).AddTicks(3200), "Shakespeare", "duc2" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AddedDate", "Email", "IPAddress", "ModifiedDate", "Password", "UserName" },
                values: new object[] { 6L, new DateTime(2022, 5, 27, 10, 18, 48, 115, DateTimeKind.Local).AddTicks(3851), "William", "3", new DateTime(2022, 5, 27, 10, 18, 48, 115, DateTimeKind.Local).AddTicks(3856), "Shakespeare", "duc3" });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "AddedDate", "Address", "FirstName", "IPAddress", "LastName", "ModifiedDate" },
                values: new object[] { 5L, new DateTime(2022, 5, 27, 10, 18, 48, 116, DateTimeKind.Local).AddTicks(4293), " quang nam", " duc", "5", "vo", new DateTime(2022, 5, 27, 10, 18, 48, 116, DateTimeKind.Local).AddTicks(4299) });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "AddedDate", "Address", "FirstName", "IPAddress", "LastName", "ModifiedDate" },
                values: new object[] { 6L, new DateTime(2022, 5, 27, 10, 18, 48, 116, DateTimeKind.Local).AddTicks(4302), " quang nam", " duc", "3", "vo", new DateTime(2022, 5, 27, 10, 18, 48, 116, DateTimeKind.Local).AddTicks(4303) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
