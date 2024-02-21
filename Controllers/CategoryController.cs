using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class CategoryController : Controller {

private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() {

            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
            public IActionResult Create(Category obj) {
                if (obj.Name != null && obj.Name == obj.DisplayOrder.ToString()){
                    ModelState.AddModelError("name", "Ordningen kan inte matcha namnfältet.");
                }
                   if (obj.Name != null && obj.Name.ToLower() == "test"){
                    ModelState.AddModelError("", "Test är ett ogiltigt värde.");
                }
                if(ModelState.IsValid) {
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            return View(obj);
        }

         public IActionResult Edit(int? id) {
            if(id == null || id == 0){
                return NotFound();
            }

            Category? CategoryFromDb = _db.Categories.Find(id);
           

            if (CategoryFromDb == null){
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
            public IActionResult Edit(Category obj) {
           
                if(ModelState.IsValid) {
                    _db.Categories.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            return View(obj);
        }
    public IActionResult Delete(int? id) {
            if(id == null || id == 0){
                return NotFound();
            }

            Category? CategoryFromDb = _db.Categories.Find(id);
           

            if (CategoryFromDb == null){
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id) {
           
           Category? obj = _db.Categories.Find(id);
            if(obj ==null) {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();

               
            return RedirectToAction("Index");
        }

    }
}