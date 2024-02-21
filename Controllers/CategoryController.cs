using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class CategoryController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}