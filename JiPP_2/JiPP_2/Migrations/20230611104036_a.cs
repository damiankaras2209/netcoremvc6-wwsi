using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiPP_2.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransmissionDicId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorDicId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransmissionDicId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VendorDicId",
                table: "Vehicles");
        }
    }
}
