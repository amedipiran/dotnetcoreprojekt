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

        public IActionResult Upsert(int? id) {

           //Skapa
            ProductVM productVM = new() {
                CategoryList = _unitOfWork.Category.GetAll().Select(u=> new SelectListItem {
                Text = u.Name,
                Value = u.Id.ToString()
            }), 
            Product = new Product()
            };
            if(id == null || id == 0) {
            return View(productVM);

            } else {
                //Uppdatera
                productVM.Product = _unitOfWork.Product.Get(u=>u.Id==id);
                return View(productVM);
            }
        }
        [HttpPost]
            public IActionResult Upsert(ProductVM productVM, IFormFile? file) {
               
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