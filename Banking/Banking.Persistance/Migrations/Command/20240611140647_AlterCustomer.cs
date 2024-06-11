using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.Persistance.Migrations.Command
{
    /// <inheritdoc />
    public partial class AlterCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Customers",
                newName: "CustomerNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                table: "Customers",
                newName: "AccountNumber");
        }
    }
}
