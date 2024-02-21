using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data 
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

    public DbSet<Category> Categories { get; set;}

    }
}