using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 8, 20, 21, 5, 405, DateTimeKind.Local).AddTicks(160), false, "Small Frozen Shoes", null },
                    { 2, new DateTime(2025, 9, 8, 20, 21, 5, 405, DateTimeKind.Local).AddTicks(260), false, "Fantastic Fresh Bacon", null },
                    { 3, new DateTime(2025, 9, 8, 20, 21, 5, 405, DateTimeKind.Local).AddTicks(270), false, "Handcrafted Soft Pants", null },
                    { 4, new DateTime(2025, 9, 8, 20, 21, 5, 405, DateTimeKind.Local).AddTicks(280), true, "Refined Fresh Ball", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priority", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 8, 20, 21, 5, 406, DateTimeKind.Local).AddTicks(6400), false, "Elektronik", 0, 1, null },
                    { 2, new DateTime(2025, 9, 8, 20, 21, 5, 406, DateTimeKind.Local).AddTicks(6430), false, "Moda", 0, 1, null },
                    { 3, new DateTime(2025, 9, 8, 20, 21, 5, 406, DateTimeKind.Local).AddTicks(6430), false, "Bilgisayar", 1, 1, null },
                    { 4, new DateTime(2025, 9, 8, 20, 21, 5, 406, DateTimeKind.Local).AddTicks(6440), false, "Kadın Giyim", 2, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 8, 20, 21, 5, 408, DateTimeKind.Local).AddTicks(4860), "Adipisci qui molestiae hesap deleniti.", false, "Sıla ipsa layıkıyla yapacakmış laboriosam.", null },
                    { 2, 2, new DateTime(2025, 9, 8, 20, 21, 5, 408, DateTimeKind.Local).AddTicks(4970), "Qui yapacakmış bundan sıfat kapının magnam sarmal sequi lakin veritatis.", false, "Sıradanlıktan consequuntur.", null },
                    { 3, 3, new DateTime(2025, 9, 8, 20, 21, 5, 408, DateTimeKind.Local).AddTicks(5030), "Ama türemiş sed dağılımı accusantium nisi ki yapacakmış çakıl quis mıknatıslı ad ekşili tempora consectetur.", false, "Non quae ki.", null },
                    { 4, 4, new DateTime(2025, 9, 8, 20, 21, 5, 408, DateTimeKind.Local).AddTicks(5070), "Un ea praesentium quam okuma ki kapının consectetur bahar ullam accusantium için mıknatıslı salladı göze sit yapacakmış camisi velit aut.", true, "Dergi koştum öyle fugit.", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 8, 20, 21, 5, 409, DateTimeKind.Local).AddTicks(6320), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 68.085818668114120m, false, 486.60m, "Tasty Rubber Chicken", null },
                    { 2, 2, new DateTime(2025, 9, 8, 20, 21, 5, 409, DateTimeKind.Local).AddTicks(6670), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 12.2766549255706690m, false, 517.30m, "Intelligent Plastic Fish", null },
                    { 3, 3, new DateTime(2025, 9, 8, 20, 21, 5, 409, DateTimeKind.Local).AddTicks(6700), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 20.474008385462020m, false, 339.62m, "Handcrafted Cotton Cheese", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
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
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
