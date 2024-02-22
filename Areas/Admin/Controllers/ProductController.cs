using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt.Data;
using Projekt.Models;
using Projekt.Models.ViewModels;
using Projekt.Repository;
using Projekt.Repository.IRepository;

namespace Projekt.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller {

private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {

            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
          
            return View(objProductList);
        }

        public IActionResult Create() {

           
            ProductVM productVM = new() {
                CategoryList = _unitOfWork.Category.GetAll().Select(u=> new SelectListItem {
                Text = u.Name,
                Value = u.Id.ToString()
            }), 
            Product = new Product()
            };
            
            return View(productVM);
        }
        [HttpPost]
            public IActionResult Create(ProductVM productVM) {
               
                if(ModelState.IsValid) {
                    _unitOfWork.Product.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["Success"] = "Produkt skapad.";
                    return RedirectToAction("Index");
                } else {
                     productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u=> new SelectListItem {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(productVM);

            
                }
               
        }

         public IActionResult Edit(int? id) {
            if(id == null || id == 0){
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.Get(u=>u.Id==id);
            //Product? productFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);

           

            if (productFromDb == null){
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
            public IActionResult Edit(Product obj) {
           
                if(ModelState.IsValid) {
                    _unitOfWork.Product.Update(obj);
                    _unitOfWork.Save();
                    TempData["Success"] = "Produkt uppdaterad.";

                    return RedirectToAction("Index");
                }
               
            return View(obj);
        }
    public IActionResult Delete(int? id) {
            if(id == null || id == 0){
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.Get(u=>u.Id==id);
           

            if (productFromDb == null){
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id) {
           
            Product? obj = _unitOfWork.Product.Get(u=>u.Id==id);
            if(obj ==null) {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Produkt raderad.";

               
            return RedirectToAction("Index");
        }

    }
}