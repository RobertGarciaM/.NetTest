using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Api.Migrations
{
    public partial class products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    idProduct = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    amount = table.Column<int>(nullable: false),
                    avalaible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.idProduct);
                });

            migrationBuilder.CreateTable(
                name: "ReserveProduct",
                schema: "dbo",
                columns: table => new
                {
                    idReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    delete = table.Column<bool>(nullable: false),
                    idProduct1 = table.Column<int>(nullable: true),
                    idUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveProduct", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_ReserveProduct_Products_idProduct1",
                        column: x => x.idProduct1,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReserveProduct_AspNetUsers_idUserId",
                        column: x => x.idUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReserveProduct_idProduct1",
                schema: "dbo",
                table: "ReserveProduct",
                column: "idProduct1");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveProduct_idUserId",
                schema: "dbo",
                table: "ReserveProduct",
                column: "idUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveProduct",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");
        }
    }
}
