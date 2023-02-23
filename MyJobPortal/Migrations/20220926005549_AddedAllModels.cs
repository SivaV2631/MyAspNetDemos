using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace JobPortal.Migrations
{
    public partial class AddedAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "JobNatures",
                columns: table => new
                {
                    JobNatureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobNatureName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobNatures", x => x.JobNatureId);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirements",
                columns: table => new
                {
                    JobRequirementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRequirementTitle = table.Column<string>(maxLength: 100, nullable: false),
                    JobRequirementId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirements", x => x.JobRequirementId);
                    table.ForeignKey(
                        name: "FK_JobRequirements_JobRequirements_JobRequirementId1",
                        column: x => x.JobRequirementId1,
                        principalTable: "JobRequirements",
                        principalColumn: "JobRequirementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobStatuses",
                columns: table => new
                {
                    JobStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobStatusName = table.Column<string>(maxLength: 100, nullable: false),
                    StatusMessage = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatuses", x => x.JobStatusId);
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
                name: "JobRequirementDetails",
                columns: table => new
                {
                    JobRequirementDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRequirmentDetailName = table.Column<string>(maxLength: 500, nullable: false),
                    JobRequirementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirementDetails", x => x.JobRequirementDetailId);
                    table.ForeignKey(
                        name: "FK_JobRequirementDetails_JobRequirements_JobRequirementId",
                        column: x => x.JobRequirementId,
                        principalTable: "JobRequirements",
                        principalColumn: "JobRequirementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTables",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    UniversityName = table.Column<string>(maxLength: 200, nullable: true),
                    PassOutYear = table.Column<string>(nullable: false),
                    Branch = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    EducationDetails = table.Column<string>(maxLength: 500, nullable: true),
                    UserTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTables", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTables_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    ContactNo = table.Column<int>(maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    CompanyUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    UserTableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_UserTables_UserTableId",
                        column: x => x.UserTableId,
                        principalTable: "UserTables",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostJobs",
                columns: table => new
                {
                    PostJobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(maxLength: 100, nullable: false),
                    Vacancies = table.Column<int>(nullable: false),
                    PostCreatedAt = table.Column<DateTime>(nullable: false),
                    LastDate = table.Column<DateTime>(nullable: false),
                    Qualification = table.Column<string>(maxLength: 50, nullable: false),
                    MinSalary = table.Column<int>(nullable: false),
                    MaxSalary = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    WebUrl = table.Column<string>(nullable: true),
                    JoRequirementId = table.Column<int>(nullable: false),
                    JobStatusId = table.Column<int>(nullable: false),
                    JobDescription = table.Column<string>(maxLength: 500, nullable: true),
                    JobNatureId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostJobs", x => x.PostJobId);
                    table.ForeignKey(
                        name: "FK_PostJobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostJobs_JobRequirements_JoRequirementId",
                        column: x => x.JoRequirementId,
                        principalTable: "JobRequirements",
                        principalColumn: "JobRequirementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostJobs_JobNatures_JobNatureId",
                        column: x => x.JobNatureId,
                        principalTable: "JobNatures",
                        principalColumn: "JobNatureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostJobs_JobStatuses_JobStatusId",
                        column: x => x.JobStatusId,
                        principalTable: "JobStatuses",
                        principalColumn: "JobStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostJobs_UserTables_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTables",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    ApplyJobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ContactNo = table.Column<int>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AppliedAt = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    JobNatureId = table.Column<int>(nullable: false),
                    JobCategoryId = table.Column<int>(nullable: false),
                    JobStatusId = table.Column<int>(nullable: false),
                    PostJobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.ApplyJobId);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_JobNatures_JobNatureId",
                        column: x => x.JobNatureId,
                        principalTable: "JobNatures",
                        principalColumn: "JobNatureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_JobStatuses_JobStatusId",
                        column: x => x.JobStatusId,
                        principalTable: "JobStatuses",
                        principalColumn: "JobStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_PostJobs_PostJobId",
                        column: x => x.PostJobId,
                        principalTable: "PostJobs",
                        principalColumn: "PostJobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_UserTables_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTables",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_CompanyId",
                table: "ApplyJobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobCategoryId",
                table: "ApplyJobs",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobNatureId",
                table: "ApplyJobs",
                column: "JobNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobStatusId",
                table: "ApplyJobs",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_PostJobId",
                table: "ApplyJobs",
                column: "PostJobId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_UserId",
                table: "ApplyJobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserTableId",
                table: "Companies",
                column: "UserTableId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirementDetails_JobRequirementId",
                table: "JobRequirementDetails",
                column: "JobRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_JobRequirementId1",
                table: "JobRequirements",
                column: "JobRequirementId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostJobs_CompanyId",
                table: "PostJobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PostJobs_JoRequirementId",
                table: "PostJobs",
                column: "JoRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_PostJobs_JobNatureId",
                table: "PostJobs",
                column: "JobNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PostJobs_JobStatusId",
                table: "PostJobs",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PostJobs_UserId",
                table: "PostJobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_UserTypeId",
                table: "UserTables",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobs");

            migrationBuilder.DropTable(
                name: "JobRequirementDetails");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "PostJobs");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "JobRequirements");

            migrationBuilder.DropTable(
                name: "JobNatures");

            migrationBuilder.DropTable(
                name: "JobStatuses");

            migrationBuilder.DropTable(
                name: "UserTables");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
