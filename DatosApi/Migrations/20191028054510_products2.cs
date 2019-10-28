using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Api.Migrations
{
    public partial class products2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveProduct_Products_idProduct1",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveProduct_AspNetUsers_idUserId",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.DropIndex(
                name: "IX_ReserveProduct_idUserId",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.RenameColumn(
                name: "idUserId",
                schema: "dbo",
                table: "ReserveProduct",
                newName: "idUser");

            migrationBuilder.RenameColumn(
                name: "idProduct1",
                schema: "dbo",
                table: "ReserveProduct",
                newName: "ProductsModelidProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveProduct_idProduct1",
                schema: "dbo",
                table: "ReserveProduct",
                newName: "IX_ReserveProduct_ProductsModelidProduct");

            migrationBuilder.AlterColumn<string>(
                name: "idUser",
                schema: "dbo",
                table: "ReserveProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "ReserveProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idProducto",
                schema: "dbo",
                table: "ReserveProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveProduct_ApplicationUserId",
                schema: "dbo",
                table: "ReserveProduct",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveProduct_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "ReserveProduct",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveProduct_Products_ProductsModelidProduct",
                schema: "dbo",
                table: "ReserveProduct",
                column: "ProductsModelidProduct",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveProduct_AspNetUsers_ApplicationUserId",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ReserveProduct_Products_ProductsModelidProduct",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.DropIndex(
                name: "IX_ReserveProduct_ApplicationUserId",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.DropColumn(
                name: "idProducto",
                schema: "dbo",
                table: "ReserveProduct");

            migrationBuilder.RenameColumn(
                name: "idUser",
                schema: "dbo",
                table: "ReserveProduct",
                newName: "idUserId");

            migrationBuilder.RenameColumn(
                name: "ProductsModelidProduct",
                schema: "dbo",
                table: "ReserveProduct",
                newName: "idProduct1");

            migrationBuilder.RenameIndex(
                name: "IX_ReserveProduct_ProductsModelidProduct",
                schema: "dbo",
                table: "ReserveProduct",
                newName: "IX_ReserveProduct_idProduct1");

            migrationBuilder.AlterColumn<string>(
                name: "idUserId",
                schema: "dbo",
                table: "ReserveProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveProduct_idUserId",
                schema: "dbo",
                table: "ReserveProduct",
                column: "idUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveProduct_Products_idProduct1",
                schema: "dbo",
                table: "ReserveProduct",
                column: "idProduct1",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveProduct_AspNetUsers_idUserId",
                schema: "dbo",
                table: "ReserveProduct",
                column: "idUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
