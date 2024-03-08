using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobileShop.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    ShopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanhGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.ShopID);
                });

            migrationBuilder.CreateTable(
                name: "ShopCart",
                columns: table => new
                {
                    ShopCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCart", x => x.ShopCartID);
                });

            migrationBuilder.CreateTable(
                name: "ShopProduct",
                columns: table => new
                {
                    ShopProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanhGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProduct", x => x.ShopProductID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ShopCartDetails",
                columns: table => new
                {
                    ShopCartDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShopCartID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartDetails", x => x.ShopCartDetailID);
                    table.ForeignKey(
                        name: "FK_ShopCartDetails_ShopCart_ShopCartID",
                        column: x => x.ShopCartID,
                        principalTable: "ShopCart",
                        principalColumn: "ShopCartID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartDetails_ShopCartID",
                table: "ShopCartDetails",
                column: "ShopCartID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "ShopCartDetails");

            migrationBuilder.DropTable(
                name: "ShopProduct");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ShopCart");
        }
    }
}
