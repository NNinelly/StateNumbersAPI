using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StateNumbersAPI.Migrations
{
    /// <inheritdoc />
    public partial class migr9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookNumbers_customers_CustomerId",
                table: "BookNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderNumbers_customers_CustomerId",
                table: "OrderNumbers");

            migrationBuilder.DropIndex(
                name: "IX_OrderNumbers_CustomerId",
                table: "OrderNumbers");

            migrationBuilder.DropIndex(
                name: "IX_BookNumbers_CustomerId",
                table: "BookNumbers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderNumbers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BookNumbers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "BookNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderNumbers_CustomerId",
                table: "OrderNumbers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookNumbers_CustomerId",
                table: "BookNumbers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookNumbers_customers_CustomerId",
                table: "BookNumbers",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderNumbers_customers_CustomerId",
                table: "OrderNumbers",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
