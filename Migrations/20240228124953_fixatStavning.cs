using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class fixatStavning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymenDueDate",
                table: "OrderHeaders",
                newName: "PaymentDueDate");

            migrationBuilder.RenameColumn(
                name: "PaymenDate",
                table: "OrderHeaders",
                newName: "PaymentDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDueDate",
                table: "OrderHeaders",
                newName: "PaymenDueDate");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "OrderHeaders",
                newName: "PaymenDate");
        }
    }
}
