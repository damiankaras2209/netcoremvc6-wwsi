using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiPP_2.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionDicId",
                table: "Vehicles",
                column: "TransmissionDicId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VendorDicId",
                table: "Vehicles",
                column: "VendorDicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_DictionaryDetails_TransmissionDicId",
                table: "Vehicles",
                column: "TransmissionDicId",
                principalTable: "DictionaryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_DictionaryDetails_VendorDicId",
                table: "Vehicles",
                column: "VendorDicId",
                principalTable: "DictionaryDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_DictionaryDetails_TransmissionDicId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_DictionaryDetails_VendorDicId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TransmissionDicId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VendorDicId",
                table: "Vehicles");
        }
    }
}
