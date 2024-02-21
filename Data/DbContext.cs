using Microsoft.EntityFrameworkCore;

namespace Projekt.Data 
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

    }
}