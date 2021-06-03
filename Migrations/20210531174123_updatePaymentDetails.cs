using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendUsers.Migrations
{
    public partial class updatePaymentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PaymentDetails",
                newName: "PaymentName");

            migrationBuilder.AddColumn<double>(
                name: "cost",
                table: "PaymentDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "PaymentName",
                table: "PaymentDetails",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNum",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
