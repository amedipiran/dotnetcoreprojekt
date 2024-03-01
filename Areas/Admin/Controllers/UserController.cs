using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt.Data;
using Projekt.Models;
using Projekt.Models.ViewModels;
using Projekt.Repository;
using Projekt.Repository.IRepository;
using Projekt.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;




namespace Projekt.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {

            return View();
        }



        //API för att skicka data till Cloudtables
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u => u.Company).ToList();
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

                if (user.Company == null)
                {
                    user.Company = new()
                    {
                        Name = ""
                    };
                }
            }


            return Json(new { data = objUserList });

        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Gick inte att låsa/låsa upp" });
            }

            if(objFromDb.LockoutEnd != null && objFromDb.LockoutEnd> DateTime.Now) {
                objFromDb.LockoutEnd = DateTime.Now;
            } else {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _db.SaveChanges();

            return Json(new { success = true, message = "Operationen lyckades." });
        }

        #endregion

    }
}