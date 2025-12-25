using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentDAL.Context.Migrations
{
    /// <inheritdoc />
    public partial class Added_EmployeeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId1");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Employees",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId1",
                table: "Employees",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId1",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId1",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
