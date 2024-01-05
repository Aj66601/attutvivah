using ATTUT.Data.Models;
using ATTUT.Services.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ATTUT.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountServices _accountServices;
        const string sessionkeystore = "sessionkeystore";
        public AccountController(IAccountServices accountServices, ILogger<AccountController> logger)
        {
            _logger = logger;
            _accountServices = accountServices;
        }
        public IActionResult Login()
        {
            _logger.LogInformation("Log Information to Debug Window!");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Validation error";
                _logger.LogInformation("Invalid model");
            }
            else
            {
                try
                {
                    object[] parameters = { obj.Username, obj.Password };
                    var _dbResponse = await _accountServices.Login(parameters);
                    if (_dbResponse.UserId == 0)
                    {
                        TempData["Error"] = _dbResponse.Name;
                    }
                    else
                    {
                        object[] parameter = { _dbResponse.UserId };
                        var menuaccess = _accountServices.MenuAccess(parameter).Result; ;
                        string storesJson = JsonConvert.SerializeObject(menuaccess);
                        HttpContext.Session.SetString(sessionkeystore, storesJson);
                        HttpContext.Session.SetString("UserId", _dbResponse.UserId.ToString());
                        HttpContext.Session.SetString("BranchId", _dbResponse.BranchId.ToString());
                        HttpContext.Session.SetString("Name", _dbResponse.Name);
                        HttpContext.Session.SetString("Role", _dbResponse.Role);
                        HttpContext.Session.SetString("CompanyId", _dbResponse.CompanyId.ToString());
                        HttpContext.Session.SetString("Fiscal", _dbResponse.Fiscal.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    TempData["Error"] = ex.Message;
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
