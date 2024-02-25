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
   //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller {

private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index() {

            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
          
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id) {
            if(id == null || id == 0) {
            return View(new Company());

            } else {
             
                Company CompanyObj = _unitOfWork.Company.Get(u=>u.Id==id);
                return View(CompanyObj);
            }
        }
       [HttpPost]
public IActionResult Upsert(Company CompanyObj) {
    if (ModelState.IsValid) {
       
        if (CompanyObj.Id == 0) {
            _unitOfWork.Company.Add(CompanyObj);
        } else {
            _unitOfWork.Company.Update(CompanyObj);
        }
        _unitOfWork.Save();
        TempData["Success"] = "Företag skapat";
        return RedirectToAction("Index");
    } else {

        return View(CompanyObj);
    }
}


        //API för att skicka data till Cloudtables
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(){
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            
            return Json(new {data = objCompanyList});
           
        }

[HttpDelete]
public IActionResult Delete(int? id){
    var CompanyToDelete = _unitOfWork.Company.Get(u => u.Id == id);

    if(CompanyToDelete == null){
        return Json(new { success = false, message = "Error vid radering: Produkt hittades inte." });
    }

    _unitOfWork.Company.Remove(CompanyToDelete);
    _unitOfWork.Save();

    return Json(new { success = true, message = "Raderingen lyckades." });
}

        #endregion

    }
}