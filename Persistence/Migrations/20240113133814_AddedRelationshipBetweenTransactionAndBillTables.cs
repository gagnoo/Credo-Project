using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipBetweenTransactionAndBillTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillId",
                table: "Transactions",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Bills_BillId",
                table: "Transactions",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Bills_BillId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BillId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Transactions");
        }
    }
}
