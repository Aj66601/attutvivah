using ATTUT.Data.Models;
using ATTUT.Helper;
using ATTUT.Services.Config;
using ATTUT.Services.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace ATTUT.Controllers
{
    [SecurityCheck]
    public class ConfigController : GeneralController
    {
        private readonly ILogger<ConfigController> _logger;
        private readonly IConfigServices _configServices;
        public ConfigController(IGeneralServices generalServices, ILogger<ConfigController> logger, IConfigServices configServices) : base(generalServices)
        {
            _logger = logger;
            _configServices = configServices;
        }
        #region--------------------Company--------------------
        
        public async Task<IActionResult> Company()
        {
            object[] parameter = { GetSession().UserId };
            var _result = await _configServices.CompanyList(parameter);
            return View(_result);
        }
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCompany(CompanyModel obj)
        {
            object[] parameters = { 0, obj.CompanyName, obj.Address, obj.Email, obj.Website, obj.Mobile, obj.GSTIN, obj.PanNo, obj.BankName, obj.BankAddress, obj.AccountNo, obj.IFSCCode, obj.Paytm, obj.CIN, GetSession().UserId };
            var _result = await _configServices.CreateOrUpdateCompany(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("Company");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        public async Task<IActionResult> EditCompany(int id)
        {
            object[] parameter = { id };
            var _result = await _configServices.CompanyById(parameter);
            return View(_result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompany(CompanyModel obj)
        {
            object[] parameters = { obj.ID, obj.CompanyName, obj.Address, obj.Email, obj.Website, obj.Mobile, obj.GSTIN, obj.PanNo, obj.BankName, obj.BankAddress, obj.AccountNo, obj.IFSCCode, obj.Paytm, obj.CIN, GetSession().UserId };
            var _result = await _configServices.CreateOrUpdateCompany(parameters);
            if (_result.InfoCode == 0)
            {
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("Company");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            return View(obj);
        }
        #endregion-----------------Company--------------------

        #region-------Branch-----------
        public async Task<IActionResult> BranchList()
        {
            object[] parameters = { GetSession().CompanyId };
            var _result = await _configServices.BranchList(parameters);
            return View(_result);
        }
        public ActionResult AddBranch()
        {
            ViewBag.DdlCompany = new SelectList(DdlCompany(), "Value", "Text");
            ViewBag.DdlState = new SelectList(DdlState(), "Value", "Text");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBranch(BranchModel obj)
        {
            object[] parameters = { obj.CompanyId, obj.BranchName, obj.BranchCode, obj.StateID, obj.Address, obj.Email, obj.ContactNo, obj.PinCode, obj.GSTIN, obj.AccountType, obj.ContactPerson, obj.ContactPersonNo, obj.BillingBranchId, GetSession().UserId };
            var _result = await _configServices.AddBranch(parameters);
            if (_result.InfoCode == 0)
            {
                if (obj.AccountType != 1 && _result.InsertedID != null)
                {
                    object[] parameters1 = { _result.InsertedID, obj.Account.BankName, obj.Account.BankAddress, obj.Account.AccountNo, obj.Account.IFSCCode, obj.Account.Paytm, "" };
                    await _configServices.UpdateBranchAccount(parameters1);
                }
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("BranchList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            ViewBag.DdlCompany = new SelectList(DdlCompany(), "Value", "Text");
            ViewBag.DdlState = new SelectList(DdlState(), "Value", "Text");
            //ViewBag.DdlBranch = new SelectList(DdlBranch(), "Value", "Text");
            return View(obj);
        }
        public async Task<IActionResult> EditBranch(int id)
        {
            object[] parameter = { id };
            var _result = await _configServices.BranchByID(parameter);
            ViewBag.DdlCompany = new SelectList(DdlCompany(), "Value", "Text");
            ViewBag.DdlState = new SelectList(DdlState(), "Value", "Text");

            return View(_result);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditBranch(BranchModel obj)
        {
            object[] parameters = { obj.BranchID, obj.CompanyId, obj.BranchName, obj.BranchCode, obj.StateID, obj.Address, obj.Email, obj.ContactNo, obj.PinCode, obj.GSTIN, obj.AccountType, obj.ContactPerson, obj.ContactPersonNo, obj.BillingBranchId, obj.IsActive, GetSession().UserId };
            var _result = await _configServices.UpdateBranch(parameters);
            if (_result.InfoCode == 0)
            {
                if (obj.AccountType != 1)
                {
                    object[] parameters1 = { obj.BranchID, obj.Account.BankName, obj.Account.BankAddress, obj.Account.AccountNo, obj.Account.IFSCCode, obj.Account.Paytm, "" };
                    await _configServices.UpdateBranchAccount(parameters1);
                }
                TempData["Success"] = _result.InfoMessage;
                return RedirectToAction("BranchList");
            }
            else
            {
                TempData["Error"] = _result.InfoMessage;
            }
            ViewBag.DdlCompany = new SelectList(DdlCompany(), "Value", "Text");
            ViewBag.DdlState = new SelectList(DdlState(), "Value", "Text");
            ViewBag.DdlBranch = new SelectList(DdlBranch(0), "Value", "Text");

            return View(obj);
        }
        #endregion-------Branch--------
        #region UserRights
        public async Task<IActionResult> UserRight(int? RoleID)
        {
            MenusModel data = new MenusModel();
            object[] parameter1 = { GetSession().UserId };
            ViewBag.DdlRole = new SelectList(DdlUserRole(0), "Value", "Text");
            if (RoleID == null)
                RoleID = 0;
            data.RoleId = RoleID.Value;
            object[] p1 = { GetSession().UserId, RoleID };
            var data_menu = await _configServices.Menus(p1);
            data.ParentList = data_menu.ToList();
            return View(data);
        }
        public async Task<IActionResult> List_Menus_json(int RoleID)
        {
            MenusModel data = new MenusModel();
            data.RoleId = RoleID;
            object[] p1 = { GetSession().UserId, RoleID };
            var data_menu = await _configServices.Menus(p1);
            data.ParentList = data_menu.ToList();
            //return PartialView("~/Views/user/_menuInRole.cshtml", data);
            return PartialView("~/Views/Config/_menuInRole.cshtml", data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRight(MenusModel obj_Menus_Model, List<MenuAccessModel> SubMenuList)
        {
            try
            {
                var result = new CreateOrUpdateModel();
                object[] para1 = { obj_Menus_Model.RoleId };
                var data2 = await _configServices.DeleteUserRight(para1);
                foreach (var item in obj_Menus_Model.ParentList)
                {
                    if (item.CheckedStatus == true)
                    {
                        object[] parameters = { obj_Menus_Model.RoleId, item.ID, GetSession().UserId };
                        result = await _configServices.AddUserRight(parameters);
                    }
                }
                foreach (var item in SubMenuList)
                {
                    if (item.CheckedStatus == true)
                    {
                        object[] parameters = { obj_Menus_Model.RoleId, item.ID, GetSession().UserId };
                        result = await _configServices.AddUserRight(parameters);
                    }
                }

                MenusModel data1 = new MenusModel();
                object[] p1 = { GetSession().UserId, obj_Menus_Model.RoleId };
                var data_menu = await _configServices.Menus(p1);
                obj_Menus_Model.ParentList = data_menu.ToList();

                TempData["Success"] = result.InfoMessage;

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            ViewBag.DdlRole = new SelectList(DdlUserRole(0), "Value", "Text");
            return View(obj_Menus_Model);
        }
        #endregion UserRights
    }
}
