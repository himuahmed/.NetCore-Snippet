using Microsoft.EntityFrameworkCore.Migrations;

namespace storeApp.Migrations
{
    public partial class AddedOutletTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutletId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Outlets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OutletId",
                table: "Items",
                column: "OutletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Outlets_OutletId",
                table: "Items",
                column: "OutletId",
                principalTable: "Outlets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Outlets_OutletId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Outlets");

            migrationBuilder.DropIndex(
                name: "IX_Items_OutletId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OutletId",
                table: "Items");
        }
    }
}
