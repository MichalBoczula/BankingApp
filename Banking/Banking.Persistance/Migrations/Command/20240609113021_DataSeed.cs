using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Banking.Persistance.Migrations.Command
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountNumber", "PersonalDataId" },
                values: new object[,]
                {
                    { 1, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 1 },
                    { 2, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 2 },
                    { 3, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BuildingNumber", "City", "CustomerId", "FlatNumber", "PostCode", "Street", "VerificationStatus" },
                values: new object[,]
                {
                    { 1, "1", "CityA", 1, "101", "10001", "123 Main St", 1 },
                    { 2, "2", "CityB", 2, "202", "10002", "456 Elm St", 1 },
                    { 3, "3", "CityC", 3, "303", "10003", "789 Oak St", 1 }
                });

            migrationBuilder.InsertData(
                table: "BankingAccounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "Balance", "CustomerId" },
                values: new object[,]
                {
                    { 1, "ACC001", 2, 1000.00m, 1 },
                    { 2, "ACC002", 2, 2000.00m, 2 },
                    { 3, "ACC003", 2, 3000.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CustomerId", "VerificationStatus" },
                values: new object[,]
                {
                    { 1, "customer1@example.com", 1, 1 },
                    { 2, "customer2@example.com", 2, 1 },
                    { 3, "customer3@example.com", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "PersonalData",
                columns: new[] { "Id", "CustomerId", "DateOfBirth", "DocumentType", "FirstName", "IdentityNumber", "LastName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "John", "1234567890", "Doe" },
                    { 2, 2, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jane", "0987654321", "Smith" },
                    { 3, 3, new DateTime(1980, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alice", "1122334455", "Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "CountryCode", "CustomerId", "Number", "VerificationStatus" },
                values: new object[,]
                {
                    { 1, "+1", 1, "123456789", 1 },
                    { 2, "+1", 2, "987654321", 1 },
                    { 3, "+1", 3, "555666777", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BankingAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankingAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BankingAccounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonalData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonalData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonalData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
