using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcultancyCRM.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsSalesRepresentative = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeadSource = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AgentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CandidateFirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CandidateLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Result = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VendorID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExamCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExamName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamMonth = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExamYear = table.Column<int>(type: "int", nullable: false),
                    ExamType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CenterName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CenterAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CenterCountry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CenterPhoneNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreditCard = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PaidFeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Delivery = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeadInfoId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedByName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedLeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedLeads_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedLeads_LeadInfo_LeadInfoId",
                        column: x => x.LeadInfoId,
                        principalTable: "LeadInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LeadInfoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TxnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmpName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadComments_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadComments_LeadInfo_LeadInfoId",
                        column: x => x.LeadInfoId,
                        principalTable: "LeadInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedByDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedByName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadStatus_LeadInfo_Id",
                        column: x => x.Id,
                        principalTable: "LeadInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedLeads_EmployeeId",
                table: "AssignedLeads",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedLeads_LeadInfoId",
                table: "AssignedLeads",
                column: "LeadInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadComments_EmployeeID",
                table: "LeadComments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadComments_LeadInfoId",
                table: "LeadComments",
                column: "LeadInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedLeads");

            migrationBuilder.DropTable(
                name: "LeadComments");

            migrationBuilder.DropTable(
                name: "LeadStatus");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LeadInfo");
        }
    }
}
