using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcultancyCRM.Migrations
{
    /// <inheritdoc />
    public partial class PKLeadCommentsIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_LeadComments", "LeadComments");
            migrationBuilder.DropColumn("Id", "LeadComments");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LeadComments",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LeadComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
