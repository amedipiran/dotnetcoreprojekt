using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using Projekt.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        // Konstruktor för att injicera beroenden
        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            // Säkerställer att databasen är uppdaterad
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Logga fel på ett korrekt sätt här, t.ex. med en logger.
                // Exempel: _logger.LogError($"Ett fel uppstod vid databasmigration: {ex.Message}");
            }

            // Skapa roller om de inte finns
            CreateRoles().GetAwaiter().GetResult();

            // Skapa adminanvändaren om den inte finns
            CreateAdminUser().GetAwaiter().GetResult();
        }

        private async Task CreateRoles()
        {
            // En lista med alla roller som ska skapas
            var roles = new List<string> { SD.Role_Customer, SD.Role_Company, SD.Role_Employee, SD.Role_Admin };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private async Task CreateAdminUser()
        {
            // Kontrollera om en användare med adminrollen redan finns för att undvika duplicering
            var adminExists = await _userManager.GetUsersInRoleAsync(SD.Role_Admin);
            if (!adminExists.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@booksanctuary.com",
                    Email = "admin@booksanctuary.com",
                    Name = "Admin Admin",
                    PhoneNumber = "0733377733",
                    StreetAddress = "Admingatan 9a",
                    State = "Östergötland",
                    City = "Norrköping",
                    PostalCode = "60247"
                };

                var createUserResult = await _userManager.CreateAsync(user, "Admin123*");
                if (createUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, SD.Role_Admin);
                }
                else
                {
                    // Felhantering här, t.ex. logga fel
                    // Exempel: _logger.LogError($"Misslyckades med att skapa adminanvändaren: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
