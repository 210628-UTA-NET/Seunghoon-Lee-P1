using Microsoft.EntityFrameworkCore.Migrations;

namespace Seunghoon_Lee_P1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    BrandId = table.Column<string>(maxLength: 10, nullable: false),
                    CategoryId = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 40, nullable: false),
                    Street = table.Column<string>(maxLength: 40, nullable: false),
                    City = table.Column<string>(maxLength: 40, nullable: false),
                    StateId = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Stores_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => new { x.StoreId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { "FD", "Fender" },
                    { "GS", "Gibson" },
                    { "PR", "PRS" },
                    { "IB", "Ibanez" },
                    { "SQ", "Squire" },
                    { "MT", "Martin" },
                    { "TL", "Taylor" },
                    { "GR", "Gretch" },
                    { "YM", "Yamaha" },
                    { "EP", "Epiphone" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "CN", "Classic & Nylon guitars" },
                    { "A", "Acoustic Guitasr" },
                    { "SHE", "Semi-Hollow Body Electric Guitars" },
                    { "HE", "Hollow Body Electric Guitars" },
                    { "SE", "Solid Body Electric Guitars" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Name" },
                values: new object[,]
                {
                    { "OH", "Ohio" },
                    { "MI", "Michigan" },
                    { "IN", "Indiana" },
                    { "KY", "Kentucky" },
                    { "WV", "West Virginia" },
                    { "VA", "Virginia" },
                    { "PA", "Pennsylvania" },
                    { "NY", "New York" },
                    { "NJ", "New Jersey" },
                    { "MD", "Maryland" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "GS", "SE", "Les Paul Standard", 2499.9899999999998 },
                    { 15, "YM", "CN", "Nylon String Silent", 699.99000000000001 },
                    { 14, "TL", "CN", "Academy 12e-N Grand Concert", 799.99000000000001 },
                    { 13, "YM", "CN", "C40", 149.99000000000001 },
                    { 16, "FD", "A", "CC-60S Concert", 219.99000000000001 },
                    { 9, "TL", "A", "314ce-K Special Edition", 2799.9899999999998 },
                    { 8, "MT", "A", "D-28 Standard Dreadnought", 2999.9899999999998 },
                    { 12, "PR", "SHE", "CE 24", 2239.9899999999998 },
                    { 11, "EP", "HE", "Casino", 649.99000000000001 },
                    { 20, "FD", "SE", "Player Telecaster Maple Fingerboard", 749.99000000000001 },
                    { 10, "GR", "HE", "G2420T Streamliner Single Cutaway", 549.99000000000001 },
                    { 18, "EP", "SE", "SG Traditional Pro", 449.99000000000001 },
                    { 17, "FD", "SE", "2004 SRV Number 1 Tribute", 46999.989999999998 },
                    { 7, "SQ", "SE", "Affinity Series Stratocaster HH", 249.99000000000001 },
                    { 6, "IB", "SE", "Premium S1070PBZ", 1399.99 },
                    { 5, "PR", "SE", "SE Custom 24", 899.99000000000001 },
                    { 4, "FD", "SE", "Player Stratocaster", 749.99000000000001 },
                    { 3, "FD", "SE", "American Professional Stratocaster", 1499.99 },
                    { 2, "GS", "SE", "Les Paul Classic", 1999.99 },
                    { 19, "GS", "SE", "Les Paul Studio", 1499.99 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "City", "Email", "Name", "PhoneNumber", "StateId", "Street" },
                values: new object[,]
                {
                    { 2, "Detroit", "abreem4@mashable.com", "LCG Michigan", "734-610-3688", "MI", "6313 Prentice Hill" },
                    { 1, "Warren", "ecordingly2@netscape.com", "LCG Ohio", "330-769-3729", "OH", "068 Village Crossing" },
                    { 3, "Indianapolis", "lknewstub1@yandex.ru", "LCG Indiana", "317-881-7684", "IN", "4729 Boyd Court" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "StoreId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 13, 6 },
                    { 2, 14, 1 },
                    { 2, 15, 8 },
                    { 2, 16, 5 },
                    { 2, 17, 1 },
                    { 2, 18, 6 },
                    { 2, 19, 10 },
                    { 2, 20, 1 },
                    { 3, 1, 4 },
                    { 3, 2, 1 },
                    { 3, 3, 6 },
                    { 3, 4, 8 },
                    { 2, 12, 5 },
                    { 3, 5, 2 },
                    { 3, 7, 7 },
                    { 3, 8, 8 },
                    { 3, 9, 4 },
                    { 3, 10, 1 },
                    { 3, 11, 8 },
                    { 3, 12, 3 },
                    { 3, 13, 1 },
                    { 3, 14, 3 },
                    { 3, 15, 8 },
                    { 3, 16, 9 },
                    { 3, 17, 1 },
                    { 3, 18, 9 },
                    { 3, 6, 1 },
                    { 2, 11, 7 },
                    { 2, 10, 8 },
                    { 2, 9, 2 },
                    { 1, 2, 4 },
                    { 1, 3, 2 },
                    { 1, 4, 4 },
                    { 1, 5, 6 },
                    { 1, 6, 7 },
                    { 1, 7, 8 },
                    { 1, 8, 6 },
                    { 1, 9, 9 },
                    { 1, 10, 1 },
                    { 1, 11, 4 },
                    { 1, 12, 3 },
                    { 1, 13, 10 },
                    { 1, 14, 9 },
                    { 1, 15, 10 },
                    { 1, 16, 6 },
                    { 1, 17, 2 },
                    { 1, 18, 1 },
                    { 1, 19, 5 },
                    { 1, 20, 8 },
                    { 2, 1, 4 },
                    { 2, 2, 1 },
                    { 2, 3, 7 },
                    { 2, 4, 4 },
                    { 2, 5, 3 },
                    { 2, 6, 1 },
                    { 2, 7, 3 },
                    { 2, 8, 1 },
                    { 3, 19, 7 },
                    { 3, 20, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StateId",
                table: "Stores",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
