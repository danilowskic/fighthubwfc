using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialRaports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false),
                    Expenditure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialRaports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MartialArts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MartialArts", x => x.Id);
                    table.UniqueConstraint("AK_MartialArts_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ContactDataId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ContactDatas_ContactDataId",
                        column: x => x.ContactDataId,
                        principalTable: "ContactDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDatasPhoneNumbers",
                columns: table => new
                {
                    ContactDatasId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumbersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDatasPhoneNumbers", x => new { x.ContactDatasId, x.PhoneNumbersId });
                    table.ForeignKey(
                        name: "FK_ContactDatasPhoneNumbers_ContactDatas_ContactDatasId",
                        column: x => x.ContactDatasId,
                        principalTable: "ContactDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactDatasPhoneNumbers_PhoneNumbers_PhoneNumbersId",
                        column: x => x.PhoneNumbersId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fighters_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NameUser",
                columns: table => new
                {
                    NamesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameUser", x => new { x.NamesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_NameUser_Names_NamesId",
                        column: x => x.NamesId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NameUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfHirement = table.Column<DateOnly>(type: "date", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: false),
                    DoctorLicenceID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FavouriteMartialArtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFans_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevelOfMartialArts",
                columns: table => new
                {
                    FighterId = table.Column<int>(type: "int", nullable: false),
                    MartialArtId = table.Column<int>(type: "int", nullable: false),
                    Belt = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevelOfMartialArts", x => new { x.FighterId, x.MartialArtId });
                    table.ForeignKey(
                        name: "FK_SkillLevelOfMartialArts_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillLevelOfMartialArts_MartialArts_MartialArtId",
                        column: x => x.MartialArtId,
                        principalTable: "MartialArts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    RegistrationEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MoneyPrize = table.Column<double>(type: "float", nullable: false),
                    ReasonOfCancel = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    AvailablePlaces = table.Column<int>(type: "int", nullable: true),
                    TicketPrice = table.Column<double>(type: "float", nullable: true),
                    AudienceType = table.Column<string>(type: "varchar(7)", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_WorkerFans_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "WorkerFans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingBootcamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Belt = table.Column<string>(type: "varchar(11)", nullable: false),
                    MartialArtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingBootcamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingBootcamps_Fighters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingBootcamps_MartialArts_MartialArtName",
                        column: x => x.MartialArtName,
                        principalTable: "MartialArts",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingBootcamps_WorkerFans_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "WorkerFans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFanWorkerFanTypes",
                columns: table => new
                {
                    WorkerFanId = table.Column<int>(type: "int", nullable: false),
                    WorkerFanType = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFanWorkerFanTypes", x => new { x.WorkerFanId, x.WorkerFanType });
                    table.ForeignKey(
                        name: "FK_WorkerFanWorkerFanTypes_WorkerFans_WorkerFanId",
                        column: x => x.WorkerFanId,
                        principalTable: "WorkerFans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FanInvolvements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TicketBuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FanId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanInvolvements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FanInvolvements_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FanInvolvements_WorkerFans_FanId",
                        column: x => x.FanId,
                        principalTable: "WorkerFans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FighterInvolvements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Points = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    EarnedPlace = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Status = table.Column<string>(type: "varchar(8)", nullable: false),
                    FighterId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterInvolvements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FighterInvolvements_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FighterInvolvements_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Events_Id",
                        column: x => x.Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Belt = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Events_Id",
                        column: x => x.Id,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonSubject = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DurationInHours = table.Column<int>(type: "int", nullable: false),
                    TrainingBootcampId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_TrainingBootcamps_TrainingBootcampId",
                        column: x => x.TrainingBootcampId,
                        principalTable: "TrainingBootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingBootcampsStudents",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    TrainingBootcampsAsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingBootcampsStudents", x => new { x.StudentsId, x.TrainingBootcampsAsStudentId });
                    table.ForeignKey(
                        name: "FK_TrainingBootcampsStudents_Fighters_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingBootcampsStudents_TrainingBootcamps_TrainingBootcampsAsStudentId",
                        column: x => x.TrainingBootcampsAsStudentId,
                        principalTable: "TrainingBootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FighterInvolvementId = table.Column<int>(type: "int", nullable: false),
                    WorkerFanId = table.Column<int>(type: "int", nullable: false),
                    FighterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCertificates_FighterInvolvements_FighterInvolvementId",
                        column: x => x.FighterInvolvementId,
                        principalTable: "FighterInvolvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalCertificates_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalCertificates_WorkerFans_WorkerFanId",
                        column: x => x.WorkerFanId,
                        principalTable: "WorkerFans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatas_Email",
                table: "ContactDatas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatasPhoneNumbers_PhoneNumbersId",
                table: "ContactDatasPhoneNumbers",
                column: "PhoneNumbersId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FanInvolvements_EventId",
                table: "FanInvolvements",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_FanInvolvements_FanId",
                table: "FanInvolvements",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterInvolvements_EventId",
                table: "FighterInvolvements",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterInvolvements_FighterId",
                table: "FighterInvolvements",
                column: "FighterId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TrainingBootcampId",
                table: "Lessons",
                column: "TrainingBootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCertificates_FighterId",
                table: "MedicalCertificates",
                column: "FighterId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCertificates_FighterInvolvementId",
                table: "MedicalCertificates",
                column: "FighterInvolvementId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCertificates_WorkerFanId",
                table: "MedicalCertificates",
                column: "WorkerFanId");

            migrationBuilder.CreateIndex(
                name: "IX_NameUser_UsersId",
                table: "NameUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillLevelOfMartialArts_FighterId_MartialArtId",
                table: "SkillLevelOfMartialArts",
                columns: new[] { "FighterId", "MartialArtId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillLevelOfMartialArts_MartialArtId",
                table: "SkillLevelOfMartialArts",
                column: "MartialArtId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBootcamps_MartialArtName",
                table: "TrainingBootcamps",
                column: "MartialArtName");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBootcamps_MasterId",
                table: "TrainingBootcamps",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBootcamps_OrganizerId",
                table: "TrainingBootcamps",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingBootcampsStudents_TrainingBootcampsAsStudentId",
                table: "TrainingBootcampsStudents",
                column: "TrainingBootcampsAsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactDataId",
                table: "Users",
                column: "ContactDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PESEL",
                table: "Users",
                column: "PESEL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDatasPhoneNumbers");

            migrationBuilder.DropTable(
                name: "FanInvolvements");

            migrationBuilder.DropTable(
                name: "FinancialRaports");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "MedicalCertificates");

            migrationBuilder.DropTable(
                name: "NameUser");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "SkillLevelOfMartialArts");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "TrainingBootcampsStudents");

            migrationBuilder.DropTable(
                name: "WorkerFanWorkerFanTypes");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "FighterInvolvements");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "TrainingBootcamps");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Fighters");

            migrationBuilder.DropTable(
                name: "MartialArts");

            migrationBuilder.DropTable(
                name: "WorkerFans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContactDatas");
        }
    }
}
