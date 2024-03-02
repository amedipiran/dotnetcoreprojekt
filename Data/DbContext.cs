using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "SciFi", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Romantik", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Deckare", DisplayOrder = 4 }
            );


            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 2, Name = "BookWorld", StreetAddress = "Läsargatan 5", City = "Stockholm", State = "Stockholm", PostalCode = "12345", PhoneNumber = "08-1234567" },
                new Company { Id = 3, Name = "Reader's Haven", StreetAddress = "Bokvägen 10", City = "Göteborg", State = "Västra Götaland", PostalCode = "54321", PhoneNumber = "031-7654321" }
            );

            modelBuilder.Entity<Product>().HasData(
   new Product
   {
       Id = 1,
       Title = "Dune",
       Description = "Dune är en science fiction-roman skriven av Frank Herbert. Den utspelar sig i en avlägsen framtid där människan har koloniserat flera planeter och strider om kontrollen över en ökenplanet vid namn Arrakis. Boken följer Paul Atreides, en ung adelsman, när han navigerar genom politik, religion och intriger på Arrakis.",
       Author = "Frank Herbert",
       Price = 100,
       ListPrice = 90,
       Price50 = 80,
       Price100 = 70,
       CategoryId = 1,
   },
  new Product
  {
      Id = 2,
      Title = "Dune Messiah",
      Description = "Dune Messiah är uppföljaren till Frank Herberts roman Dune. Boken utforskar konsekvenserna av händelserna i den första boken och följer Paul Atreides, nu känd som Muad'Dib, när han navigerar genom politiska och religiösa utmaningar på Arrakis och i galaxen.",
      Author = "Frank Herbert",
      Price = 110,
      ListPrice = 100,
      Price50 = 90,
      Price100 = 80,
      CategoryId = 1,

  },
  new Product
  {
      Id = 3,
      Title = "Children of Dune",
      Description = "Children of Dune är den tredje boken i Frank Herberts Dune-serie. Handlingen kretsar kring Paul Atreides barn, Leto II och Ghanima, när de konfronterar hot från både yttre och inre fiender medan de navigerar genom sin roll i Atreides arv och på Arrakis.",
      Author = "Frank Herbert",
      Price = 120,
      ListPrice = 110,
      Price50 = 100,
      Price100 = 90,
      CategoryId = 1,

  },
  new Product
  {
      Id = 4,
      Title = "God Emperor of Dune",
      Description = "God Emperor of Dune är den fjärde boken i Frank Herberts Dune-serie. Handlingen äger rum tusentals år efter händelserna i de tidigare böckerna och fokuserar på Leto II, son till Paul Atreides, som nu styr över Arrakis som en gudlik kejsare.",
      Author = "Frank Herbert",
      Price = 130,
      ListPrice = 120,
      Price50 = 110,
      Price100 = 100,
      CategoryId = 1,

  },
  new Product
  {
      Id = 5,
      Title = "Heretics of Dune",
      Description = "Heretics of Dune är den femte boken i Frank Herberts Dune-serie. Handlingen följer en grupp rebeller och dissidenter som kämpar mot det etablerade imperiets tyranni och religiösa dogmer på Arrakis och i den omgivande galaxen.",
      Author = "Frank Herbert",
      Price = 140,
      ListPrice = 130,
      Price50 = 120,
      Price100 = 110,
      CategoryId = 1,

  },
  new Product
  {
      Id = 6,
      Title = "Chapterhouse: Dune",
      Description = "Chapterhouse: Dune är den sjätte och sista boken i Frank Herberts Dune-serie. Handlingen kretsar kring intrigerna och konflikterna mellan olika fraktioner som strävar efter kontroll över det sista återstående exemplaret av den heliga kryddan på planeten Chapterhouse.",
      Author = "Frank Herbert",
      Price = 150,
      ListPrice = 140,
      Price50 = 130,
      Price100 = 120,
      CategoryId = 1,



  });

        }

    }
}