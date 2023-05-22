using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class crNotifTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receivers = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                value: "fdfaa2f3-199b-4745-ac25-0d73948c168c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("6755b85d-9886-4e98-89df-fe320e6febd7"),
                column: "ConcurrencyStamp",
                value: "ddcbabe7-2897-439d-b30a-55e1bda70ff4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bed15c1f-b73a-4301-97b8-65fb4f54d1a0"),
                column: "ConcurrencyStamp",
                value: "54dd4b5e-0e69-4cd4-8fc3-c941fb8ef778");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d80c014-4959-4d4d-b699-8c10192afc15"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4b298ea-64b0-4acb-9e6d-b23514f9d417", "AQAAAAEAACcQAAAAEHKrblUvUMQJeNE80EwN1tJEyEcb3ZeYE6IHzXBISHpA8eNQjqgDxit2GlLh/Dgp5w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49cad19-8d64-44fe-88ad-3e98fc3376ec"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1dd5815f-57fa-47fd-ada5-c3c5abf06d1b", "AQAAAAEAACcQAAAAEE1lDPcxibTIuVjMvG5YJ++gMxZQ5vyDxz8wDLIWXIpM4H85fyVgr5MLxvokTf5vJQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("deabd869-b037-48f5-9201-052f23f01ca8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a166184f-4e9c-4de2-aaa8-a1267b27679d", "AQAAAAEAACcQAAAAELwAwk+Cbx8egYcuFNq7ht+ZavhO1PFe4LZXgEvTifyvmU6phuJt/V6iVZg/3EeQ9g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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
    }
}
