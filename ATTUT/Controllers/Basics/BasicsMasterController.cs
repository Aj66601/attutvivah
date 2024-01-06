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

        #region --------- COUNTRY------------
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

        public async Task<IActionResult> EditCountry(int id)
        {
            object[] parameters = { id };
            var _result = await _basicmasterServices.CountryList(parameters);
            return View(_result.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCountry(CountryModel obj)
        {
            object[] parameters = { obj.CountryId, obj.CountryName ?? "", obj.CountryRemarks ?? "", obj.IsActive, GetSession().UserId };
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

        #endregion

        #region --------- STATES ----------
        public async Task<IActionResult> StateList()
        {
            object[] parameters = { 0 };
            var _result = await _basicmasterServices.StateList(parameters);
            return View(_result);
        }
           public IActionResult AddState()
        {
            ViewBag.DdlCountry = new SelectList(DdlCountry(), "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddState(StateModel obj)
        {
            object[] parameters = { obj.CountryId, 0, obj.StateName ?? "", obj.StateRemarks ?? "",1, GetSession().UserId };
            var _result = await _basicmasterServices.CreateOrUpdateState(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("StateList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
      
        public async Task<IActionResult> EditState(int id)
        {
            object[] parameters = { id };
            var _result = await _basicmasterServices.StateList(parameters);
            return View(_result.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditState(StateModel obj)
        {
            object[] parameters = { obj.StateId, obj.StateName ?? "", obj.StateRemarks ?? "", obj.IsActive, GetSession().UserId };
            var _result = await _basicmasterServices.CreateOrUpdateState(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("StateList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }

        #endregion

        #region --------- STATES ----------
        public async Task<IActionResult> DistrictList()
        {
            object[] parameters = { 0 };
            var _result = await _basicmasterServices.StateList(parameters);
            return View(_result);
        }
        public IActionResult AddDistrict()
        {
            ViewBag.DdlCountry = new SelectList(DdlCountry(), "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDistrict(StateModel obj)
        {
            object[] parameters = { obj.CountryId, 0, obj.StateName ?? "", obj.StateRemarks ?? "", 1, GetSession().UserId };
            var _result = await _basicmasterServices.CreateOrUpdateState(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("StateList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }


        #endregion



    }
}
