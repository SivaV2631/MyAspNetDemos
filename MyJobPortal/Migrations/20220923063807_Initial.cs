using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJobPortal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStatuses",
                columns: table => new
                {
                    AccountStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountStatusName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatuses", x => x.AccountStatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserTables",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    UserTypeId = table.Column<int>(nullable: false),
                    AccountStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTables", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTables_AccountStatuses_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "AccountStatuses",
                        principalColumn: "AccountStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTables_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_UserTypeId",
                table: "UserTables",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTables");

            migrationBuilder.DropTable(
                name: "AccountStatuses");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
