using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class rasha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipoperIDShipperID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShipperID",
                table: "Shippers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ShipoperIDShipperID",
                table: "Orders",
                newName: "ShipoperIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipoperIDShipperID",
                table: "Orders",
                newName: "IX_Orders_ShipoperIDID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sub_Catogeries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sub_Catogeries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Product",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippers_ShipoperIDID",
                table: "Orders",
                column: "ShipoperIDID",
                principalTable: "Shippers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipoperIDID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Shippers",
                newName: "ShipperID");

            migrationBuilder.RenameColumn(
                name: "ShipoperIDID",
                table: "Orders",
                newName: "ShipoperIDShipperID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipoperIDID",
                table: "Orders",
                newName: "IX_Orders_ShipoperIDShipperID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sub_Catogeries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sub_Catogeries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippers_ShipoperIDShipperID",
                table: "Orders",
                column: "ShipoperIDShipperID",
                principalTable: "Shippers",
                principalColumn: "ShipperID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
