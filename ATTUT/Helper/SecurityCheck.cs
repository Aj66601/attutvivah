using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ATTUT.Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SecurityCheck : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {

            if (filterContext != null)
            {
                var controlleractiondescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
                string controllername = controlleractiondescriptor?.ControllerName;
                string actionname = controlleractiondescriptor?.ActionName;

                var session = filterContext.HttpContext.Session;
                var UserId = session.GetString("UserId");
                if (UserId != null)
                {
                    var isAccessAllowed = IsAccessAllowed(controllername, actionname, UserId);
                    if (!isAccessAllowed.IsAllowed)
                    {
                        ViewResult result = new ViewResult();
                        result.ViewName = "SecurityError";
                        // result.ViewData.set() = isAccessAllowed.Message;
                        filterContext.Result = result;
                    }
                }
                else
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "SecurityError";
                    //result.TempData["ErrorMessage"] = "You are not authenticated. Please <a href='/'>log-in</a> and try again!";
                    filterContext.Result = result;
                }
            }
        }

        public IsAccessModel IsAccessAllowed(string controllerName, string actionName, string id)
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
            IsAccessModel isAccess = new();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("IsAccessAllowed", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ControllerName", controllerName);
                cmd.Parameters.AddWithValue("@ActionName", actionName);
                cmd.Parameters.AddWithValue("@UserId", id);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    isAccess.IsAllowed = Convert.ToBoolean(rdr["IsAllowed"]);
                    isAccess.Message = rdr["Message"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                isAccess.IsAllowed = false;
                isAccess.Message = ex.Message;
            }
            finally
            {
                con.Dispose();
            }
            return isAccess;
        }
        public class IsAccessModel
        {
            public bool IsAllowed { get; set; }
            public string Message { get; set; } = string.Empty;
        }
    }
}