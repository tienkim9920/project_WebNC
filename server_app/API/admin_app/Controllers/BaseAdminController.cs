using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class BaseAdminController : Controller
    {
        ShoppingEntities db = new ShoppingEntities();
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session["id"] == null || !Session["role"].Equals("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index" }));
            }


            base.OnActionExecuted(filterContext);
        }
    }
}