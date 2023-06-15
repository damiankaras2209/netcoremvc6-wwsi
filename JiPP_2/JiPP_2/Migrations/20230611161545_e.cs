using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiPP_2.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Customers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "streetNumber",
                table: "Customers",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Customers",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "postCode",
                table: "Customers",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "pesel",
                table: "Customers",
                newName: "Pesel");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Customers",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Customers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Customers",
                newName: "streetNumber");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Customers",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Customers",
                newName: "postCode");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Pesel",
                table: "Customers",
                newName: "pesel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "city");
        }
    }
}
