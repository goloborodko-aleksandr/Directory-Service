using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLocation_departments_department_id",
                table: "DepartmentLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLocation_locations_location_id",
                table: "DepartmentLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPosition_departments_department_id",
                table: "DepartmentPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPosition_positions_position_id",
                table: "DepartmentPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_departments_parent_id",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "DepartmentPosition",
                newName: "DepartmentPositions");

            migrationBuilder.RenameTable(
                name: "DepartmentLocation",
                newName: "DepartmentLocations");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentPosition_position_id",
                table: "DepartmentPositions",
                newName: "IX_DepartmentPositions_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentPosition_department_id",
                table: "DepartmentPositions",
                newName: "IX_DepartmentPositions_department_id");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLocation_location_id",
                table: "DepartmentLocations",
                newName: "IX_DepartmentLocations_location_id");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLocation_department_id",
                table: "DepartmentLocations",
                newName: "IX_DepartmentLocations_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLocations_departments_department_id",
                table: "DepartmentLocations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLocations_locations_location_id",
                table: "DepartmentLocations",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPositions_departments_department_id",
                table: "DepartmentPositions",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPositions_positions_position_id",
                table: "DepartmentPositions",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_departments_parent_id",
                table: "departments",
                column: "parent_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLocations_departments_department_id",
                table: "DepartmentLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLocations_locations_location_id",
                table: "DepartmentLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPositions_departments_department_id",
                table: "DepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentPositions_positions_position_id",
                table: "DepartmentPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_departments_parent_id",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "DepartmentPositions",
                newName: "DepartmentPosition");

            migrationBuilder.RenameTable(
                name: "DepartmentLocations",
                newName: "DepartmentLocation");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentPositions_position_id",
                table: "DepartmentPosition",
                newName: "IX_DepartmentPosition_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentPositions_department_id",
                table: "DepartmentPosition",
                newName: "IX_DepartmentPosition_department_id");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLocations_location_id",
                table: "DepartmentLocation",
                newName: "IX_DepartmentLocation_location_id");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentLocations_department_id",
                table: "DepartmentLocation",
                newName: "IX_DepartmentLocation_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLocation_departments_department_id",
                table: "DepartmentLocation",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLocation_locations_location_id",
                table: "DepartmentLocation",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPosition_departments_department_id",
                table: "DepartmentPosition",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentPosition_positions_position_id",
                table: "DepartmentPosition",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_departments_parent_id",
                table: "departments",
                column: "parent_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
