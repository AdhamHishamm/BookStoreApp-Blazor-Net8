using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ee3a968-9685-43cc-8ee3-b2f637e75032", "8bea7983-d3cf-4568-98b9-7ed2ed06376e", "User", "USER" },
                    { "c8ee558b-4f61-4e70-baad-652277882885", "af40331e-3396-4a74-8495-de0d70eed889", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8bea7983-d3cf-4568-98b9-7ed2ed06376e", 0, "46ea4aff-80e4-4a78-9089-8109ab79bce9", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAECsFE8VoBAehOOVcxZS1lXkliPMYICjmfdvS+PjvgnKROitzy4wWaE0DwppkeOz19g==", null, false, "feeff4ee-f996-4245-9d9e-18fce34920e2", false, "user@bookstore.com" },
                    { "af40331e-3396-4a74-8495-de0d70eed889", 0, "4c5f2ef3-e8fe-49ee-8dd5-ae065d07b972", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAENHEIqn3sIl/6klI+Omv7CnP65SWtcTPFeDtTzKJOFGL/CC+S1P5dg9jWdbR4NygHg==", null, false, "0d1f4fe7-bae7-41c6-92b7-2aa022c7a4b8", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[]{ "5ee3a968-9685-43cc-8ee3-b2f637e75032", "8bea7983-d3cf-4568-98b9-7ed2ed06376e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[]{ "c8ee558b-4f61-4e70-baad-652277882885", "af40331e-3396-4a74-8495-de0d70eed889" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5ee3a968-9685-43cc-8ee3-b2f637e75032", "8bea7983-d3cf-4568-98b9-7ed2ed06376e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8ee558b-4f61-4e70-baad-652277882885", "af40331e-3396-4a74-8495-de0d70eed889" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ee3a968-9685-43cc-8ee3-b2f637e75032");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8ee558b-4f61-4e70-baad-652277882885");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bea7983-d3cf-4568-98b9-7ed2ed06376e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af40331e-3396-4a74-8495-de0d70eed889");
        }
    }
}
