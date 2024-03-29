using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.Data;
using Projekt.Models;
using Projekt.Repository;
using Projekt.Repository.IRepository;
using Projekt.Utility;

namespace Projekt.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller {

private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {

            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                    _unitOfWork.Category.Add(obj);
                    _unitOfWork.Save();
                    TempData["Success"] = "Kategori skapad.";
                    return RedirectToAction("Index");
                }
               
            return View(obj);
        }

         public IActionResult Edit(int? id) {
            if(id == null || id == 0){
                return NotFound();
            }

            Category? CategoryFromDb = _unitOfWork.Category.Get(u=>u.Id==id);
            //Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);

           

            if (CategoryFromDb == null){
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
            public IActionResult Edit(Category obj) {
           
                if(ModelState.IsValid) {
                    _unitOfWork.Category.Update(obj);
                    _unitOfWork.Save();
                    TempData["Success"] = "Kategori uppdaterad.";

                    return RedirectToAction("Index");
                }
               
            return View(obj);
        }
    public IActionResult Delete(int? id) {
            if(id == null || id == 0){
                return NotFound();
            }

            Category? CategoryFromDb = _unitOfWork.Category.Get(u=>u.Id==id);
           

            if (CategoryFromDb == null){
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id) {
           
            Category? obj = _unitOfWork.Category.Get(u=>u.Id==id);
            if(obj ==null) {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Kategori raderad.";

               
            return RedirectToAction("Index");
        }

    }
}