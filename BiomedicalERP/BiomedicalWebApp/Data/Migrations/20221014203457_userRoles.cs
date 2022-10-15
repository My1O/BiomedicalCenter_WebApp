using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiomedicalWebApp.Data.Migrations
{
    public partial class userRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5995887b-443c-47be-b086-05b4a1c54d03", "b4eb7ff8-66b6-46e1-9026-bfd50af03789", "Supervisor", "SUPERVISOR" },
                    { "6da656d4-b96e-473b-b2e4-7eb297a75483", "01ce27d6-148a-434e-b9d7-667dd3d4eb00", "Administrador", "ADMINISTRADOR" },
                    { "e7e383f8-c338-4855-8117-2c054f506410", "6ade3f67-2c4c-42be-8b2c-b11ad4f5f862", "Desarrollador", "DESARROLLADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6cc95765-b72a-478a-9f90-c94674c3b434", 0, "cfbd6de7-c0f6-49dd-aa75-221e080bcd74", "ApplicationUser", "martinezjohnny@El.com", true, false, null, "MARTINEZJOHNNY@EL.COM", "MARTINEZJOHNNY@EL.COM", "AQAAAAEAACcQAAAAEGUt4PseeGWvx04oPXfgBjwMXv1IcXq9tHF9y/JTQhfwEFCD0cxoX6ppwGws5tpByw==", null, false, "fbef81cc-faea-4251-9b8a-cc4fcd8399bc", false, "martinezjohnny@El.com" },
                    { "ce0f6b83-4534-4990-8418-5cc001a2bd96", 0, "b6974dd8-9623-4864-bd6b-57bf0f374831", "ApplicationUser", "Rcairo@09.com", true, false, null, "RCAIRO@09.COM", "RCAIRO@09.COM", "AQAAAAEAACcQAAAAEDfxlGEnGJVTopjYn7QWgM8BWgK3E8wNIXhcT3xPCez43ZJSLN76x13tP9Qss0aLnw==", null, false, "e04d350f-40e4-47ea-8ed4-c413e120f98c", false, "Rcairo@09.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6da656d4-b96e-473b-b2e4-7eb297a75483", "6cc95765-b72a-478a-9f90-c94674c3b434" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5995887b-443c-47be-b086-05b4a1c54d03", "ce0f6b83-4534-4990-8418-5cc001a2bd96" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e383f8-c338-4855-8117-2c054f506410");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6da656d4-b96e-473b-b2e4-7eb297a75483", "6cc95765-b72a-478a-9f90-c94674c3b434" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5995887b-443c-47be-b086-05b4a1c54d03", "ce0f6b83-4534-4990-8418-5cc001a2bd96" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5995887b-443c-47be-b086-05b4a1c54d03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6da656d4-b96e-473b-b2e4-7eb297a75483");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6cc95765-b72a-478a-9f90-c94674c3b434");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce0f6b83-4534-4990-8418-5cc001a2bd96");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
