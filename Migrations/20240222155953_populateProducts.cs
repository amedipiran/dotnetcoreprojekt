﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class populateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ListPrice = table.Column<double>(type: "REAL", nullable: false),
                    Price50 = table.Column<double>(type: "REAL", nullable: false),
                    Price100 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Nike", "Nike Air Force 1 är en legendarisk basketsko som först introducerades 1982 och är känd för att vara den första basketskon som använder Nike Air-teknologin. Denna innovation erbjuder överlägsen dämpning och stöd, vilket har bidragit till skons rykte på basketplanen och dess långvariga popularitet utanför den.", 900.0, 1000.0, 700.0, 800.0, "Air Force 1" },
                    { 2, "Nike", "Nike Blazer Mid '77 fångar den gamla skolans charm av basket med dess vintagestil och klassiska design. Skon har en robust konstruktion med en överdel i läder och mocka, kompletterat med en retro Swoosh-logotyp för en autentisk look. Dess simpla men stiliga utseende har gjort den till en favorit både på och utanför basketplanen.", 1000.0, 1100.0, 800.0, 900.0, "Blazer Mid '77" },
                    { 3, "Adidas", "Adidas Campus är en ikonisk sneaker som ursprungligen lanserades på 1980-talet. Den är känd för sin låga profil, enkla design och hållbarhet, vilket gjort den till en favorit både inom skatekulturen och som en vardagssko.", 1149.0, 1249.0, 849.0, 1049.0, "Campus" },
                    { 4, "Adidas", "Adidas Stan Smith är en tidlös tennissko som först släpptes på 1970-talet. Med sin minimalistiska design och signaturdetaljer som de perforerade tre ränderna och porträttet av Stan Smith på tungan, har denna sko blivit en ikon inom modevärlden. Dess låga profil och enkla estetik gör den till en mångsidig sko som passar till nästan allt.", 850.0, 950.0, 650.0, 750.0, "Stan Smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
