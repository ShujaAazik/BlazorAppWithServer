using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    public partial class DataFormatA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataFormatId",
                table: "ContractDictionary",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ContractDictionary_DataFormatId",
                table: "ContractDictionary",
                column: "DataFormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractDictionary_DataFormats_DataFormatId",
                table: "ContractDictionary",
                column: "DataFormatId",
                principalTable: "DataFormats",
                principalColumn: "DataFormatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractDictionary_DataFormats_DataFormatId",
                table: "ContractDictionary");

            migrationBuilder.DropIndex(
                name: "IX_ContractDictionary_DataFormatId",
                table: "ContractDictionary");

            migrationBuilder.DropColumn(
                name: "DataFormatId",
                table: "ContractDictionary");
        }
    }
}
