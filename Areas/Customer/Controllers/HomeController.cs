using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.Repository;
using Projekt.Repository.IRepository;
using Projekt.Utility;

namespace Projekt.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

          
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = id,
            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            // Skapa en ny instans av ShoppingCart där ProductId sätts korrekt
            ShoppingCart newShoppingCart = new ShoppingCart
            {
                ProductId = shoppingCart.ProductId, // Sätt rätt ProductId här
                Count = shoppingCart.Count,
                ApplicationUserId = shoppingCart.ApplicationUserId
            };

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(
                u => u.ApplicationUserId == userId && u.ProductId == newShoppingCart.ProductId);

            if (cartFromDb != null)
            {
                // Ändra befintlig kundvagn om den finns
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();

            }
            else
            {
                // Lägg till ny kundvagnspost om ingen befintlig kundvagn hittades
                _unitOfWork.ShoppingCart.Add(newShoppingCart);
            _unitOfWork.Save();


                //Räknar hur många varor som finns i kundvagnen
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(
                u => u.ApplicationUserId == userId).Count());
            }



            TempData["success"] = "Kundvagnen uppdaterades.";
            return RedirectToAction(nameof(Index));
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
