using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data 
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

    public DbSet<Category> Categories { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Category>().HasData(
                    new Category {Id=1, Name="Pants", DisplayOrder=1},
                    new Category {Id=2, Name="T-Shirts", DisplayOrder=2}, new Category {Id=3, Name="Shirts", DisplayOrder=3},
                    new Category {Id=4, Name="SweatShirts", DisplayOrder=4}

                );
        }

    }
}