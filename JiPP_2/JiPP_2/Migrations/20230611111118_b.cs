using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiPP_2.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_DictionaryDetails_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_DictionaryDetails_VendorId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VendorId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VendorId",
                table: "Vehicles",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_DictionaryDetails_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "DictionaryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_DictionaryDetails_VendorId",
                table: "Vehicles",
                column: "VendorId",
                principalTable: "DictionaryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
