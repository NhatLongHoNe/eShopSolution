using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 17, 36, 9, 513, DateTimeKind.Local).AddTicks(2084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 11, 49, 14, 298, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c0b3b068-3570-4139-b8f1-441a4c14168f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b5cab65-68dd-4430-9930-1ddcae023da9", "AQAAAAEAACcQAAAAEHkKKGZHYtmMpZLq0gGr901wuAfzp9gbqnlW1jKb37E2YXGfbNWMUqJnyfV3Ie2ReQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 18, 17, 36, 9, 531, DateTimeKind.Local).AddTicks(8143));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 11, 49, 14, 298, DateTimeKind.Local).AddTicks(176),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 18, 17, 36, 9, 513, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "e16f2504-27ae-4ffc-8062-a3896ab36572");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81426769-3af2-46aa-b925-72f812e62f1c", "AQAAAAEAACcQAAAAEBNIFpTfHb/MesaHJsZDrUrJqt0JJ2P+3CkNzicrhvJdStz0tawlnwbXglu2J7VoYQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 15, 11, 49, 14, 316, DateTimeKind.Local).AddTicks(1804));
        }
    }
}
