using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcultancyCRM.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAssetAssignmentRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsItemsAssigned",
                table: "AssetsItemsAssigned");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AssetsItemsAssigned",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsItemsAssigned",
                table: "AssetsItemsAssigned",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsItemsAssigned_AssetsId",
                table: "AssetsItemsAssigned",
                column: "AssetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsItemsAssigned",
                table: "AssetsItemsAssigned");

            migrationBuilder.DropIndex(
                name: "IX_AssetsItemsAssigned_AssetsId",
                table: "AssetsItemsAssigned");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AssetsItemsAssigned");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsItemsAssigned",
                table: "AssetsItemsAssigned",
                column: "AssetsId");
        }
    }
}
