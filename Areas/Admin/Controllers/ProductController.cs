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



namespace Projekt.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {

            //Skapa
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                return View(productVM);

            }
            else
            {
                //Uppdatera
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "ProductImages");
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                bool isNewProduct = productVM.Product.Id == 0;

                if (isNewProduct)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();

                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (files != null && files.Count > 0)
                {
                    // Skapa en mapp för produkten om den inte redan finns
                    string productPath = @"images/products/product-" + productVM.Product.Id;
                    string finalPath = Path.Combine(wwwRootPath, productPath);
                    if (!Directory.Exists(finalPath))
                    {
                        Directory.CreateDirectory(finalPath);
                    }

                    foreach (IFormFile file in files)
                    {
                        // Generera en unik filnamn för att undvika namnkonflikter
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        // Kopiera filen till den slutgiltiga sökvägen
                        string fullPath = Path.Combine(finalPath, fileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Skapa en ny ProductImage och lägg till den i databasen
                        ProductImage productImage = new ProductImage
                        {
                            ImageUrl = @"/" + Path.Combine(productPath, fileName).Replace(@"\", "/"),
                            ProductId = productVM.Product.Id
                        };

                        // Lägg till ProductImage till Product om det är nödvändigt
                        if (productVM.Product.ProductImages == null)
                        {
                            productVM.Product.ProductImages = new List<ProductImage>();
                        }
                        productVM.Product.ProductImages.Add(productImage);
                    }

                    // Uppdatera produkten för att inkludera bilderna
                    _unitOfWork.Product.Update(productVM.Product);
                    _unitOfWork.Save();
                }

                TempData["Success"] = isNewProduct ? "Produkt skapad." : "Produkt uppdaterad.";
                return RedirectToAction("Index");
            }
            else
            {
                // Om ModelState inte är giltig, ladda om kategorilistan för vyn
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }

        public IActionResult RemoveImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.ProductImage.Get(u => u.Id == imageId);
            int productId = imageToBeDeleted.ProductId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {


                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                }
                _unitOfWork.ProductImage.Remove(imageToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Bilden raderad!";
            }
            return RedirectToAction(nameof(Upsert), new { id = productId });
        }

        //API för att skicka data till Cloudtables
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            return Json(new { data = objProductList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToDelete = _unitOfWork.Product.Get(u => u.Id == id);

            if (productToDelete == null)
            {
                return Json(new { success = false, message = "Error vid radering: Produkt hittades inte." });
            }

            // Kontrollera att ImageUrl inte är null eller tom innan man försöker radera bilden
                    string productPath = @"images/products/product-" + id;
                    string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);
                    if (Directory.Exists(finalPath))
                    {
                        string[] filePaths = Directory.GetFiles(finalPath);
                        foreach(string filePath in filePaths) {
                            System.IO.File.Delete(filePath);
                        }
                        Directory.Delete(finalPath);
                    }

            _unitOfWork.Product.Remove(productToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Raderingen lyckades." });
        }



        #endregion

    }
}