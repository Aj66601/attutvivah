using ATTUT.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ATTUT.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Session.GetString("UserId") == null)
                filterContext.Result = new RedirectResult("/");
        }
        public SessionModel GetSession()
        {
            SessionModel _user = new SessionModel();
            var _userId = HttpContext.Session.GetString("UserId");
            var _name = HttpContext.Session.GetString("Name");
            var _branchId = HttpContext.Session.GetString("BranchId");
            var _fiscal = HttpContext.Session.GetString("Fiscal");
            var _companyId = HttpContext.Session.GetString("CompanyId");
            _user.UserId = Convert.ToInt32(_userId);
            _user.Name = _name ?? "";
            _user.BranchId = Convert.ToInt32(_branchId);
            _user.CompanyId = Convert.ToInt32(_companyId);
            _user.Fiscal = Convert.ToInt32(_fiscal);
            return _user;
        }
    }
}
