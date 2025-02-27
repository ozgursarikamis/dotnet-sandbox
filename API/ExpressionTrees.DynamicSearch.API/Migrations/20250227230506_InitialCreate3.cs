using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressionTrees.DynamicSearch.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "Country");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Employees",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Employees",
                newName: "Name");
        }
    }
}
