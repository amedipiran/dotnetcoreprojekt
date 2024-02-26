using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.Models.ViewModels;
using Projekt.Repository;
using Projekt.Repository.IRepository;

namespace Projekt.Areas.Customer.Controllers {
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM {get; set;}
        public CartController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index() {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

    ShoppingCartVM = new () {
        ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId == userId,includeProperties:"Product")
    };
    foreach(var cart in ShoppingCartVM.ShoppingCartList){
        cart.Price = GetPriceBasedOnQuantity(cart);
        ShoppingCartVM.OrderTotal +=(cart.Price*cart.Count);
    }
            return View(ShoppingCartVM);
        }
private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart) {
    if (shoppingCart.Count <= 5) {
        return shoppingCart.Product.Price ?? 0; // Ange standardvärde om null
    } else if (shoppingCart.Count <= 10) {
        return shoppingCart.Product.Price50 ?? 0; // Ange standardvärde om null
    } else {
        return shoppingCart.Product.Price100 ?? 0; // Ange standardvärde om null
    }
}


    }}