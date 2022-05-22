using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    public partial class DataFormatTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ContractDictionary",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DataFormats",
                columns: table => new
                {
                    DataFormatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataFormats", x => x.DataFormatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataFormats");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ContractDictionary");
        }
    }
}
