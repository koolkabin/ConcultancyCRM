using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcultancyCRM.Migrations
{
    /// <inheritdoc />
    public partial class relationshipEmployeeDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetsItemsAssigned_Department_DepartmentId",
                table: "AssetsItemsAssigned");

            migrationBuilder.DropIndex(
                name: "IX_AssetsItemsAssigned_DepartmentId",
                table: "AssetsItemsAssigned");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AssetsItemsAssigned");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AssetsItemsAssigned",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetsItemsAssigned_DepartmentId",
                table: "AssetsItemsAssigned",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsItemsAssigned_Department_DepartmentId",
                table: "AssetsItemsAssigned",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }
    }
}
