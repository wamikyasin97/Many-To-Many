using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core_Conventions_One_to_One.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_studentId",
                table: "Addresses",
                column: "studentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Students_studentId",
                table: "Addresses",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Students_studentId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_studentId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Addresses");
        }
    }
}
