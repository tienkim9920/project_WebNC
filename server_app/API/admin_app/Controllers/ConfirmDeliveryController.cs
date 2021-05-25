using admin_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin_app.Controllers
{
    public class ConfirmDeliveryController : BaseNVController
    {
        // GET: ConfirmDelivery
        ShoppingEntities db = new ShoppingEntities();
        public ActionResult Index()
        {
            var orders = db.Orders.Where(c => c.status.Equals("3")).ToList();
            return View(orders);
        }

        [HttpPost]
        public JsonResult Confirm(string id)
        {
            var updateItem = db.Orders.Find(id);

            updateItem.status = "4";
            updateItem.pay = true;
            db.SaveChanges();
            return Json(new { msg = "Thành công" });
        }

    }
}