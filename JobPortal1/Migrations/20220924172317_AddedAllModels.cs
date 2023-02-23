using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace JobPortal1.Migrations
{
    public partial class AddedAllModels : Migration
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
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(maxLength: 50, nullable: false),
                    CountryCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "JobApplyStatuses",
                columns: table => new
                {
                    JobApplyStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobApplyStatusName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplyStatuses", x => x.JobApplyStatusId);
                });

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
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    EmployeeAge = table.Column<int>(nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(nullable: false),
                    Qualification = table.Column<string>(nullable: false),
                    PermanentAddress = table.Column<string>(nullable: false),
                    AttachCV = table.Column<string>(nullable: true),
                    JobReferences = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    JobCategoryId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTables",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(maxLength: 13, nullable: false),
                    UserTypeId = table.Column<int>(nullable: false),
                    AccountStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTables", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTables_AccountStatuses_AccountStatusId",
                        column: x => x.AccountStatusId,
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

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(nullable: true),
                    CertificateAuthority = table.Column<string>(nullable: true),
                    LevelCertification = table.Column<string>(nullable: true),
                    FromYear = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_Certificates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituteName = table.Column<string>(maxLength: 100, nullable: false),
                    TitleOfEducation = table.Column<string>(maxLength: 100, nullable: false),
                    Degree = table.Column<string>(maxLength: 100, nullable: false),
                    FromYear = table.Column<DateTime>(nullable: false),
                    ToYear = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobApplies",
                columns: table => new
                {
                    JobApplyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobApplyDateTime = table.Column<DateTime>(nullable: false),
                    JobApplyStatusUpdateDate = table.Column<DateTime>(nullable: false),
                    JobApplyStatusUpdate = table.Column<string>(maxLength: 200, nullable: true),
                    JobApplyStatusId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplies", x => x.JobApplyId);
                    table.ForeignKey(
                        name: "FK_JobApplies_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplies_JobApplyStatuses_JobApplyStatusId",
                        column: x => x.JobApplyStatusId,
                        principalTable: "JobApplyStatuses",
                        principalColumn: "JobApplyStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(maxLength: 50, nullable: true),
                    Proficiency = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Languages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(maxLength: 500, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    FromYear = table.Column<DateTime>(nullable: false),
                    ToYear = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    ContactNo = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    UserTableUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_UserTables_UserTableUserId",
                        column: x => x.UserTableUserId,
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
                    JoRequirementId = table.Column<int>(nullable: false),
                    JobStatusId = table.Column<int>(nullable: false),
                    JobDescription = table.Column<string>(maxLength: 500, nullable: true),
                    JobNatureId = table.Column<int>(nullable: false),
                    UserTableUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostJobs", x => x.PostJobId);
                    table.ForeignKey(
                        name: "FK_PostJobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostJobs_JobRequirements_JoRequirementId",
                        column: x => x.JoRequirementId,
                        principalTable: "JobRequirements",
                        principalColumn: "JobRequirementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostJobs_JobNatures_JobNatureId",
                        column: x => x.JobNatureId,
                        principalTable: "JobNatures",
                        principalColumn: "JobNatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostJobs_JobStatuses_JobStatusId",
                        column: x => x.JobStatusId,
                        principalTable: "JobStatuses",
                        principalColumn: "JobStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostJobs_UserTables_UserTableUserId",
                        column: x => x.UserTableUserId,
                        principalTable: "UserTables",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_EmployeeId",
                table: "Certificates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserTableUserId",
                table: "Companies",
                column: "UserTableUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CountryId",
                table: "Educations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EmployeeId",
                table: "Educations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplies_EmployeeId",
                table: "JobApplies",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplies_JobApplyStatusId",
                table: "JobApplies",
                column: "JobApplyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirementDetails_JobRequirementId",
                table: "JobRequirementDetails",
                column: "JobRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_JobRequirementId1",
                table: "JobRequirements",
                column: "JobRequirementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_EmployeeId",
                table: "Languages",
                column: "EmployeeId");

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
                name: "IX_PostJobs_UserTableUserId",
                table: "PostJobs",
                column: "UserTableUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_AccountStatusId",
                table: "UserTables",
                column: "AccountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_UserTypeId",
                table: "UserTables",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_CountryId",
                table: "WorkExperiences",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_EmployeeId",
                table: "WorkExperiences",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "JobApplies");

            migrationBuilder.DropTable(
                name: "JobRequirementDetails");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PostJobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "JobApplyStatuses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "JobRequirements");

            migrationBuilder.DropTable(
                name: "JobNatures");

            migrationBuilder.DropTable(
                name: "JobStatuses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "UserTables");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "AccountStatuses");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
