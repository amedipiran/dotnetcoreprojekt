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
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u=>u.Company).ToList();
            foreach(var user in objUserList) {
                if(user.Company == null) {
                    user.Company = new() {
                        Name =""
                    };
                }
            }


            return Json(new { data = objUserList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
           

            return Json(new { success = true, message = "Raderingen lyckades." });
        }

        #endregion

    }
}