using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class rmNotifTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 22, 13, 58, 13, 653, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("240e615a-2fa4-468a-8728-c3c9c7d3db58"),
                column: "ConcurrencyStamp",
                value: "ab4d3665-54f0-443a-9740-28ea4cee7215");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "77984ab2-b216-4865-a4e4-91339de3d70f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bed15c1f-b73a-4301-97b8-65fb4f54d1a0"),
                column: "ConcurrencyStamp",
                value: "a950fb25-b0c4-45d9-ae0f-36d2fa9d5132");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d80c014-4959-4d4d-b699-8c10192afc15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57074bb1-826d-4210-9dfc-6ef75d47d649", "AQAAAAEAACcQAAAAEMY8C32ZlSX/dP7TaSwxh/OmR7ZjYtU6i3LFkbdupHcoDh/kcXPIFkxGiIEgRcfYxg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7cff05f9-e0a9-4784-ab6c-86895db5a677", "AQAAAAEAACcQAAAAELT90jE1zJF1JcBPSiKzYrcw7SCkjod3HOwc+4A25MbFKgFskorEExKFK8RB5bP3iw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("deabd869-b037-48f5-9201-052f23f01ca8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17b41ca2-9967-402b-9234-7bba70411a0b", "AQAAAAEAACcQAAAAEGrCSlTMbS3kpu8tWL/5DL7+SwXReiR3QW3FiZ1GXrHzIBL24cAT2DB3wWInrC7xDg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 22, 13, 58, 13, 653, DateTimeKind.Local).AddTicks(171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Receivers = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("240e615a-2fa4-468a-8728-c3c9c7d3db58"),
                column: "ConcurrencyStamp",
                value: "47d81c0b-3733-4096-96f0-5c8e7b54c5b0");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "ad2ed5cd-1d73-4399-b9f4-51b2cc642611");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bed15c1f-b73a-4301-97b8-65fb4f54d1a0"),
                column: "ConcurrencyStamp",
                value: "58abf9b7-c7ae-40c0-89c2-850fef402d15");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d80c014-4959-4d4d-b699-8c10192afc15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22273f4c-30e2-4bbc-9d65-42f4838cc17b", "AQAAAAEAACcQAAAAECGNjOMs9dHI/t1oXifjRJIRa0sbqfcZ7nJECYceppqYkk2kDePKZwWaICqf1fYUEw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "929aa435-3271-4abb-9d2a-680b68c07d84", "AQAAAAEAACcQAAAAEHvqcrC7p/+0NhAgODO2f1IXt+ZVFlF893vOMAvZkV/i9Z/FPgMC8CxiIhau8Udgvw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("deabd869-b037-48f5-9201-052f23f01ca8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "018d4c4c-af90-46cb-a336-5744b0f61e49", "AQAAAAEAACcQAAAAEPYV+O4mo5763mBK2j/A8A8UZAd3ZiqwTW9utgLSLycD4UmymR6Ax+i4ceLpoeB0AQ==" });
        }
    }
}
