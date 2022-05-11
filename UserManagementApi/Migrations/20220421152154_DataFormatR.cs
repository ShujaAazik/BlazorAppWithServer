using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    public partial class DataFormatR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFormatId",
                table: "ContractDictionary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataFormatId",
                table: "ContractDictionary",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
