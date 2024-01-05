using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vb.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                schema: "dbo",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerId",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Customer_CustomerId",
                schema: "dbo",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_EftTransaction_Account_AccountId",
                schema: "dbo",
                table: "EftTransaction");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                schema: "dbo",
                table: "EftTransaction",
                newName: "AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_EftTransaction_AccountId",
                schema: "dbo",
                table: "EftTransaction",
                newName: "IX_EftTransaction_AccountNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "Contact",
                newName: "CustomerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_CustomerId",
                schema: "dbo",
                table: "Contact",
                newName: "IX_Contact_CustomerNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "Address",
                newName: "CustomerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CustomerId",
                schema: "dbo",
                table: "Address",
                newName: "IX_Address_CustomerNumber");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                schema: "dbo",
                table: "AccountTransaction",
                newName: "AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransaction_AccountId",
                schema: "dbo",
                table: "AccountTransaction",
                newName: "IX_AccountTransaction_AccountNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "Account",
                newName: "CustomerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CustomerId",
                schema: "dbo",
                table: "Account",
                newName: "IX_Account_CustomerNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerNumber",
                schema: "dbo",
                table: "Account",
                column: "CustomerNumber",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Account_AccountNumber",
                schema: "dbo",
                table: "AccountTransaction",
                column: "AccountNumber",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerNumber",
                schema: "dbo",
                table: "Address",
                column: "CustomerNumber",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Customer_CustomerNumber",
                schema: "dbo",
                table: "Contact",
                column: "CustomerNumber",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EftTransaction_Account_AccountNumber",
                schema: "dbo",
                table: "EftTransaction",
                column: "AccountNumber",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerNumber",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Account_AccountNumber",
                schema: "dbo",
                table: "AccountTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerNumber",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Customer_CustomerNumber",
                schema: "dbo",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_EftTransaction_Account_AccountNumber",
                schema: "dbo",
                table: "EftTransaction");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                schema: "dbo",
                table: "EftTransaction",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_EftTransaction_AccountNumber",
                schema: "dbo",
                table: "EftTransaction",
                newName: "IX_EftTransaction_AccountId");

            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                schema: "dbo",
                table: "Contact",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_CustomerNumber",
                schema: "dbo",
                table: "Contact",
                newName: "IX_Contact_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                schema: "dbo",
                table: "Address",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CustomerNumber",
                schema: "dbo",
                table: "Address",
                newName: "IX_Address_CustomerId");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                schema: "dbo",
                table: "AccountTransaction",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountTransaction_AccountNumber",
                schema: "dbo",
                table: "AccountTransaction",
                newName: "IX_AccountTransaction_AccountId");

            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                schema: "dbo",
                table: "Account",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CustomerNumber",
                schema: "dbo",
                table: "Account",
                newName: "IX_Account_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                schema: "dbo",
                table: "AccountTransaction",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                schema: "dbo",
                table: "Address",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Customer_CustomerId",
                schema: "dbo",
                table: "Contact",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EftTransaction_Account_AccountId",
                schema: "dbo",
                table: "EftTransaction",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
