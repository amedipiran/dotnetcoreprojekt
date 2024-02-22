using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data 
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

    public DbSet<Category> Categories { get; set;}
    public DbSet<Product> Products { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Category>().HasData(
                    new Category {Id=1, Name="Sneakers", DisplayOrder=1},
                    new Category {Id=2, Name="Arbetsskor", DisplayOrder=2}, new Category {Id=3, Name="Stövlar", DisplayOrder=3},
                    new Category {Id=4, Name="Fritidsskor", DisplayOrder=4}

                );
          modelBuilder.Entity<Product>().HasData(
    new Product {
        Id = 1,
        Title = "Air Force 1",
        Description = "Nike Air Force 1 är en legendarisk basketsko som först introducerades 1982 och är känd för att vara den första basketskon som använder Nike Air-teknologin. Denna innovation erbjuder överlägsen dämpning och stöd, vilket har bidragit till skons rykte på basketplanen och dess långvariga popularitet utanför den.",
        Brand = "Nike",
        Price = 1000, 
        ListPrice = 900,
        Price50 = 800,
        Price100 = 700,
        CategoryId = 1,
        ImageUrl = ""

    },
    new Product {
    Id = 2,
    Title = "Blazer Mid '77",
    Description = "Nike Blazer Mid '77 fångar den gamla skolans charm av basket med dess vintagestil och klassiska design. Skon har en robust konstruktion med en överdel i läder och mocka, kompletterat med en retro Swoosh-logotyp för en autentisk look. Dess simpla men stiliga utseende har gjort den till en favorit både på och utanför basketplanen.",
    Brand = "Nike",
    Price = 1100,
    ListPrice = 1000,
    Price50 = 900,
    Price100 = 800,
        CategoryId = 1,
        ImageUrl = ""


},

    new Product {
        Id = 3,
        Title = "Campus",
        Description = "Adidas Campus är en ikonisk sneaker som ursprungligen lanserades på 1980-talet. Den är känd för sin låga profil, enkla design och hållbarhet, vilket gjort den till en favorit både inom skatekulturen och som en vardagssko.",
        Brand = "Adidas",
        Price = 1249, 
        ListPrice = 1149,
        Price50 = 1049,
        Price100 = 849,
        CategoryId = 1,
        ImageUrl = ""

    },
    new Product {
    Id = 4,
    Title = "Stan Smith",
    Description = "Adidas Stan Smith är en tidlös tennissko som först släpptes på 1970-talet. Med sin minimalistiska design och signaturdetaljer som de perforerade tre ränderna och porträttet av Stan Smith på tungan, har denna sko blivit en ikon inom modevärlden. Dess låga profil och enkla estetik gör den till en mångsidig sko som passar till nästan allt.",
    Brand = "Adidas",
    Price = 950,
    ListPrice = 850,
    Price50 = 750,
    Price100 = 650,
        CategoryId = 1,
        ImageUrl = ""


}


);

        }

    }
}