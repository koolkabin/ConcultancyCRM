using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcultancyCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEmpTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUserEmployees",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserEmployees", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserEmployees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserEmployees_EmployeeId",
                table: "AppUserEmployees",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserEmployees");

            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
