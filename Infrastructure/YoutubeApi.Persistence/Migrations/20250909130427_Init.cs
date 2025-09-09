using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProdctId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProdctId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProdctId",
                        column: x => x.ProdctId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 9, 16, 4, 27, 456, DateTimeKind.Local).AddTicks(7300), false, "Handcrafted Granite Computer", null },
                    { 2, new DateTime(2025, 9, 9, 16, 4, 27, 456, DateTimeKind.Local).AddTicks(7390), false, "Licensed Frozen Pizza", null },
                    { 3, new DateTime(2025, 9, 9, 16, 4, 27, 456, DateTimeKind.Local).AddTicks(7400), false, "Intelligent Plastic Table", null },
                    { 4, new DateTime(2025, 9, 9, 16, 4, 27, 456, DateTimeKind.Local).AddTicks(7420), true, "Awesome Frozen Hat", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priority", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 9, 16, 4, 27, 459, DateTimeKind.Local).AddTicks(2800), false, "Elektronik", 0, 1, null },
                    { 2, new DateTime(2025, 9, 9, 16, 4, 27, 459, DateTimeKind.Local).AddTicks(2830), false, "Moda", 0, 1, null },
                    { 3, new DateTime(2025, 9, 9, 16, 4, 27, 459, DateTimeKind.Local).AddTicks(2830), false, "Bilgisayar", 1, 1, null },
                    { 4, new DateTime(2025, 9, 9, 16, 4, 27, 459, DateTimeKind.Local).AddTicks(2830), false, "Kadın Giyim", 2, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 9, 16, 4, 27, 460, DateTimeKind.Local).AddTicks(4230), "Umut sinema quis ama quia.", false, "Nostrum çorba eum lakin olduğu.", null },
                    { 2, 2, new DateTime(2025, 9, 9, 16, 4, 27, 460, DateTimeKind.Local).AddTicks(4380), "Lakin ex aut voluptatem de ea beatae velit dağılımı teldeki.", false, "Gidecekmiş architecto.", null },
                    { 3, 3, new DateTime(2025, 9, 9, 16, 4, 27, 460, DateTimeKind.Local).AddTicks(4420), "Iusto ki bilgiyasayarı aperiam ama çobanın minima quis dolores değerli voluptatum ipsum consequuntur ışık sequi.", false, "Koştum commodi incidunt.", null },
                    { 4, 4, new DateTime(2025, 9, 9, 16, 4, 27, 460, DateTimeKind.Local).AddTicks(4460), "Aut batarya koştum sarmal aliquam orta aliquam bilgisayarı voluptatem değerli ve qui fugit duyulmamış ipsam öyle biber laudantium veritatis quasi.", true, "Layıkıyla incidunt çünkü numquam.", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { -3, 3, new DateTime(2025, 9, 9, 16, 4, 27, 462, DateTimeKind.Local).AddTicks(2430), "The Football Is Good For Training And Recreational Purposes", 26.640805074917770m, false, 936.00m, "Licensed Fresh Bacon", null },
                    { -2, 2, new DateTime(2025, 9, 9, 16, 4, 27, 462, DateTimeKind.Local).AddTicks(1420), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 50.972071874505670m, false, 939.94m, "Gorgeous Rubber Ball", null },
                    { -1, 1, new DateTime(2025, 9, 9, 16, 4, 27, 462, DateTimeKind.Local).AddTicks(1210), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 32.106276223393960m, false, 43.79m, "Refined Cotton Soap", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
