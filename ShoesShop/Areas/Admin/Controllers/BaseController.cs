using ShoesShop.Areas.Admin.Models;
using ShoesShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoesShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (AdminLogin)Session[CommonConstant.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Login", Area = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }
        protected void SetAll(string message, string type)
        {
            TempData["AlterMessage"] = message;
            if (type == "success")
            {
                TempData["AlterType"] = "alert-success";
            }else if(type=="waring"){
                TempData["AlterType"] = "alert-warning";
            }else if (type == "error")
            {
                TempData["AlterType"] = "alter-danger";
            }
        }
    }
     
}