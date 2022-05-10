using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    public partial class AddedDataFormatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "DataFormatId",
            //    table: "contractConfigs",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "DataFormats",
            //    columns: table => new
            //    {
            //        DataFormatId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DataFormats", x => x.DataFormatId);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_contractConfigs_DataFormatId",
            //    table: "contractConfigs",
            //    column: "DataFormatId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_contractConfigs_DataFormats_DataFormatId",
            //    table: "contractConfigs",
            //    column: "DataFormatId",
            //    principalTable: "DataFormats",
            //    principalColumn: "DataFormatId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_contractConfigs_DataFormats_DataFormatId",
            //    table: "contractConfigs");

            //migrationBuilder.DropTable(
            //    name: "DataFormats");

            //migrationBuilder.DropIndex(
            //    name: "IX_contractConfigs_DataFormatId",
            //    table: "contractConfigs");

            //migrationBuilder.DropColumn(
            //    name: "DataFormatId",
            //    table: "contractConfigs");
        }
    }
}
