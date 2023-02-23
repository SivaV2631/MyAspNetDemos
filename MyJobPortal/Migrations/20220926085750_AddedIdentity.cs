using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace JobPortal.Migrations
{
    public partial class AddedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_Companies_CompanyId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_JobCategories_JobCategoryId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_JobNatures_JobNatureId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_JobStatuses_JobStatusId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_PostJobs_PostJobId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_UserTables_UserId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_UserTables_UserTableId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirementDetails_JobRequirements_JobRequirementId",
                table: "JobRequirementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_Companies_CompanyId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_JobRequirements_JoRequirementId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_JobNatures_JobNatureId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_JobStatuses_JobStatusId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_UserTables_UserId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_UserTypes_UserTypeId",
                table: "UserTables");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_Companies_CompanyId",
                table: "ApplyJobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_JobCategories_JobCategoryId",
                table: "ApplyJobs",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "JobCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_JobNatures_JobNatureId",
                table: "ApplyJobs",
                column: "JobNatureId",
                principalTable: "JobNatures",
                principalColumn: "JobNatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_JobStatuses_JobStatusId",
                table: "ApplyJobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_PostJobs_PostJobId",
                table: "ApplyJobs",
                column: "PostJobId",
                principalTable: "PostJobs",
                principalColumn: "PostJobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_UserTables_UserId",
                table: "ApplyJobs",
                column: "UserId",
                principalTable: "UserTables",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_UserTables_UserTableId",
                table: "Companies",
                column: "UserTableId",
                principalTable: "UserTables",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirementDetails_JobRequirements_JobRequirementId",
                table: "JobRequirementDetails",
                column: "JobRequirementId",
                principalTable: "JobRequirements",
                principalColumn: "JobRequirementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_Companies_CompanyId",
                table: "PostJobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_JobRequirements_JoRequirementId",
                table: "PostJobs",
                column: "JoRequirementId",
                principalTable: "JobRequirements",
                principalColumn: "JobRequirementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_JobNatures_JobNatureId",
                table: "PostJobs",
                column: "JobNatureId",
                principalTable: "JobNatures",
                principalColumn: "JobNatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_JobStatuses_JobStatusId",
                table: "PostJobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_UserTables_UserId",
                table: "PostJobs",
                column: "UserId",
                principalTable: "UserTables",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_UserTypes_UserTypeId",
                table: "UserTables",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_Companies_CompanyId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_JobCategories_JobCategoryId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_JobNatures_JobNatureId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_JobStatuses_JobStatusId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_PostJobs_PostJobId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_UserTables_UserId",
                table: "ApplyJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_UserTables_UserTableId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirementDetails_JobRequirements_JobRequirementId",
                table: "JobRequirementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_Companies_CompanyId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_JobRequirements_JoRequirementId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_JobNatures_JobNatureId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_JobStatuses_JobStatusId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PostJobs_UserTables_UserId",
                table: "PostJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_UserTypes_UserTypeId",
                table: "UserTables");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_Companies_CompanyId",
                table: "ApplyJobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_JobCategories_JobCategoryId",
                table: "ApplyJobs",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "JobCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_JobNatures_JobNatureId",
                table: "ApplyJobs",
                column: "JobNatureId",
                principalTable: "JobNatures",
                principalColumn: "JobNatureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_JobStatuses_JobStatusId",
                table: "ApplyJobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_PostJobs_PostJobId",
                table: "ApplyJobs",
                column: "PostJobId",
                principalTable: "PostJobs",
                principalColumn: "PostJobId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_UserTables_UserId",
                table: "ApplyJobs",
                column: "UserId",
                principalTable: "UserTables",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_UserTables_UserTableId",
                table: "Companies",
                column: "UserTableId",
                principalTable: "UserTables",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirementDetails_JobRequirements_JobRequirementId",
                table: "JobRequirementDetails",
                column: "JobRequirementId",
                principalTable: "JobRequirements",
                principalColumn: "JobRequirementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_Companies_CompanyId",
                table: "PostJobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_JobRequirements_JoRequirementId",
                table: "PostJobs",
                column: "JoRequirementId",
                principalTable: "JobRequirements",
                principalColumn: "JobRequirementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_JobNatures_JobNatureId",
                table: "PostJobs",
                column: "JobNatureId",
                principalTable: "JobNatures",
                principalColumn: "JobNatureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_JobStatuses_JobStatusId",
                table: "PostJobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "JobStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostJobs_UserTables_UserId",
                table: "PostJobs",
                column: "UserId",
                principalTable: "UserTables",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_UserTypes_UserTypeId",
                table: "UserTables",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
