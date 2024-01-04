using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSApp.Migrations
{
    public partial class AddAdminEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "PasswordHash", "Username" },
                values: new object[] { "ISAjW", "AQAAAAEAACcQAAAAEOvkW3iXaNbmZHfOuaSu4YkINmcj/9P84BvrZTaL8tngcdBwGp/UNjlsTkFNtCTzfg==", "admin@example.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
