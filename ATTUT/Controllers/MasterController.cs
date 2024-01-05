using ATTUT.Data.Models;
using ATTUT.Services.General;
using ATTUT.Services.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ATTUT.Controllers
{
    public class MasterController : GeneralController
    {
        private readonly ILogger<MasterController> _logger;
        private readonly IMasterServices _masterServices;
        public MasterController(IGeneralServices generalServices, 
            ILogger<MasterController> logger, IMasterServices masterServices) : base(generalServices)
        {
            _logger = logger;
            _masterServices = masterServices;
        }
        #region--------------------HSN--------------------
        public async Task<IActionResult> HSNList()
        {
            object[] parameters = { GetSession().CompanyId,0 };
            var _result = await _masterServices.HSNs(parameters);
            return View(_result);
        }
        public IActionResult AddHSN()
        {
            ViewBag.DdlCompany = new SelectList(DdlCompany(), "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHSN(HSNCodeModel obj)
        {
            object[] parameters = { 0, obj.HSNCode, GetSession().CompanyId, obj.Description ?? "", obj.CGST, obj.SGST, obj.IGST, obj.Surcharge, obj.Cess, GetSession().UserId };
            var _result = await _masterServices.CreateOrUpdateHSNs(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("HSNList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        public async Task<IActionResult> EditHSN(int id)
        {
            object[] parameters = { GetSession().CompanyId, id };
            ViewBag.DdlCompany = new SelectList(DdlCompany(), "Value", "Text");
            var _result = await _masterServices.HSNs(parameters);
            return View(_result.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHSN(HSNCodeModel obj)
        {
            object[] parameters = { obj.ID, obj.HSNCode, GetSession().CompanyId, obj.Description ?? "", obj.CGST, obj.SGST, obj.IGST, obj.Surcharge, obj.Cess, GetSession().UserId };
            var _result = await _masterServices.CreateOrUpdateHSNs(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("HSNList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        #endregion-----------------HSN--------------------

        #region--------------------Brand--------------------
        public async Task<IActionResult> BrandList()
        {
            object[] parameters = { GetSession().CompanyId, 0 };
            var _result = await _masterServices.BrandList(parameters);
            return View(_result);
        }
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBrand(BrandModel obj)
        {
            obj.IsActive = true;
            object[] parameters = { 0, GetSession().CompanyId, obj.BrandName ?? "", obj.IsActive , GetSession().UserId };
            var _result = await _masterServices.CreateOrUpdateBrand(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("BrandList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        public async Task<IActionResult> EditBrand(int id)
        {
            object[] parameters = { GetSession().CompanyId, id };
            var _result = await _masterServices.BrandList(parameters);
            return View(_result.First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBrand(BrandModel obj)
        {
            object[] parameters = { obj.BrandID, GetSession().CompanyId, obj.BrandName ?? "", obj.IsActive, GetSession().UserId };
            var _result = await _masterServices.CreateOrUpdateBrand(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("BrandList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        #endregion-----------------Brand--------------------

        #region--------------------Category--------------------
        public async Task<IActionResult> CategoryList()
        {
            object[] parameters = { GetSession().CompanyId, 0 };
            var _result = await _masterServices.CategoryList(parameters);
            return View(_result);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryModel obj)
        { 
            object[] parameters = { 0, GetSession().CompanyId, obj.CategoryName ?? "", 1, GetSession().UserId };
            var _result = await _masterServices.CreateOrUpdateCategory(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("CategoryList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            object[] parameters = { GetSession().CompanyId, id };
            var _result = await _masterServices.CategoryList(parameters);
            return View(_result.First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryModel obj)
        {
            object[] parameters = { obj.CategoryID, GetSession().CompanyId, obj.CategoryName ?? "", obj.IsActive, GetSession().UserId };
            var _result = await _masterServices.CreateOrUpdateCategory(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("CategoryList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        #endregion-----------------Category--------------------

    }
}
