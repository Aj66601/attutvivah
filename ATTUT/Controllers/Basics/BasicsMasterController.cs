using ATTUT.Data.Models;
using ATTUT.Data.Models.Basics;
using ATTUT.Services.Basics;
using ATTUT.Services.General;
using ATTUT.Services.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ATTUT.Controllers.Basics
{
    public class BasicsMasterController : GeneralController
    {
        private readonly ILogger<BasicsMasterController> _logger;
        private readonly IBasicMasterServices _basicmasterServices;
        public BasicsMasterController(IGeneralServices generalServices,
            ILogger<BasicsMasterController> logger, IBasicMasterServices basicmasterServices) : base(generalServices)
        {
            _logger = logger;
            _basicmasterServices = basicmasterServices;
        }

        public async Task<IActionResult> CountryList()
        {
            object[] parameters = {  0 };
            var _result = await _basicmasterServices.CountryList(parameters);
            return View(_result);
        }

        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCountry(CountryModel obj)
        {
            object[] parameters = { 0, obj.CountryName ?? "", obj.CountryRemarks ?? "",1, GetSession().UserId };
            var _result = await _basicmasterServices.CreateOrUpdateCountry(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("CountryList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }

        //#region--------------------Category--------------------
        //public async Task<IActionResult> CategoryList()
        //{
        //    object[] parameters = { GetSession().CompanyId, 0 };
        //    var _result = await _masterServices.CategoryList(parameters);
        //    return View(_result);
        //}
        //public IActionResult AddCategory()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddCategory(CategoryModel obj)
        //{
        //    object[] parameters = { 0, GetSession().CompanyId, obj.CategoryName ?? "", 1, GetSession().UserId };
        //    var _result = await _masterServices.CreateOrUpdateCategory(parameters);
        //    if (_result.InfoCode == 0)
        //    {
        //        TempData["Success"] = _result.InfoMessage;
        //        return RedirectToAction("CategoryList");
        //    }
        //    else
        //    {
        //        TempData["Error"] = _result.InfoMessage;
        //    }
        //    return View(obj);
        //}
        //public async Task<IActionResult> EditCategory(int id)
        //{
        //    object[] parameters = { GetSession().CompanyId, id };
        //    var _result = await _masterServices.CategoryList(parameters);
        //    return View(_result.First());
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditCategory(CategoryModel obj)
        //{
        //    object[] parameters = { obj.CategoryID, GetSession().CompanyId, obj.CategoryName ?? "", obj.IsActive, GetSession().UserId };
        //    var _result = await _masterServices.CreateOrUpdateCategory(parameters);
        //    if (_result.InfoCode == 0)
        //    {
        //        TempData["Success"] = _result.InfoMessage;
        //        return RedirectToAction("CategoryList");
        //    }
        //    else
        //    {
        //        TempData["Error"] = _result.InfoMessage;
        //    }
        //    return View(obj);
        //}
        //#endregion-----------------Category--------------------
    }
}
